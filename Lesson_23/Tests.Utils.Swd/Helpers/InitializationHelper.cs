using System.Reflection;
using OpenQA.Selenium;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseElements;
using Tests.Utils.Swd.BaseElements.Abstractions;

namespace Tests.Utils.Swd.Helpers;

public static class InitializationHelper
{
    public static void InitializeElements(object page)
    {
        // Get all the fields and properties marked with the FindBy attribute
        var type = page.GetType();
        var members = type
            .GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(m => m.GetCustomAttributes(typeof(FindByAttribute), true).Any());

        foreach (var member in members)
        {
            // Get the FindBy attribute from the member
            var findByAttr = member
                .GetCustomAttributes<FindByAttribute>(true)
                .FirstOrDefault();

            var memberType = member.MemberType;
            if (findByAttr != null)
            {
                // Get the By locator directly from the attribute
                By locator = findByAttr.GetLocator();

                switch (member)
                {
                    // Set the element using the locator, for both fields and properties
                    case FieldInfo field:
                        field.SetValue(page, CreateElement(field.FieldType, locator));
                        break;
                    case PropertyInfo property:
                        property.SetValue(page, CreateElement(property.PropertyType, locator));
                        break;
                }
            }
        }
    }

    private static BaseElement CreateElement(Type element, By locator)
    {
        if (element == typeof(Button))
            return new Button { Locator = locator };
        if (element == typeof(CheckBox))
            return new CheckBox { Locator = locator };
        if (element == typeof(Input))
            return new Input { Locator = locator };

        if (element == typeof(WebElements))
            return new WebElements { Locator = locator };


        throw new ArgumentException("Invalid element type");
    }
}