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
            Console.WriteLine("Välkommen till bibloteket\n \nVill du logga in eller skapa ett konto?");
            string answer1 = Console.ReadLine();
            

            if (answer1.Contains("skapa"))
            {
                Register.Show();
            }
            if (answer1.Contains("logga"))
            {
                Login.Show();
            }
        }
    }
}