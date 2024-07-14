namespace Loops;

public class ForEach
{
    public void Run()
    {
        // a foreach loop is used to iterate over a
        // collection of values
        // to be more specific, it iterates over
        // things that are "IEnumerable"
        // all collections are IEnumerable!

        // here is what a foreach loop looks like
        // foreach (Type thing in collectionOfThings)
        // {
        //     // do something...
        // }

        // let's see a real example with a number array!
        int[] numbers = { 1, 2, 3, 4, 5 };
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }

        // what about with... a list of strings?
        List<string> words = new List<string>
        {
            "red",
            "green",
            "blue",
        };
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }

        // how about with... a dictionary?
        Dictionary<string, int> ages = new()
        {
            { "Alice", 25 },
            { "Bob", 24 },
            { "Charlie", 26 },
        };
        //foreach (KeyValuePair<string, int> person in ages)
        foreach (KeyValuePair<string, int> kvp in ages)
        {
            Console.WriteLine($"{kvp.Key} is {kvp.Value} years old");
        }

        // we can use break and continue in a foreach loop
        // just like other loops too!
        foreach (int number in numbers)
        {
            if (number == 3)
            {
                break;
            }

            Console.WriteLine(number);
        }
    }
}