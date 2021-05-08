using System.Collections.Generic;
using System;

namespace KeyboardNav
{
    class Program
    {

        public static List<string> names = new List<string> { "Toyyib", "Faruq", "Ade", "Laide", "Mateen", "Fareed"};
        static void Main(string[] args)
        {

            Menu();
        }

        static void Menu()
        {

            bool show = true;
            int currentIndex = 0;

            Console.Write("Enter First Name: ");
            string Fname = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string PNumnber = Console.ReadLine();
            Console.WriteLine("Select a teacher: ");

            WriteNameList(currentIndex);

            while (show)
            {
                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    currentIndex = (currentIndex + 1 > names.Count - 1) ? names.Count - 1 : currentIndex + 1;

                    WriteNameList(currentIndex, true);
                }

                else if (keyPressed.Key == ConsoleKey.UpArrow)
                {
                    currentIndex = (currentIndex - 1 < 0) ? 0 : currentIndex - 1;
                    WriteNameList(currentIndex, true);
                }

                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    var cp = Console.GetCursorPosition();

                    int count = 1;

                    while (count <= names.Count + 1)
                    {
                        Console.SetCursorPosition(0, cp.Top - count);
                        Console.WriteLine("                     ");
                        count++;
                    }

                    Console.ResetColor();
                    Console.SetCursorPosition(0, cp.Top - count+1);
                    Console.Write("Selected Teacher: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(names[currentIndex]);
                    show = false;
                }
            }
            Console.ResetColor();
            Console.Write("\nEnter your age: ");
            string age = Console.ReadLine();
        }

        static void WriteNameList(int currentIndex, bool adjustCursorPosition = false)
        {

            if (adjustCursorPosition)
            {
                var cp = Console.GetCursorPosition();

                Console.SetCursorPosition(0, cp.Top - names.Count);
            }

            for (int i = 0; i < names.Count; i++)
            {
                if (i == currentIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"(*) {names[i]}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"( ) {names[i]}");
                }
            }
        }
    }
}
