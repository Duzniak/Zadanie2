using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj liczbę:");
        int liczba = int.Parse(Console.ReadLine());

        if (liczba % 2 == 0)
        {
            Console.WriteLine("Liczba jest parzysta.");
        }
        else
        {
            Console.WriteLine("Liczba jest nieparzysta.");
        }
    }
}