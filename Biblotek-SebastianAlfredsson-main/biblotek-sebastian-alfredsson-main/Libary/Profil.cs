using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.IO;
using System.Collections;

namespace Libary
{
    class Profil
    {
        static string path = "C:\\Users\\Elev\\Documents\\inlogg.txt";
        public static void Show()
        {
            Console.Clear();
            Console.WriteLine(" -----------------------------------");
            Console.WriteLine("      Välkommen till din profil      ");
            Console.WriteLine(" Ditt nuvarande personummer är: "+Login.username1);
            Console.WriteLine(" Ditt nuvarande lösenord: "+Login.password1);
            Console.WriteLine(" -----------------------------------");
            Console.WriteLine(" Vill du ändra ditt lösenord skriv (1)");
            Console.WriteLine(" Vill du ansöka om biblotikarie skriv (2)");
            Console.WriteLine(" Vill du gå tillbaka till homepage skriv (3)");
            Console.WriteLine(" -----------------------------------");
            string answer1 = Console.ReadLine();

            if (answer1 == "1")
            {
                Console.WriteLine("Vad vill du att ditt nya lösenord ska vara?");
                string newpassword = Console.ReadLine();
                string[] line2 = { $"{Login.username1} {newpassword}" };
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Elev\Documents\inlogg.txt");
                var arlist =lines.ToList();
                string[] line1 = { $"{Login.username1} {Login.password1}" };
                // "username password" --> [0]
                for (int i = 0; i < arlist.Length; i++)
                {
                    
                    var line = lines[i];
                    if (line == line1)
                    { 
                        arlist.Remove(line);

                        string[] lines3 = arlist.ToArray();

                        System.IO.File.AppendAllLines(path, lines3);
                    }
                }
            }
        }

    }
}