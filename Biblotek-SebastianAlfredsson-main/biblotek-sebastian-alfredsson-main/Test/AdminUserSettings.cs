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
    class Biblotikarie
    {
        public static void Show()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\sebastian.alfredsso\Documents\inlogg.txt");
            string data = File.ReadAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json");
            dynamic usersData = JsonConvert.DeserializeObject<dynamic>(data);
            Console.WriteLine("Hej! Du har tre alternativ här du kan\n 1: Redigera en användare eller ta bort\n 2: Lista alla användare\n 3: Lägga till en användare");
            string answer = Console.ReadLine();
            Console.Clear();
            if(answer == "1")
            {
                var i = 0;
                foreach(var user in usersData){
                    Console.WriteLine("Id: " + user.id);
                    Console.WriteLine("Användarnamn: " + user.username);
                    Console.WriteLine("Mail: " + user.mail);
                    Console.WriteLine("Telefonummer: " + user.number);
                    Console.WriteLine("Admin: " + user.admin);
                    Console.WriteLine(" ");
                }
                Console.WriteLine("Skriv in idet på användaren som du vill redigera eller ta bort användaren.");
                
                string answer1 = Console.ReadLine();
                int number2 = int.Parse(answer1);

                Console.Clear();


                for (int i2 = 0; i < usersData.Count; i++)
                    {
                        var user = usersData[i];
                        if (user.id == number2)
                        {
                            int k = 0;

                            k = k + 1;
                            Console.WriteLine(k + ": Vill du redigera användaren");
                            k = k + 1;
                            Console.WriteLine(k + ": Vill du ta bort användaren");
                            string answer3 = Console.ReadLine();
                            Console.Clear();

                            if (answer3 == "1")
                            {
                                int number3 = 1;
                                Console.WriteLine("Vad vill du redigera? Skriv in numret på den information du vill ändra");
                                Console.WriteLine(number3 + ": Användarnamn: " + user.username);
                                number3 = number3 + 1;
                                Console.WriteLine(number3 + ": Mail: " + user.mail);
                                number3 = number3 + 1;
                                Console.WriteLine(number3 + ": Telefonummer: " + user.number);
                                number3 = number3 + 1;
                                Console.WriteLine(number3 + ": Admin: " + user.admin);
                                Console.WriteLine(" ");
                                string answer4 = Console.ReadLine();
                                Console.Clear();
                                if(answer4== "1")
                                {
                                    Console.WriteLine("Vad vill du att användarnamnet ska vara");
                                    string answer5 = Console.ReadLine();
                                    user.username = answer5;
                                    string dataToSave = JsonConvert.SerializeObject(usersData);
                                    File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json", dataToSave);

                                }
                                if (answer4 == "2")
                                {
                                    Console.WriteLine("Vad vill du att mailet ska vara");
                                    string answer5 = Console.ReadLine();
                                    user.mail = answer5;
                                    string dataToSave = JsonConvert.SerializeObject(usersData);
                                    File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json", dataToSave);
                                }
                                if (answer4 == "3")
                                {
                                    Console.WriteLine("Vad vill du att telefonnumret ska vara");
                                    string answer5 = Console.ReadLine();
                                    user.number = answer5;
                                    string dataToSave = JsonConvert.SerializeObject(usersData);
                                    File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json", dataToSave);
                                }
                                if (answer4 == "4")
                                {
                                    Console.WriteLine("Vill du ge behörighet till biblotikarie för detta konto\n (1) Ja\n (2) Nej");
                                    string answer5 = Console.ReadLine();
                                    if(answer5 == "1")
                                    {
                                        user.admin = true;
                                        string dataToSave = JsonConvert.SerializeObject(usersData);
                                        File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json", dataToSave);
                                    }
                                    if (answer5 == "2")
                                    {
                                        user.admin = false;
                                        string dataToSave = JsonConvert.SerializeObject(usersData);
                                        File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json", dataToSave);
                                    }

                            }
                            }
                        if (answer3 == "2")
                        {
                            for (int i1 = usersData.Count - 1; i1 >= 0; i1--)
                            {
                                if (usersData[i1].id == number2)
                                {
                                    usersData.RemoveAt(i1);
                                }
                            }

                            string dataToSave = JsonConvert.SerializeObject(usersData);
                            File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json", dataToSave);
                        }
                    }
                    }

            }
            if (answer == "2")
            {
                Console.WriteLine("Alla användare signar till denna applikation är: ");

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }

                }
         
            if (answer == "3")
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();

                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                Console.Write("Enter mail: ");
                string mail = Console.ReadLine();

                Console.Write("Enter number: ");
                string number = Console.ReadLine();

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


                string id = "";
                id = LastIndex.ToString();

                User user = new User(username, id, borrowing, reserved,password, number,mail, admin);

                usersData.Add(JToken.FromObject(user));

                string dataToSave = JsonConvert.SerializeObject(usersData);
                File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json", dataToSave);
                Console.WriteLine("Ditt konto skapades vi skickar dig till huvudmenyn igen");
                mainpage.Show();
            }
        }
    }
}
