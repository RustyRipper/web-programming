using System;

public class Ex1
{
    public static void printTuple((string imie, string nazwisko, int wiek, double placa) tuple)
    {
        (string firstName, string lastName, int age, double salary) person = 
            (tuple.imie, tuple.nazwisko, tuple.wiek, tuple.placa);
 

        Console.WriteLine($" Imie: {person.Item1} Nazwisko: {person.Item2} Wiek: {person.Item3} Placa: {person.Item4}");

        Console.WriteLine($" Imie: {person.firstName} Nazwisko: {person.lastName} Wiek: {person.age} Placa: {person.salary}");

        var person2 = (FName: tuple.imie, LName: tuple.nazwisko, Age: tuple.wiek, Salary: tuple.placa);

        Console.WriteLine( $" Imie: {person2.FName} Nazwisko: {person2.LName} Wiek: {person2.Age} Placa: {person2.Salary}");
    }
    public static void test()
    {
        var tup = (Imie: "Tadeusz", Nazwisko: "Mickiewicz", Wiek: 50, Placa: 12.22);
        printTuple(tup);
    }
}
