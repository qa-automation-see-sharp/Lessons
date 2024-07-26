namespace ObjectsAndOOP;

public class ObjectsClasses
{
    /*
     * Useful information about Objects and Classes
     * https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/objects
     */
    public void RunExample()
    {
        // Behavior of value type
        int myInt1 = 5;
        int myInt2 = myInt1;
        myInt2 = 7;
        Console.WriteLine(myInt1);
        Console.WriteLine(myInt2);

        // example of your own value type (struct)
        var personStruct1 = new PersonStruct("Oleh", 30);
        var personStruct2 = personStruct1;

        personStruct2.Name = "Ivan";
        Console.WriteLine(personStruct1.Name);
        Console.WriteLine(personStruct2.Name);

        //Behavior of reference type
        var personClass1 = new PersonClass("Oleh", 30);
        var personClass2 = personClass1;

        personClass2.Name = "Ivan";

        Console.WriteLine(personClass1.Name);
        Console.WriteLine(personClass2.Name);


        // Every class we create is inherited from Object class
        // This means that all these classes have these methods by default
        var obj1 = new PersonClass("Oleh", 30);
        var obj2 = new PersonClass("Oleh", 30);

        /*The GetType method in C#
         * Is a method provided by the System.Object class, which is the base class for all types in C#.
         * This method is used to obtain the runtime Type of the current instance. The Type object provides information
         * about the type, including its name, namespace, methods, properties, and other metadata.
         * */

        /*Key Points About GetType Method
         * Purpose: The GetType method is used to get the exact runtime type of an instance.
         * This is useful for reflection, debugging, and type comparisons.
         * Return Type: GetType returns an instance of the Type class from the System namespace.
         *
         * Usage: It is commonly used in scenarios where type information is needed at runtime,
         * such as when performing type checks or using reflection to dynamically interact with objects.
         */
        var type = obj1.GetType();
        Console.WriteLine(type);

        /* The ToString() method in C#
         * It ss a built-in method defined in the System.Object class, which is the base class for all types in C#.
         * This method is used to return a string representation of an object. By default, the ToString() method returns
         * the fully qualified name of the object's type.
         *
         * However, it can be overridden in derived classes to provide a more meaningful
         * string representation of the object.
         */

        /* Usage in Built-In Types
         * Many built-in types in C# provide their own implementation of ToString().
         * For example:
         * Numeric Types: int, double, etc., return the string representation of their value.
         * DateTime: Provides a formatted date and time string.
         * Collections: Types like List<T> use ToString() to return information about the collection.
         */

        var str = obj1.ToString();
        Console.WriteLine(str);

        /* The Equals method in C#
         * Used to determine whether two objects are considered equal. It is a method defined in the System.Object class,
         * which is the base class for all types in .NET.
         * By default, the Equals method checks for reference equality, meaning it checks whether the two object references
         * point to the same instance in memory.
         * However, this behavior can be overridden in derived classes to implement value equality,
         * which compares the contents of the objects.
         */

        var equals = obj1.Equals(obj2);
        Console.WriteLine(equals);

        /* The GetHashCode method in C#
         * A hash code is a numerical value that is used to uniquely identify objects during operations such
         * as adding them to a hash-based collection like a Dictionary, HashSet, or Hashtable.
         *  The GetHashCode method provides this hash code for an object.
         *
         * Purpose:
         * Hash codes are primarily used for efficient insertion and lookup in hash-based collections.
         * They provide a way to quickly distribute objects into buckets.
         *
         * Overrides:
         * When you override Equals, you should also override GetHashCode to ensure that equal objects return the same hash code.
         */

        /* Important Considerations:
         * Consistency: Always ensure that Equals and GetHashCode are consistent with each other.
         *
         * If Equals considers two objects equal, GetHashCode must return the same value for both objects.
         *
         * Symmetry and Transitivity:
         * Ensure that Equals is symmetric (a.Equals(b) == b.Equals(a)) and transitive (a.Equals(b) and b.Equals(c)
         * implies a.Equals(c)).
         *
         * Null Handling: Always check for null in the Equals method to avoid NullReferenceException.
         */

        var hashCode = obj1.GetHashCode();
        Console.WriteLine(hashCode);

        Console.WriteLine(
            $"Person1 hash code: {personClass1.GetHashCode()} \nPerson2 hash code: {personClass2.GetHashCode()}");
    }
}

//Class Example
public class PersonClass
{
    // Properties
    public string Name { get; set; }
    public int Age { get; set; }

    // Constructor
    public PersonClass(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Override ToString
    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }

    // Override GetHashCode and Equals
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Age);
    }

    // Override Equals
    public override bool Equals(object? obj)
    {
        /* ReferenceEquals
         * Default method in Object class to check reference equality between two objects.
         */

        // Null handling
        if (ReferenceEquals(null, obj)) return false;

        // check if the objects have the same reference
        if (ReferenceEquals(this, obj)) return true;

        // check if the objects are of the same type
        if (obj.GetType() != this.GetType()) return false;

        // call the Equals method
        return Equals((PersonClass)obj);
    }

    protected bool Equals(PersonClass other)
    {
        // check if the properties are the same
        return Name == other.Name && Age == other.Age;
    }
}

// Struct example
public struct PersonStruct
{
    public string Name { get; set; }
    public int Age { get; set; }

    public PersonStruct(string name, int age)
    {
        Name = name;
        Age = age;
    }
}