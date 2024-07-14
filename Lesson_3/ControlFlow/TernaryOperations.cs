namespace ControlFlow;

public class TernaryOperations
{
    public void Run()
    {
        // Ternary operations are a way to write if-else statements in a single line
        // They are useful when you have a simple condition and you want to assign a value based on it
        // The syntax is: condition ? valueIfTrue : valueIfFalse
        // The condition is evaluated first, if it is true, the valueIfTrue is returned, otherwise the valueIfFalse is returned
        int number = -5;
        
        // variable = (condition) ? expressionTrue : expressionFalse;
        string result = number > 0 ? "Positive" : "Negative";
        Console.WriteLine(result);

        // You can also use ternary operations to assign values to variables
        int a = 5;
        int b = 10;
        int max = a > b ? a : b;
        Console.WriteLine(max);

        // Ternary operations can be nested
        int x = 5;
        int y = 10;
        int z = 15;
        int maxNumber = x > y ? (x > z ? x : z) : (y > z ? y : z);
        Console.WriteLine(maxNumber);
    }
}