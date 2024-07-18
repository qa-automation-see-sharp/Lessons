namespace OopIntro;

public class FieldsAndProperties
{
    public void RunExample()
    {
        // a field is a variable that is declared directly in a class.

        // what does private do in the above examples?
        // "private" is an access modifier.
        // We saw "public" as an access modidier in earlier videos.
        // "private" specifies that something is accessible only within the class


        var john = new Person2();
        // john._name = "John"; // this will not work because _name is private


        var johnWithMethod = new Person3();
        //Console.WriteLine(johnWithMethod.GetName());

        // methods and functions can also have "private" access modifiers
        // if a method/function is private, it can only be accessed within the class
        // there are other access modifiers that we won't cover in this course


        var johnWithProperty = new Person4();
        Console.WriteLine(johnWithProperty.Name);
        Console.WriteLine(johnWithProperty.Name2);
        Console.WriteLine(johnWithProperty.Name3);

        Console.WriteLine("Setting the name...");
        johnWithProperty.MutableName = "John Doe";
        Console.WriteLine(johnWithProperty.MutableName);
        Console.WriteLine(johnWithProperty.Name);
        Console.WriteLine(johnWithProperty.Name2);
        Console.WriteLine(johnWithProperty.Name3);
    }

    // here is how we declare a field in a class
    private class Person
    {
        private string _name;
    }

    // we can give a field a value when we declare it
    private class Person2
    {
        private string _name = "John";
    }

    // we can access _name using a method!
    private class Person3
    {
        private readonly string _name = "John";

        public string GetName()
        {
            return _name;
        }
    }

    // A property is a member that provides a flexible mechanism to
    // read, write, or compute the value of a private field.
    private class Person4
    {
        public string Name { get; private set; } = "John";

        public string Name2 => Name;

        public string Name3 { get; } = "John";

        public string MutableName
        {
            get => Name;
            set => Name = value;
        }
    }
}