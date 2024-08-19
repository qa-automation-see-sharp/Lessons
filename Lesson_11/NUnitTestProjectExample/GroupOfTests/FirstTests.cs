using NUnitTestProjectExample.Fixtures;

namespace NUnitTestProjectExample.GroupOfTests;

[TestFixture, Parallelizable(ParallelScope.None)]
public class FirstTests : FirstGroupOfTests
{
    [Test, Order(2), Description("This is a test1")]
    [TestCase(1, 2)]
    public void Test1(int a, int b)
    {
        Console.WriteLine("----> Test1");
        Console.WriteLine($"----> First number: {a}, Second number: {b}");
        Thread.Sleep(1000);
        Assert.Pass();
    }

    [Test, Order(1), Description("This is a test2")]
    [TestCase("mam", "dad")]
    public void Test2(string a, string b)
    {
        Console.WriteLine("----> Test2");
        Console.WriteLine($"----> First string: {a}, Second string: {b}");
        Thread.Sleep(5000);
        Assert.Pass();
    }
}