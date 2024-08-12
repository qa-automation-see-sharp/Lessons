var myClass = new MyClass();
var myDelegate = new MyDelegate(myClass.Method1);
var myDelegate2 = new MyDelegate(myClass.Method2);

var both = myDelegate + myDelegate2;
    both("Hello, from delegate");

var anonimusDelegate = new MyDelegate(delegate { Console.WriteLine("Hello, from anonimus delegate"); });


anonimusDelegate.Invoke(null);


//TODO лямбда-вирази 

public delegate void MyDelegate(string? message);

public class MyClass
{
    public void Method1(string message)
    {
        Console.WriteLine(message);
    }

    public void Method2(string message)
    {
        Console.WriteLine(message);
    }
}