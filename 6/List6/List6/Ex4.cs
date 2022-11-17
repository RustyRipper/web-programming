
using System;

namespace List6
{
    class Ex4
    {
        public static void printTuple(dynamic tuple)
        {
            (string firstName, string lastName, int age, double salary) person =
                (tuple.imie, tuple.nazwisko, tuple.wiek, tuple.placa);


            Console.WriteLine($" Imie: {person.Item1} Nazwisko: {person.Item2} Wiek: {person.Item3} Placa: {person.Item4}");

            Console.WriteLine($" Imie: {person.firstName} Nazwisko: {person.lastName} Wiek: {person.age} Placa: {person.salary}");

            var person2 = (FName: tuple.imie, LName: tuple.nazwisko, Age: tuple.wiek, Salary: tuple.placa);

            Console.WriteLine($" Imie: {person2.FName} Nazwisko: {person2.LName} Wiek: {person2.Age} Placa: {person2.Salary}");
        }
        public static void test()
        {
            var tup = new { imie = "Tadeusz", nazwisko = "Mickiewicz", wiek = 20, placa = 12.2 };
            Ex4.printTuple(tup);
        }
    }
}
