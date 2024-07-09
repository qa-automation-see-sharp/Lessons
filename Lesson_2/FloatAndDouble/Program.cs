// Useful links:
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types

// This program demonstrates the use of floating-point numeric data types in C#

// float from ±1.5 x 10^−45 to ±3.4 x 10^38  precision of 7 digits 4 bytes or 32 bits
float myFloat = 3.14f;
var myFloat2 = 3.14f;
Console.WriteLine($"Float max value is {float.MaxValue}, min value is {float.MinValue}");

// double from ±5.0 × 10^−324 to ±1.7 × 10^308 precision of 15-16 digits 8 bytes or 64 bits
double myDouble = 3.14;
var myDouble2 = 3.14d;
Console.WriteLine($"Double max value is {double.MaxValue}, min value is {double.MinValue}");

// decimal from ±1.0 x 10^-28 to ±7.9 x 10^28 precision of 28-29 digits 16 bytes or 128 bits 
decimal myDecimal = 3.14m;
var myDecimal2 = 3.14m;
Console.WriteLine($"Decimal max value is {decimal.MaxValue}, min value is {decimal.MinValue}");

float sum = 5.5f + 5.5f;
Console.WriteLine($"5.5 + 5.5 = {sum}");

float difference = 5.5f - 10.5f;
Console.WriteLine($"5.5 - 10.5 = {difference}");

float product = 5.5f * 5.5f;
Console.WriteLine($"Product of two floats is {product}");

float quotient = 15.5f / 10.5f;
Console.WriteLine($"Quotient of two floats is {quotient}");

float quotient2 = 5 / 10;
Console.WriteLine($"Quotient of two integers is {quotient2}");

float quotient3 = 5f / 10;
Console.WriteLine($"Quotient of two integers is {quotient2}");