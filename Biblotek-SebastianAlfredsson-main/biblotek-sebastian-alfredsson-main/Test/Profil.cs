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
    class Profil
    {
        static string path = "C:\\Users\\sebastian.alfredsso\\Documents\\inlogg.txt";




        public static List<string> ArrayToList(string[] arr)
        {
            List<string> list = new List<string>();
            list.AddRange(arr);

            return list;
        }

        public static void Show()
        {
            string data = File.ReadAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json");
            dynamic usersData = JsonConvert.DeserializeObject<dynamic>(data);
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
                var newinlogg = line2[0];
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\sebastian.alfredsso\Documents\inlogg.txt");
                var arlist = ArrayToList(lines);
                string line1 = $"{Login.username1} {Login.password1}";

                for (int i = 0; i < arlist.Count; i++)
                {
                    var line = lines[i];
                    if (line == line1)
                    { 
                        arlist.Remove(line);
                        arlist.Add(newinlogg);



                        string[] lines3 = arlist.ToArray();

                        System.IO.File.Delete(path);

                        System.IO.File.AppendAllLines(path, lines3);

                    }
                }
            }

            if(answer1== "2")
            {
                Console.WriteLine("Skriv in din mail");
                string mail = Console.ReadLine();
                Console.WriteLine("Skriv in ditt nummer");
                string number = Console.ReadLine();
                foreach(var user in usersData)
                {
                    if (user.username == Login.username1) 
                    {
                        user.admin = true;
                        user.mail = number;
                        user.number = mail;
                    }
                }
                string dataToSave = JsonConvert.SerializeObject(usersData);
                File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json", dataToSave);
                mainpage.Show();

            }

            if(answer1 == "3")
            {
                mainpage.Show();
            }
        }

    }
}