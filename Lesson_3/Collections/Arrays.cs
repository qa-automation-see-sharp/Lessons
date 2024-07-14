namespace Collections;

public class Arrays
{
    public void Run()
    {
        // arrays are a collection of variables of the same type
        // - arrays are zero based
        // - arrays are fixed in size
        // - we can get values from an array
        // - we can set values in an array

        //ways of initialization 
        int[] intArray1 = new int[5];
        intArray1[0] = 1;
        intArray1[1] = 2;
        int[] intArrays2 = new int[] { 1, 2, 3, 4, 5 };
        int[] intArray3 = [1, 2, 3, 4, 5];

        string[] stringArray1 = new string[5];
        stringArray1[0] = "one";
        stringArray1[1] = "two";

        string[] stringArray2 = new string[] { "one", "two", "three", "four", "five" };
        string[] stringArray3 = ["one", "two", "three", "four", "five"];

        // here is how we declare an array
        int[] numbers = new int[3];

        // [1]
        // [2]
        // [3]

        // here is how we set values in an array
        numbers[0] = 1;
        numbers[1] = 2;
        numbers[2] = 3;

        // here is how we get values from an array
        int firstNumber = numbers[0];
        int secondNumber = numbers[1];

        // here is how we declare and initialize an array
        int[] numbers2 = new int[]
        {
            5,
            6,
            7,
            8,
        };
        double[] numbers3 =
        {
            10.1,
            11.1,
            12.1,
        };
        int[] numbers4 =
        [
            3,
            4,
            5,
        ];

        // here is how we get the length of an array
        int length = numbers.Length; //3
    }
}