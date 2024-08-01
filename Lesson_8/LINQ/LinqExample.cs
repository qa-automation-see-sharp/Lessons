namespace LINQ;

/* Що таке LINQ?
 * LINQ (Language Integrated Query) - це потужний інструмент у .NET, який дозволяє запитувати дані з різних джерел
 * (масиви, списки, бази даних, XML-файли тощо) у стилі, схожому на SQL. LINQ надає уніфікований підхід до обробки даних,
 * роблячи код більш читабельним та підтримуваним.
 */
/* What is LINQ?
 * LINQ (Language Integrated Query) is a powerful tool in .NET that allows querying data from various sources
 * (arrays, lists, databases, XML files, etc.) in a SQL-like manner. LINQ provides a unified approach to data processing,
 * making the code more readable and maintainable.
 */

// Delegate example
internal delegate bool MyDelegate(int n);

public class LinqExample
{
    private readonly int[] _arrayOfInt = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
    private readonly int[][] _arrayOfInt1 = [[1, 2, 3, 4, 5], [6, 7, 8, 9, 10], [11, 12, 13, 14, 15]];
    private readonly List<int> _listOfInt = [1, 2, 123, 44, 1, 33, 55, 77, 88, 89, 6, 99];

    private readonly List<Person> _listPersons = new()
    {
        new Person { Name = "Alice", Age = 20 },
        new Person { Name = "Bob", Age = 22 },
        new Person { Name = "Charlie", Age = 23 },
        new Person { Name = "David", Age = 21 },
        new Person { Name = "Eve", Age = 22 }
    };

