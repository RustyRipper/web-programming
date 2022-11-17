
using System;

public class Ex3
{
    class Car
    {
        string name;
    }
    private static bool Product10(int x)
    {
        return x > 10;
    }
    public static void test() 
    {
        int[] numbers = new int[] { 1, 2, 3, 4, 5, 9, 12, 3, 2, 11};
        
        Console.WriteLine(Array.Find(numbers, Product10));
        Console.WriteLine(Array.FindIndex(numbers, 8, 2, Product10));
        Array.Reverse(numbers);
        foreach (int item in numbers){
            Console.Write(item + " ");
        }
        Array.Sort(numbers);
        Console.WriteLine();
        foreach (int item in numbers)
        {
            Console.Write(item+ " ");
        }

        Console.WriteLine();
        Console.WriteLine(Array.IndexOf(numbers, 11));

    }
}