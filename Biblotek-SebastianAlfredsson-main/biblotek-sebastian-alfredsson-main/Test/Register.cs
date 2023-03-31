using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Libary
{
    public class Register
    {
        // C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\books.json
        static string path = "C:\\Users\\sebastian.alfredsso\\Documents\\inlogg.txt";
        public static void Show()
        {
            string data = File.ReadAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json");
            dynamic usersData = JsonConvert.DeserializeObject<dynamic>(data);

            Console.Clear();

            Console.WriteLine("Välkommen till bibloteket\n \nHörde att du ville skapa ett konto! Var vänlig att skriv in ditt personnummer");
            string username = Console.ReadLine();
            Console.WriteLine("Nu behöver vi ett lösenord också!");
            string password = Console.ReadLine();
            Console.WriteLine("Skriv in din mail");
            string mail = Console.ReadLine();
            Console.WriteLine("Skriv in ditt telefon nummer");
            string number = Console.ReadLine();

            string[] lines = { $"{username} {password}" };

            System.IO.File.AppendAllLines(path, lines);

            List<string> borrowing = new List<string>();

            List<string> reserved = new List<string>();


            bool admin = false;

            int LastIndex = 0;

            var i = 0;

            foreach (var user2 in usersData)
            {

                i++;

                LastIndex = i;
            }

            // id är 1 just nu
            string id = "";
            id = LastIndex.ToString();

            User user = new User(username, id, borrowing, reserved, password, number, mail, admin);

            usersData.Add(JToken.FromObject(user));

            string dataToSave = JsonConvert.SerializeObject(usersData);
            File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json", dataToSave);



            Console.WriteLine("Nu är ditt konto skapat, vi skickar dig till inloggsidan så får du testa ditt inlogg!");

            Thread.Sleep(3000);

            Login.Show();
        }
    }    
}
