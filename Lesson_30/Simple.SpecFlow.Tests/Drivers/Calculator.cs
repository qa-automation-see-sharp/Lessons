namespace Simple.SpecFlow.Tests.Drivers;

public class Calculator
{
    public int Result { get; private set; }
    public int Add(int a, int b)
    {
        return Result = a + b;
    }
    
    public int Subtract(int a, int b)
    {
        return Result = a - b;
    }
}