namespace NUnit.Tests.Example;

public class Tests
{
    private int _numberToAssert = 1;

    [SetUp]
    [Test]
    public async Task Test1()
    {
        _numberToAssert = 2;
        await Task.Delay(2000);
        Assert.That(_numberToAssert, Is.EqualTo(2));
    }

    [Test]
    public async Task Test2()
    {
        await Task.Delay(2000);
        Assert.That(_numberToAssert, Is.EqualTo(1));
    }

    [Test]
    [TestCase(1)]
    [TestCase(5)]
    [TestCase(5)]
    public void Test2(int number)
    {
        Assert.That(_numberToAssert, Is.EqualTo(number));
    }

    [TestCaseSource(nameof(GetTestData))]
    public void Test3(int number)
    {
        Assert.That(_numberToAssert, Is.EqualTo(number));
    }


    public static IEnumerable<TestCaseData> GetTestData()
    {
        yield return new TestCaseData(1);
        yield return new TestCaseData(2);
        yield return new TestCaseData(3);
    }
}