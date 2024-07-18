namespace Collections;

public class Dictionary
{
    public void Run()
    {
        // Dictionaries are used to store key-value pairs
        // - dictionaries are not zero based
        // - dictionaries are dynamic in size
        // - we can get values from a dictionary
        // - we can set values in a dictionary
        // - we can add values to a dictionary
        // - we can remove values from a dictionary
        // - we can clear a dictionary
        // - we can check if a dictionary contains a key
        // - we can check if a dictionary contains a value
        // - we can get the count of a dictionary
        // - we can get the keys of a dictionary
        // - we can get the values of a dictionary

        // here is how we declare a dictionary
        var words = new Dictionary<string, string>();

        // here is how we add values to a dictionary
        words.Add("one", "uno");
        words.Add("two", "dos");
        words.Add("three", "tres");
        words["one"] = "cuatro";

        // here is how we get values from a dictionary
        var one = words["one"];
        var two = words["two"];
        var three = words["three"];

        // words is now:
        // ["one" => "cuatro"]
        // ["two" => "dos"]
        // ["three" => "tres"]

        // here is how we declare and initialize a dictionary
        var numbers = new Dictionary<int, string>
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "three" },
            { 4, "four" }
        };

        // here is how we get the count of a dictionary
        var count = numbers.Count; //4

        // here is how we remove a value from a dictionary
        numbers.Remove(1);
        numbers.Remove(2);
        numbers.Remove(3);

        // numbers is now:
        // [2 => "two"]

        var users = new Dictionary<string, Dictionary<string, double>>
        {
            {
                "John", new Dictionary<string, double>
                {
                    { "password", 1000000.99d }
                }
            }
        };
    }
}