// See https://aka.ms/new-console-template for more information


int number = 10;
double myDouble = number; // Implicit casting
double myDouble2 = 3.7d; // Explicit casting

int myInt = (int)myDouble2; // Explicit casting

string mystring = "123";

int myInt32 = Convert.ToInt32(mystring);
int myInt2 = int.Parse(mystring); // Parsing


Console.WriteLine(myInt);