// We can declare a boolean variable

bool myBool;
bool my_bool;
bool MyBool;

// We can assign a value to these variables
myBool = true;
myBool = false;

// We can declare and assign in one line
var coolBool = true;

// We can re-assign a value to these variables
coolBool = false;

// We can do boolean logic with these variables

// && is the AND operator as long as both sides are true the result is true
var trueAndFalse = true && false; // false
var trueAndTrue = true && true; // true
var falseAndFalse = false && false; // false

// || is the OR operator as log as one side is true the result is true
var trueOrFalse = true || false; // true
var trueOrTrue = true || true; // true
var falseOrFalse = false || false; // false

// ! is the NOT operator it inverts the value
var notTrue = !true; // false
var notFalse = !false; // true

// The results of our boolean logic
// as we see with string interpolation:
Console.WriteLine($"true && False: {trueAndFalse}");
Console.WriteLine($"true && True: {trueAndTrue}");
Console.WriteLine($"false && False: {falseAndFalse}");
Console.WriteLine($"true || False: {trueOrFalse}");
Console.WriteLine($"true || True: {trueOrTrue}");
Console.WriteLine($"false || False: {falseOrFalse}");
Console.WriteLine($"!True: {notTrue}");
Console.WriteLine($"!False: {notFalse}");