//Namespace is a way to organize your code, it is a container for classes, interfaces, structs, enums, and delegates

namespace OopIntro;

// access modifiers are keywords that determine the accessibility of a class, method, or filed, property, in C#
// there are 6 access modifiers in C#: public, private, protected, internal, protected internal, and private protected
// No access modifier means private

public class AccessModifiers
{
    Person3 _person = new Person3();

    //Private class can be declared only inside the other class
    private class Person3
    {
        private string _name = "John";

        public string GetName()
        {
            return _name;
        }
    }
}

//this is a private class, we can access it only in this namspace
class Person
{
    private string _name;
    // public Person3  _person = new Person3(); this will cause a compilation error
}

//this is a public class, we can access it from any other namespace
class Person2
{
    private string _name = "John";
}