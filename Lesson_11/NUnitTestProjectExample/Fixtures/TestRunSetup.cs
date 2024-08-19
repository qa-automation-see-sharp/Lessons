namespace NUnitTestProjectExample.Fixtures;

[SetUpFixture]
public class TestRunSetup
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Console.WriteLine("----> TestRunSetup OneTimeSetUp <----");
    }
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Console.WriteLine("----> TestRunSetup OneTimeTearDown <----");
    }
}