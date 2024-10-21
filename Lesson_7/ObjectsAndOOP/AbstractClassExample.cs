namespace ObjectsAndOOP;

/* An abstract class in C#.
 * Is a class that cannot be instantiated directly. It serves as a base class for other classes and can contain both
 * abstract methods (methods without implementation) and non-abstract methods (methods with implementation).
 * Abstract classes are used to provide a common definition of a base class that multiple derived classes can share.
 */
/* Key Points About Abstract Classes in C#.
 * Cannot Be Instantiated: You cannot create an instance of an abstract class directly.
 * Abstract Methods: Abstract classes can have abstract methods, which are declared without any implementation.
 * Derived classes must provide an implementation for these abstract methods.
 *
 * Non-Abstract Methods: Abstract classes can also have non-abstract methods, which can have implementation.
 *
 * Constructor: Abstract classes can have constructors, which can be called when derived classes are instantiated.
 *
 * Usage: Abstract classes are used when you want to define a common base class with some shared functionality and some
 * functionality that must be implemented by derived classes.
 */
/* Summary:
 * abstract classes in C# are powerful tools for creating a base class with common functionality and abstract members
 * that must be implemented by derived classes.
 * They provide a balance between the flexibility of interfaces and the shared implementation of base classes.
 */
/* Abstraction is the concept of hiding the complex implementation details and
 * showing only the necessary features of an object. It is achieved using
 * abstract classes and interfaces.
 */

public class AbstractClassExample
{
    public void RunExample()
    {
        // We create instances of derived classes 
        var car = new Car { Model = "Model 3", Make = "Tesla", Year = 2021, Color = "Red" };
        var boat = new Boat { Model = "Speedster", Make = "Sea-Doo", Year = 2020, Color = "Blue" };
        var plane = new Plane { Model = "747", Make = "Boeing", Year = 2019, Color = "White" };

        // store them in a list of base class type
        var vehicles = new List<Vehicle> { car, boat, plane };

        // acting like a base class but getting different results based on the actual object type
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine(
                $"Model: {vehicle.Model}, Make: {vehicle.Make}, Year: {vehicle.Year}, Color: {vehicle.Color}");
            vehicle.StartUp();
            vehicle.Move();
        }
    }
}

// Base abstract class
public abstract class Vehicle
{
    public string Model { get; set; }
    public string Make { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }

    // this default constructor is not necessary, but having this one gives
    // us the ability to create an object without passing any parameters
    public Vehicle()
    {
    }

    // constructor with parameters 
    // this constructor helps to initialize the object with the provided values
    public Vehicle(string model, string make, int year, string color)
    {
        Model = model;
        Make = make;
        Year = year;
        Color = color;
    }

    // abstract method don't have a body and must be implemented in derived classes 
    public abstract void Move();

    // virtual method can have a body and can be overridden in derived classes
    public virtual void StartUp()
    {
        Console.WriteLine("Stopping...");
    }
}

// All derived classes must implement the abstract method Move() from the base class Vehicle.

// Derived classes
public class Car : Vehicle
{
    // This constructors gives us ability create a object with default fields values
    public Car()
    {
    }

    // this constructor helps to initialize the object with the provided values
    public Car(string model, string make, int year, string color) : base(model, make, year, color)
    {
    }

    public override void Move()
    {
        Console.WriteLine("Car is moving...");
    }

    public override void StartUp()
    {
        Console.WriteLine("Starting...");
    }
}

// Derived classes
public class Boat : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Motorcycle is swimming...");
    }
}

// Derived classes
public class Plane : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Plane is flying...");
    }
}