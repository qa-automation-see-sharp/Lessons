namespace ObjectsAndOOP;

/* An interface in C#.
 * Is a contract that defines a set of methods, properties, events, or indexers without any implementation.
 * Classes or structs that implement the interface must provide the implementation for all its members.
 * Interfaces are used to define capabilities that can be shared among different classes,
 * enabling polymorphism and multiple inheritance of behavior.
 */

/* Key Points About Interfaces in C#.
 * Definition: Interfaces define a contract that implementing classes or structs must adhere to. They cannot contain any implementation.
 * 
 * Syntax: Interfaces are declared using the interface keyword. Usually named with a leading "I" to indicate it's
 * an interface.
 * 
 * Implementation: A class or struct implements an interface using the : InterfaceName syntax and must provide
 * an implementation for all interface members.
 * 
 * Multiple Inheritance: A class or struct can implement multiple interfaces, which allows for multiple inheritance
 * of behavior.
 * 
 * Polymorphism: Interfaces enable polymorphic behavior, allowing objects to be treated based on the interface they
 * implement rather than their concrete type.
 */

/* Useful links to docs
 * https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces
 */
public class InterfaceExample
{
    public void RunExample()
    {
        var rectangle = new Rectangle(5, 10);
        var circle = new Circle(5);
        
        Console.WriteLine($"Rectangle Area: {rectangle.Area()}");
        Console.WriteLine($"Rectangle Perimeter: {rectangle.Perimeter()}");
        
        var shapes = new List<IShape> {rectangle, circle};
        foreach (var shape in shapes)
        {
            Console.WriteLine($"Area: {shape.Area()}");
            Console.WriteLine($"Perimeter: {shape.Perimeter()}");
        }
    }
}

// Interface 
public interface IShape
{
    double Area();
    double Perimeter();
}

// Class Rectangle implements IShape
public class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Area()
    {
        return Width * Height;
    }

    public double Perimeter()
    {
        return 2 * (Width + Height);
    }
}

// Class Circle implements IShape
public class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public double Perimeter()
    {
        return 2 * Math.PI * Radius;
    }
}