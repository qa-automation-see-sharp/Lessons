namespace ObjectsAndOOP;

/* Inheritance in C#
 * is one of the core concepts of object-oriented programming (OOP) in C#.
 * It allows a class to inherit the properties and methods of another class.
 * The class that inherits is called the derived class or subclass, and the class being inherited from is called
 * the base class or superclass.
 */
/* Useful articles about Inheritance
 * https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/inheritance
 */

public class Inheritance
{
    /* Key Points About Inheritance in C#.
     * Reusability: Inheritance promotes reusability by allowing new classes to use the properties and methods of existing classes.
     * Extensibility: It allows you to extend the functionality of existing classes without modifying them.
     * Hierarchy: Inheritance helps in creating a hierarchical classification.
     *
     * Syntax:
     * To implement inheritance in C#, you use a colon (:) followed by the base class name after the derived class name.
     */

    // Example of inheritance
    public void RunExample()
    {
        // Class Cat inherits from Animal
        var cat = new Cat { Age = 4, Name = "Tom" };
        var dog = new Dog("Rex", 5);
        var bird = new Bird { Age = 2, Name = "Kesha" };

        var zoo = new List<Animal> { cat, dog, bird };

        foreach (var animal in zoo)
        {
            Console.WriteLine(
                $"{animal.GetType().Name}, who's name is  {animal.Name}, and age: {animal.Age}. Now is making a sound:");

            // We can use 'is' keyword to check if the object is of a certain type
            if (animal is Dog d)
            {
                d.Bark();
            }
            else if (animal is Cat c)
            {
                c.Meow();
            }
            else if (animal is Bird b)
            {
                b.Sing();
            }
        }
    }
}

// Base class
public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    // this default constructor is not necessary, but having this one gives
    // us the ability to create an object without passing any parameters
    public Animal()
    {
    }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void Voice()
    {
        Console.WriteLine("Animal voice...");
    }
}

// Derived class
public class Dog : Animal
{
    // To use base class constructor we need to call it from the derived class constructor 
    // with base keyword and parameters of base class we want to pass
    public Dog(string name, int age) : base(name, age)
    {
    }

    public void Bark()
    {
        Console.WriteLine("Barking...");
    }

    // clases could have a virtual methods that could be overridden in derived classes
    public override void Voice()
    {
        Console.WriteLine("Barking...");
    }
}

// Derived class
public class Cat : Animal
{
    public void Meow()
    {
        Console.WriteLine("Meowing...");
    }

    public override void Voice()
    {
        Console.WriteLine("Meowing...");
    }
}

// Derived class
public class Bird : Animal
{
    public void Sing()
    {
        Console.WriteLine("Singing...");
    }

    public override void Voice()
    {
        Console.WriteLine("Singing...");
    }
}