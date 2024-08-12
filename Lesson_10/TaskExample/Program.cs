Task myTask = new Task(() => Console.WriteLine("Hello, from task"));
myTask.Start();

var myClass = new MyClass();
    myClass.RunJob("Digging");

Task<int> myTask2 = new Task<int>(() => Sum(5, 6));
myTask2.Start();
var result = myTask2;
Console.WriteLine(result);




int Sum(int a, int b) => a + b;


public class MyClass
{
    public async Task RunJob(string managerMessage)
    {
        await Task.Run(() => { DoJob(managerMessage); });

        Console.WriteLine($"Manager:Good Job!");
    }

    public async Task DoJob(string message)
    {
        Console.WriteLine($"Worker:Job {message} is being done...");
        await Task.Delay(1000);
        Console.WriteLine($"Worker:Job {message} is done!");
    }
}