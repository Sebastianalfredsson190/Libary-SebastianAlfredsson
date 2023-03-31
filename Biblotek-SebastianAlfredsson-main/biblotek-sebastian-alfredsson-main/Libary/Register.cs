using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libary
{
    public class Register
    {
        static string path = "C:\\Users\\Elev\\Documents\\inlogg.txt";
        public static void Show()
        {
            Console.Clear();

            Console.WriteLine("Välkommen till bibloteket\n \nHörde att du ville skapa ett konto! Var vänlig att skriv in ditt personnummer");
            string username = Console.ReadLine();
            Console.WriteLine("Nu behöver vi ett lösenord också!");
            string password = Console.ReadLine();

            string[] lines = { $"{username} {password}" };

            System.IO.File.AppendAllLines(path, lines);

            Console.WriteLine("Nu är ditt konto skapat, vi skickar dig till inloggsidan så får du testa ditt inlogg!");

            Thread.Sleep(3000);

            Login.Show();
        }
    }   
}
