using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.IO;

namespace Libary
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till bibloteket\n \nVad vill du göra?\n" +"(1) logga in\n(2) skapa ett konto?");
            string answer1 = Console.ReadLine();
            

            if (answer1.Contains("2"))
            {
                Register.Show();

            }
            if (answer1.Contains("1"))
            {
                Login.Show();
            }
        }
    }
}