using System.Reflection;
using OpenQA.Selenium;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;
using Tests.Utils.Swd.BaseWebElements.Elements.Table;

namespace Tests.Utils.Swd.Helpers;

public static class InitializationHelper
{
    public static void InitializeElements(object page)
    {
        InitializeElements(page, null);
    }

    public static void InitializeElements(object page, IWebElement? parent)
    {
        // Get all the fields and properties marked with the FindBy attribute
        var members = page.GetType()
            .GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(m => m.GetCustomAttributes(typeof(FindByAttribute), true).Any());

        foreach (var member in members)
        {
            // Get the FindBy attribute from the member
            var findByAttr = member.GetCustomAttribute<FindByAttribute>(true);

            if (findByAttr != null)
            {
                // Get the By locator directly from the attribute
                var locator = findByAttr.GetLocator();
                if (member is FieldInfo field)
                {
                    var fieldValue = field.GetValue(page);
                    if (fieldValue is null) // Initialize only if the field hasn't been initialized yet
                    {
                        var element = CreateElement(field.FieldType, locator, parent);
                        field.SetValue(page, element);
                    }

                    // Recurse only if the field represents a page object or another composite structure
                    if (IsCompositeElement(field.FieldType))
                    {
                        // Pass the parent element for scoping
                        InitializeElements(field.GetValue(page), (field.GetValue(page) as BaseElement)?.ParentElement);
                    }

                    field.SetValue(page, CreateElement(field.FieldType, locator, parent));
                }
                // Initialize properties in the same way as fields
                else if (member is PropertyInfo property)
                {
                    var propertyValue = property.GetValue(page);
                    if (propertyValue is null)
                    {
                        var element = CreateElement(property.PropertyType, locator, parent);
                        property.SetValue(page, element);
                    }

                    // Recurse only if the property represents a page object or another composite structure
                    if (IsCompositeElement(property.PropertyType))
                    {
                        // Pass the parent element for scoping
                        InitializeElements(property.GetValue(page),
                            (property.GetValue(page) as BaseElement)?.ParentElement);
                    }
                }
            }
        }
    }

    private static object? CreateElement(Type element, By locator, IWebElement? parent)
    {
        if (!typeof(BaseElement).IsAssignableFrom(element)) throw new ArgumentException("Invalid element type");
        if (element == typeof(Element))
            return new Element { Locator = locator, ParentElement = parent };
        if (element == typeof(Button))
            return new Button { Locator = locator, ParentElement = parent };
        if (element == typeof(CheckBox))
            return new CheckBox { Locator = locator, ParentElement = parent };
        if (element == typeof(Input))
            return new Input { Locator = locator, ParentElement = parent };
        if (element == typeof(RadioButton))
            return new RadioButton { Locator = locator, ParentElement = parent };
        if (element == typeof(Table))
            return new Table { Locator = locator, ParentElement = parent };
        if (element == typeof(Rows))
            return new Rows { Locator = locator, ParentElement = parent };
        if (IsGenericType(element))
        {
            var elementType = element.GetGenericArguments()[0];
            return Activator.CreateInstance(
                typeof(Elements<>).MakeGenericType(elementType),
                locator, parent) as BaseElement;
        }

        throw new ArgumentException("Invalid element type");
    }

    private static bool IsGenericType(Type type)
    {
        return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Elements<>);
    }

    // Method to determine if a type is a composite element or a nested page object
    private static bool IsCompositeElement(Type type)
    {
        // Recursion only applies to page objects or complex types, not basic elements like Input, Button, etc.
        return !typeof(BaseElement).IsAssignableFrom(type) && type.IsClass;
    }
}