using NUnitTestProjectExample.Fixtures;

namespace NUnitTestProjectExample.OtherGroupOfTests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
[Order(1)]
[Category("SecondTests bla la")]
public class SecondTests : FirstGroupOfTests
{
    [SetUp]
    public void SetUpSecondTests()
    {
        Console.WriteLine("SecondTests Setup");
    }

    [TestCaseSource(typeof(SecondTestsData), nameof(SecondTestsData.GetTestData))]
    public int Test1(int a, int b)
    {
        return a + b;
    }

    [Test]
    public void Test2()
    {
        Console.WriteLine("SecondTests Test2");
        Thread.Sleep(2000);
    }
}

public sealed class SecondTestsData
{
    public static IEnumerable<TestCaseData> GetTestData()
    {
        yield return new TestCaseData(1, 2)
            .SetName("Positive Numbers")
            .SetCategory("PositiveNumbers")
            .Returns(3);

        yield return new TestCaseData(1, 2)
            .SetName("Positive Numbers")
            .SetCategory("PositiveNumbers")
            .Returns(3)
            .Ignore("Ignore this test");

        yield return new TestCaseData(3, 3)
            .SetName("Negative Numbers")
            .SetCategory("PositiveNumbers")
            .Returns(6);
    }
}