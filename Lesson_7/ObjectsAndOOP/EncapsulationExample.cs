namespace ObjectsAndOOP;

/* Encapsulation is the concept of wrapping data (variables) and methods (functions) together as a single unit.
 * It restricts direct access to some of an object's components, which can prevent the accidental
 * modification of data.
 */
public class EncapsulationExample
{
    public Person1 Person = new() { Name = "Oleh", Age = 30 };
    private Person1 Person1 = new() { Name = "Oleh", Age = 30 };
}

// Example of encapsulation
public class Person1
{
    // Private fields
    private string name;
    private int age;

    // Public properties
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }
} 