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
    class MyBooks
    {
        public static void Show()
        {
            Console.Clear();
            Console.WriteLine("Böcker du lånar just nu är: ");

            string data = File.ReadAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json");
            dynamic usersData = JsonConvert.DeserializeObject<dynamic>(data);
            string data2 = File.ReadAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\books.json");
            dynamic bookData = JsonConvert.DeserializeObject<dynamic>(data2);

            foreach (var user in usersData)
            {
                if (user.username == Login.username1)
                {
                    Console.WriteLine(user.borrowing);
                    Console.WriteLine("Reserverade böcker: ");
                    Console.WriteLine(user.reserved);
                    Console.WriteLine("\nVill du lämna tillbaka en lånad bok skriv (1) \nVill du gå till huvudmenyn skriv (2)");
                    string answer1 = Console.ReadLine();
                    if (answer1 == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("Skriv numret av boken du vill lämna tillbaka \n");

                        

                        for( var i = 0; i < user.borrowing.Count; i++)
                        {
                            int number = i + 1;
                            Console.WriteLine(number + ":");
                            Console.WriteLine(user.borrowing[i]);
                        }
                        string answer2 = Console.ReadLine();
                        int number1 = int.Parse(answer2);
                        int number2 = number1 - 1;
                        

                        for ( var i = 0; i < user.borrowing.Count; i++)
                        {
                            if (number2 == i) {
                                foreach(var book in bookData)
                                {
                                    if (book.name == user.borrowing[i])
                                    {
                                        book.stock = book.stock + 1;
                                    }
                                }
                                user.borrowing.RemoveAt(i);
                            }       
                        }
                        string dataToSave = JsonConvert.SerializeObject(usersData);
                        File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json", dataToSave);
                        string dataToSave2 = JsonConvert.SerializeObject(bookData);
                        File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\books.json", dataToSave2);
                        Console.WriteLine("Boken är tillbaka lämnad och vi skickar dig till huvudmenyn igen!");
                        Thread.Sleep(3000);
                        mainpage.Show();

                    }
                    if (answer1 == "2")
                    {
                        mainpage.Show();
                    }

                }
            }
        }
    }
}