// See https://aka.ms/new-console-template for more information


var number = 10;
double myDouble = number; // Implicit casting
var myDouble2 = 3.7d; // Explicit casting

var myInt = (int)myDouble2; // Explicit casting

var mystring = "123";

var myInt1 = Convert.ToInt32(mystring);
var myInt2 = int.Parse(mystring); // Parsing

// Conditional parsing
var myInt3 = 0;
if (int.TryParse(mystring, out var tmp))
{
    myInt3 = tmp;
}


Console.WriteLine(myInt);
Console.WriteLine(myInt1);
Console.WriteLine(myInt2);
Console.WriteLine(myInt3);