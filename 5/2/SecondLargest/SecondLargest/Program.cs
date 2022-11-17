using System;

namespace SecondLargest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj ilosc liczb a nastepnie wpisuj je od nowej linii");
            int highest=0;
            int secondH=0;
            bool isSecond = false;
            int temp=0;
            int n = System.Int32.Parse(Console.ReadLine());
            for(int i=0; i < n; i++)
            {
                temp = System.Int32.Parse(Console.ReadLine());
                if (i == 0)
                    highest = temp;
                else {
                    if (temp > highest)
                    {
                        secondH = highest;
                        highest = temp;
                        isSecond = true;
                    }
                    else if (temp < highest)
                    {
                        if (isSecond)
                        {
                            if (temp > secondH)
                                secondH = temp;
                        }
                        else
                        {
                            secondH = temp;
                            isSecond = true;
                        }

                    }
                }
            }
            if (isSecond)
                Console.WriteLine("druga najwieksza to "+ secondH);
            else
                Console.WriteLine("brak rozwiazania");
            

        }
    }
}
