using System.Collections;

namespace xUnit.Tests.Example;

public class UnitTest1 : IAsyncLifetime
{
    private int _numberToAssert = 1;
    private int _numberToToSetUp;

    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[] { 1 };
        yield return new object[] { 2 };
        yield return new object[] { 3 };
    }

    // SetUp 
    public UnitTest1()
    {
        _numberToToSetUp = 5;
        // SetUp is goes here in constructor
    }

    // Async SetUp
    public async Task InitializeAsync()
    {
        await Task.Delay(1000);
    }

    [Fact]
    public async Task Test1()
    {
        Assert.True(_numberToAssert == 1);
        Assert.True(_numberToToSetUp == 5);
        await Task.Delay(2000);
    }

    [Fact]
    public async Task Test2()
    {
        _numberToAssert = 2;
        Assert.True(_numberToAssert == 2);
        Assert.True(_numberToToSetUp == 5);
        await Task.Delay(2000);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Test3(int number)
    {
        Assert.Equal(_numberToAssert, number);
    }

    [Theory]
    [MemberData(nameof(GetTestData))]
    public void Test4(int number)
    {
        Assert.Equal(_numberToAssert, number);
    }

    [Theory]
    [ClassData(typeof(TestDataCollection))]
    public void Test5(int number)
    {
        Assert.Equal(_numberToAssert, number);
    }

    //Teardown
    public async Task DisposeAsync()
    {
        _numberToToSetUp = 0;
        await Task.Delay(1000);
    }
}

public class TestDataCollection : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 1 };
        yield return new object[] { 2 };
        yield return new object[] { 3 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}