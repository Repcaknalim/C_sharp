using System;   //jak w c++, omijamy w ten sposób "przedrostki"

namespace NumberGuesser //Jak w c++, te same nazwy funkcji w dwóch różnych namespaceach
{
    class Program
    {
        static void Main()
        {
            GetAppInfo();

            string username = GetUserName();

            GreetUser(username);

            Random random = new Random();           //obiekt klasy random
            int correctNumber = random.Next(1,11);  //wylosuj losową liczbę z przedziału 1-10

            bool correctAnswer = false;

            Console.WriteLine("Odgadnij liczbe (1-10)");

            while (!correctAnswer)
            { 
                string input = Console.ReadLine();

                bool isNumber = int.TryParse(input, out int guess); //Sprawdź czy input to liczba

                if (!isNumber) 
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Prosze wprowadzic liczbe.");
                    continue;   //przejdz do konca petli
                }

                if (guess > 10 || guess < 1)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Prosze wprowadzic liczbe z przedzialu 1-10.");
                    continue;   //przejdz do konca petli
                }

                if (guess < correctNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Za malo");
                }
                else if (guess > correctNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Za duzo");
                }
                else
                {
                    PrintColorMessage(ConsoleColor.Green, "Prawidlowa odpowiedz!");
                    correctAnswer = true;
                }
            }
        }

        static void GetAppInfo()
        {
            string appName = "Zgadywanie Liczby";
            int appVersion = 1;
            string appAuthor = "Kacper";

            string info = $"[{appName}] Wersja: 0.0.{appVersion}, Autor: {appAuthor}";

            PrintColorMessage(ConsoleColor.Magenta, info);
        }

        static string GetUserName()
        {
            Console.WriteLine("Jak masz na imie?");

            string inputUserName = Console.ReadLine();      //Wczytanie inputu z klawiatury

            return inputUserName;
        }

        static void GreetUser(string username)
        {
            string greetings = $"Powodzenia {username}";

            PrintColorMessage(ConsoleColor.Blue, greetings);
        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;     //Zmień kolor napisów w konsoli

            Console.WriteLine(message);     //Wypisanie w jednej lini

            Console.ResetColor();       //Zresetuj kolor napisów w konsoli
        }
    }
}