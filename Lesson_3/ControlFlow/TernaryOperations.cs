namespace ControlFlow;

public class TernaryOperations
{
    public void Run()
    {
        // Ternary operations are a way to write if-else statements in a single line
        // They are useful when you have a simple condition and you want to assign a value based on it
        // The syntax is: condition ? valueIfTrue : valueIfFalse
        // The condition is evaluated first, if it is true, the valueIfTrue is returned, otherwise the valueIfFalse is returned
        var number = -5;

        // variable = (condition) ? expressionTrue : expressionFalse;
        var result = number > 0 ? "Positive" : "Negative";
        Console.WriteLine(result);

        // You can also use ternary operations to assign values to variables
        var a = 5;
        var b = 10;
        var max = a > b ? a : b;
        Console.WriteLine(max);

        // Ternary operations can be nested
        var x = 5;
        var y = 10;
        var z = 15;
        var maxNumber = x > y ? x > z ? x : z : y > z ? y : z;
        Console.WriteLine(maxNumber);
    }
}