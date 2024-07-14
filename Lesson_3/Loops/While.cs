namespace Loops;

public class While
{
    public void Run()
    {
        int count = 0;
        while (count < 5)
        {
            Console.WriteLine(count);
            count++;
        }

        Console.WriteLine($"The total count is {count}!");

        // here is a do while loop that counts to 5
        count = 0;
        do
        {
            Console.WriteLine(count);
            count++;
        } while (count < 5);
        Console.WriteLine($"The total count is {count}!");
    }
}