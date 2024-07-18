// See https://aka.ms/new-console-template for more information

var myInt1 = 5;
var myInt2 = 6;
var myInt3 = myInt1;

Console.WriteLine(myInt1);
myInt3 = myInt1 + 1;
Console.WriteLine(myInt1);
Console.WriteLine(myInt3);

var myClass = new MyClass(); //new reference
var myClass2 = new MyClass(); //new reference
var myClass3 = myClass; //same reference as myClass

Console.WriteLine(myClass.Name);
myClass3.Name = "New Name";
Console.WriteLine(myClass.Name);


public class MyClass
{
    public string Name { get; set; } = "MyClass";
}