    private readonly Dictionary<string, int> _dictionary = new()
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
        { "ten", 10 }
    };

    private readonly List<string> _listOfStrings =
    [
        "Banana", "Banana1", "Banana2", "Banana3", "Banana4", "Banana5", "Banana", "Banana7", "Banana8", "Banana9",
        "Banana10"
    ];

    /* IEnumerable<T> is an interface in the System.Collections.Generic namespace in C#.
     * It defines a single method, GetEnumerator, which returns an enumerator that iterates through a collection.
     * This interface is the base interface for all non-generic collections that can be enumerated, meaning you can
     * use it to loop through any collection that implements IEnumerable<T>.
     *
     * IEnumerable<T> provides a simple way to iterate over a collection of a specified type. It's commonly used
     * with the foreach loop, which internally calls the GetEnumerator method to get an enumerator
     * to iterate through the collection.
     */

    // SQL syntax like LINQ
    public void Linq_Example()
    {
        IEnumerable<int> queryExample1 =
            from number in _arrayOfInt
            where number > 4
            select number;

        IEnumerable<int> queryExample2 =
            from number in _listOfInt
            where number > 50
            select number;

        IEnumerable<KeyValuePair<string, int>> queryExample3 =
            from pair in _dictionary
            where pair.Value > 5
            orderby pair.Value
            select pair;

        Console.WriteLine("----> LINQ like SQL <----");
        Console.WriteLine($"Here is the elements inside of collection:\n{string.Join(',', _arrayOfInt)}");
        Console.WriteLine();
        Console.WriteLine("Here is the result of our query:" +
                          "\nfrom number in _arrayOfInt" +
                          "\nwhere number > 4" +
                          "\nselect number;");
        Console.WriteLine();
        foreach (var number in queryExample1)
        {
            Console.WriteLine($"Number: {number}");
        }
        Console.WriteLine();
    }

    /* What is a Lambda Expression in C#?
     * A lambda expression in C# is an anonymous function that you can use to create delegates or expression
     * tree types. Lambda expressions are used extensively in LINQ (Language Integrated Query) to write inline
     * expressions for operations such as filtering, sorting, and transforming data.
     */

    /* Лямбда-вираз в C# - це анонімна функція, яку можна використовувати для створення делегатів або типів
     * дерев виразів. Лямбда-вирази широко використовуються в LINQ (Language Integrated Query) для написання
     * вбудованих виразів для операцій, таких як фільтрація, сортування та перетворення даних.
     */
    // lambda expression after the arrow => is the body of the function
    private readonly Func<int> _expression = () => 1;

    // lambda expression after the arrow => is the body of the function
    private readonly Func<Person> _expressionExample2 = () => new Person { Name = "Alice", Age = 20 };

    public void Lambda_Example()
    {
        Console.WriteLine("----> Lambda <----");
        Console.WriteLine("Here is the result of our lambda expression:");
        Console.WriteLine(_expression.Invoke());
        Console.WriteLine(_expressionExample2.Invoke());
        Console.WriteLine();
    }

    /* What is a Delegate in C#?
     * A delegate in C# is a type that represents references to methods with a specific parameter list and
     * return type. Delegates are similar to function pointers in C or C++, but they are type-safe and secure.
     * They are used to pass methods as arguments to other methods,
     * allowing for flexible and dynamic method invocation.
     */

    /* Делегат у C# - це тип, що представляє посилання на методи з певним списком параметрів та типом повернення.
     * Делегати схожі на вказівники на функції в C або C++, але вони є безпечними та надійними.
     * Вони використовуються для передачі методів як аргументів іншим методам, що дозволяє гнучке
     * та динамічне викликання методів.
     */

    readonly MyDelegate _myDelegate = n => n > 1;

    private void MyDelegate_Example()
    {
        var myDelegateExample = _listOfInt.Where(_myDelegate.Invoke);
        Console.WriteLine("---> Delegate <---");
        Console.WriteLine("Using delegate to filter elements with Where method in the collection:");
        Console.WriteLine(myDelegateExample);
        Console.WriteLine();
    }

    /* In C#, you can assign a lambda expression to a variable by using delegate types such as Func, Predicate and Action.
     * These types are predefined generic delegates provided by the .NET framework.
     * Func delegates are used for lambda expressions that return a value.
     * Action delegates are used for lambda expressions that do not return a value.
     *
     * Using Func<T>
     * Func<T> delegates can have up to 16 input parameters and one output parameter.
     * The last type parameter in the Func delegate specifies the return type.
     */

    /* This is an example of how we can use
     * Simple expression (bool method)
     * Func<T> delegate
     * Predicate<T> delegate
     */

    // Expression could be extracted to a variable or method like this:

    //method
    private bool SimpleExpression(int n)
    {
        return n > 4;
    }

    // Property or field
    private bool SimpleExpression2(int n) => n > 4;

    // Function
    private Func<int, bool> expressionForWhere = n => n > 4;

    // Predicate
    private Predicate<int> predicateExample = n => n > 4;

    /* Where - filters the collection based on a specific condition
     * takes the condition as a lambda expression
     * returns IEnumerable<T>, where T is type of elements in collection
     */
    public void Where_Example()
    {
        var whereMethodExample1 = _listOfInt.Where(n => n > 4);
        var whereMethodExample2 = _listOfInt.Where(SimpleExpression);
        var whereMethodExample3 = _listOfInt.Where(expressionForWhere);
        var whereMethodExample4 = _listOfInt.Where(predicateExample.Invoke);

        Console.WriteLine("----> Where <----");
        Console.WriteLine("Here is example of what we gonna see if we gonna _listOfInt.Where(n => n > 4)\n");
        Console.WriteLine(string.Join(',', whereMethodExample1));

        Console.WriteLine("Here is example of what we gonna see if we gonna use our Local Function " +
                          "_listOfInt.Where(SimpleExpression)\n");
        Console.WriteLine(string.Join(',', whereMethodExample2));

        Console.WriteLine("Here is example of what we gonna see if we gonna use our Func<int, bool>");
        Console.WriteLine(string.Join(',', whereMethodExample3));

        Console.WriteLine("Here is example of what we gonna see if we gonna use our Predicate<int>");
        Console.WriteLine(string.Join(',', whereMethodExample4));
        Console.WriteLine();
    }

    /* Select - вибирає певні елементи з колекції
     * Надалі буду використовувати тільки лямбда-вирази бо вони більш популярні та зручніші для використання в LINQ
     */
    public void Select_Example()
    {
        var newPersonAfterFilter = new List<Person>();

        foreach (var person in _listPersons)
            if (person.Age > 18)
                newPersonAfterFilter.Add(person);

        var selectExample = _listPersons
            .Where(person => person.Age > 18)
            .Select(person => person.Name)
            .ToList();

        Console.WriteLine("----> Select <----");
        Console.WriteLine("List of elements before our sorting and grouping:" +
                          $"\n{string.Join("\n", _listPersons)}");
        Console.WriteLine();
        Console.WriteLine("Here is list of persons names, who are older than 18:\n");
        selectExample.ForEach(s => Console.WriteLine(s));
        Console.WriteLine();
    }

    /* OrderBy, OrderByDescending - сортує колекцію за певним критерієм
    */
    public void OrderedBy_Example()
    {
        var selectExample1 = _listPersons
            .Where(person => person.Age > 18)
            .OrderBy(person => person.Name)
            .Select(person => person.Name)
            .ToList();
        Console.WriteLine("----> OrderBy <----");
        Console.WriteLine("List of elements before our sorting and grouping:" +
                          $"\n{string.Join("\n", _listPersons)}");
        Console.WriteLine();
        Console.WriteLine("Here is list of persons names, who are older than 18, sorted by name:\n");
        selectExample1.ForEach(s => Console.WriteLine(s));
        Console.WriteLine();
    }

    /* ThenBy, ThenByDescending - використовується для сортування колекції за додатковим критерієм
    */
    public void ThenBy_Example()
    {
        var selectExample1 = _listPersons
            .Where(person => person.Age > 18)
            .OrderBy(person => person.Name) //ascending
            .ThenBy(person => person.Age) //ascending
            .Select(person => person.Name)
            .ToList();

        Console.WriteLine("----> ThenBy <----");
        Console.WriteLine("List of elements before our sorting and grouping:" +
                          $"\n{string.Join("\n", _listPersons)}");
        Console.WriteLine();
        Console.WriteLine("Here is list of persons names, who are older than 18, " +
                          "sorted by name and then by age:\n");
        selectExample1.ForEach(s => Console.WriteLine(s));
        Console.WriteLine();
    }

    /* GroupBy - групує елементи колекції за певним критерієм
    */
    public void GroupedBy_Example()
    {
        var groupByExample = _listOfInt
            .Where(i => i > 18)
            .GroupBy(i => i % 2 == 0 ? "Even" : "Odd")
            .Select(i => new { Key = i.Key, Count = i.Count() });

        Console.WriteLine("---> GroupBy <---");
        Console.WriteLine("Elements grouped by even and odd numbers:\n");

        foreach (var newObj in groupByExample)
        {
            Console.WriteLine($"{newObj.Key} - {newObj.Count}");
        }

        Console.WriteLine();
    }

    /* ToList, ToArray, ToDictionary - перетворює колекцію в інший тип колекції
    */
    public void ToLost_ToDictionary_ToArray_Example()
    {
        Console.WriteLine("----> ToList, ToDictionary, ToArray <----");
        Console.WriteLine($"Here is the elements inside of collection: \n{string.Join(',', _arrayOfInt)}");

        // Array to list example
        List<int> toListExample = _arrayOfInt.ToList();

        // Array to Dictionary example 
        Dictionary<string, int> toDictionaryExample = _arrayOfInt.ToDictionary(s => s.ToString(), pair => pair);

        Console.WriteLine("Here is elements after we gonna use ToDictionary method:");
        foreach (var kvp in toDictionaryExample)
        {
            Console.WriteLine($"{kvp.Key} - {kvp.Value}");
        }

        Console.WriteLine();
    }

    /* First, FirstOrDefault, Last, LastOrDefault - повертає перший або останній елемент колекції
    */
    public void First_FirstOrDefault_Last_LastOrDefault_Example()
    {
        Console.WriteLine($"Here is the elements inside of collection:\n{string.Join(',', _listOfInt)}");

        Console.WriteLine("----> First <---");
        Console.WriteLine("If no element found First(i => i > 1000), exception will be thrown, exception:\n");

        int? someInt = null;
        try
        {
            someInt = _listOfInt.First(i => i > 1000);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        Console.WriteLine();

        var firstOrDefault = _listPersons.FirstOrDefault(i => i.Age > 1000);

        Console.WriteLine("----> FirstOrDefault <---");
        Console.WriteLine(
            "If no element found FirstOrDefault(i => i > 1000), method will return default value, which is null, output:");

        if (firstOrDefault is not null)
        {
            Console.WriteLine(firstOrDefault);
        }
        else
        {
            Console.WriteLine("Not found");
        }

        Console.WriteLine("Last, LastOrDefault works the same way as First," +
                          " FirstOrDefault, but returns last element of the collection");
        Console.WriteLine();

        Console.WriteLine("Here is example of what we gonna see if we gonna use our First method to list of int");
        var array = _arrayOfInt1.Select(i => i.FirstOrDefault(j => j > 5)).ToArray();
        Console.WriteLine(string.Join(", ", array));
        Console.WriteLine();
    }

    /* Any, All - використовується для перевірки умови на кожному елементі колекції
    */
    public void Any_All_TrueForAll_Exist_Contains_Example()
    {
        var any = _listOfInt.Any(i => i > 50);
        var all = _listOfInt.All(i => i > 50);
        var trueForAll = _listOfInt.TrueForAll(i => i > 50);
        var exists = _listOfInt.Exists(i => i > 50);
        var contains = _listOfInt.Contains(123);

        Console.WriteLine("----> Boolean methods <----");
        Console.WriteLine($"Here is the elements inside of collection: {string.Join(',', _listOfInt)}");
        Console.WriteLine();
        Console.WriteLine($"Method Any(i => i > 50) output: {any}");
        Console.WriteLine($"Method All(i => i > 50) output: {all}");
        Console.WriteLine($"Method TrueForAll(i => i > 50) output: {trueForAll}");
        Console.WriteLine($"Method Exists(i => i > 50) output: {exists}");
        Console.WriteLine($"Method Contains(123) output: {contains}");
        Console.WriteLine();
    }

    /* Count - повертає кількість елементів у колекції
     */
    public void Count_Example()
    {
        var countExample = _listOfInt.Count(i => i > 50);
        Console.WriteLine("----> Method Count <----");
        Console.WriteLine($"Here is the elements inside of collection: {string.Join(',', _listOfInt)}");
        Console.WriteLine();
        Console.WriteLine(
            $"Method Cout will give as the amount of elements in the collection, and count is: {countExample}");
        Console.WriteLine();
    }

    /* Sum, Min, Max, Average - використовується для обчислення суми, мінімального,
     * максимального значення та середнього значення елементів колекції
     */
    public void Sum_Min_Max_Average_Example()
    {
        var sumExample = _arrayOfInt.Sum(i => i);
        var minExample = _listOfInt.Min(i => i);
        var maxExample = _listOfInt.Max(i => i);
        var averageExample = _listOfInt.Average(i => i);

        Console.WriteLine("----> Sum, Min, Max, Average <----");
        Console.WriteLine($"Here is the elements inside of collection: {string.Join(',', _listOfInt)}");
        Console.WriteLine();
        Console.WriteLine($"Method Sum(i => i) output: {sumExample}");
        Console.WriteLine($"Method Min(i => i) output: {minExample}");
        Console.WriteLine($"Method Max(i => i) output: {maxExample}");
        Console.WriteLine($"Method Average(i => i) output: {averageExample}");
        Console.WriteLine();
    }

    /*
     * How Equals is different from Contains
     */
    public void Equals_Vs_Contains_Example()
    {
        Console.WriteLine("----> Equals vs Contains <----");
        Console.WriteLine($"Here is what inside of collection:\n{string.Join(',', _listOfStrings)}");
        Console.WriteLine();

        var tmp = _listOfStrings.Where(s => s.Equals("Banana")).ToList();
        Console.WriteLine($"If we gonna use Equals method to compare elements, we will see:\n{string.Join(',', tmp)}");
        Console.WriteLine();


        var tmp2 = _listOfStrings.Where(s => s.Contains("Banana")).ToList();
        Console.WriteLine(
            $"If we gonna use Contains method to compare elements, we will see:\n{string.Join(',', tmp2)}");
        Console.WriteLine();
    }

    public void RunAllRunLinqExample()
    {
        Linq_Example();
        Lambda_Example();
        MyDelegate_Example();
        Where_Example();
        Select_Example();
        OrderedBy_Example();
        ThenBy_Example();
        GroupedBy_Example();
        ToLost_ToDictionary_ToArray_Example();
        First_FirstOrDefault_Last_LastOrDefault_Example();
        Any_All_TrueForAll_Exist_Contains_Example();
        Count_Example();
        Sum_Min_Max_Average_Example();
        Equals_Vs_Contains_Example();
    }
}