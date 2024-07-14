// initialization

string firstName;
firstName = "Oleh";
var lastName = "Kutafin";

// concatenation
var fullName = firstName + " " + lastName;

// Read from the console example
Console.WriteLine("Hi there user! What is your first name?");
var firstName1 = Console.ReadLine();
Console.WriteLine("Hi there user! What is your last name?");
var lastName1 = Console.ReadLine();
Console.WriteLine("How old are you?");
var usersAge = Console.ReadLine();

//What is Char?
var whatIsThis = lastName1[0];
var myChar = 'a';

Console.WriteLine("Welcome to our service");
Console.WriteLine("Full name: " + fullName);
Console.WriteLine("Age: " + usersAge);

Console.WriteLine("Your name has " + firstName1.Length + " characters");
Console.WriteLine("And your name start with " + firstName1[0]);