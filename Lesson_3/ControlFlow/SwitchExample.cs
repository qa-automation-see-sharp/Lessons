namespace ControlFlow;

public class SwitchExample
{
    public void Run()
    {
        
        // The switch statement is used to select one of
        // many code blocks to be executed.
        // The switch expression is used to select one of
        // many code blocks to be executed.

        // here is an example of a switch statement
        int dayOfWeek = 1;
        
        switch (dayOfWeek)
        {
            case 1:
                Console.WriteLine("Monday");
                break;
            case 2:
                Console.WriteLine("Tuesday");
                break;
            case 3:
                Console.WriteLine("Wednesday");
                break;
            case 4:
                Console.WriteLine("Thursday");
                break;
            case 5:
                Console.WriteLine("Week Day");
                break;
            case 6:
                Console.WriteLine("Weekend");
                break;
            case 7:
                Console.WriteLine("Weekend");
                break;
            default:
                Console.WriteLine("Invalid day");
                break;
        }
        
        Console.WriteLine("This is after the switch!");
        
        // here is an example of a switch expression
        string dayOfWeekName = "Monday";
        
        string result = dayOfWeekName switch
        {
            "Monday" => "First day of the week",
            "Tuesday" => "Second day of the week",
            "Wednesday" => "Third day of the week",
            "Thursday" => "Fourth day of the week",
            "Friday" => "Fifth day of the week",
            "Saturday" => "Sixth day of the week",
            "Sunday" => "Seventh day of the week",
            _ => "Invalid day"
        };
    }
}