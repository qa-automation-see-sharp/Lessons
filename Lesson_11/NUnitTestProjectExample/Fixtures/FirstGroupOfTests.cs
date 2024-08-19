namespace NUnitTestProjectExample.Fixtures;

[TestFixture, Parallelizable(ParallelScope.None)]
public class FirstGroupOfTests : TestRunSetup
{
    [OneTimeSetUp]
    public void OneTimeSetUpFirstGroupOfTests()
    {
        Console.WriteLine("----> FirstGroupOfTests OneTimeSetUp <----");
    }

    [SetUp]
    public void Setup()
    {
        Console.WriteLine(" ----> FirstGroupOfTests Fixture Setup <---");
    }

    [TearDown]
    public void TearDown()
    {
        Console.WriteLine("----> FirstGroupOfTests TearDown <----");
    }
    [OneTimeTearDown]
    public void OneTimeTearDownFirstGroupOfTests()
    {
        Console.WriteLine("----> FirstGroupOfTests OneTimeTearDown <----");
    }
}