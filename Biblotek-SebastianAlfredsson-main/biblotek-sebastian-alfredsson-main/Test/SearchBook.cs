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
    class SearchBook
    {
        static BookSystem system = BookSystem.GetInstance();


        public static void Show()
        {
            string data = File.ReadAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json");
            dynamic usersData = JsonConvert.DeserializeObject<dynamic>(data);
            string data2 = File.ReadAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\books.json");
            dynamic bookData = JsonConvert.DeserializeObject<dynamic>(data2);

            Console.Clear();
            Console.WriteLine("Skriv in bokens title, författare eller isbn för hitta din favorit bok");
            string answer = Console.ReadLine();

            Console.WriteLine($"Sök efter en book: {answer}\n");

            var result = system.FindBook(answer);

            for (var i = 0; i < result.Count; i++)
            {
                var book = result[i];
                Console.WriteLine($"Title: {book.name}");
                Console.WriteLine($"Author: {book.author}");
                Console.WriteLine($"Year:{book.year}");
                Console.WriteLine($"Isbn: {book.isbn}");
                Console.WriteLine($"BokNummer: {book.number }");
                Console.WriteLine($"Stock: {book.stock}\n");
            }
            Console.WriteLine("Vill du låna eller reserva en bok skriv in boknumret som står på din bok");
            string answer1 = Console.ReadLine();
            Console.WriteLine("Boken kommer reserveras om den ej finns i lager");


            if (answer1 == "1")
            {   
                foreach(var book in bookData) { 
                if (book.stock > 0 && book.name == "The Hunger Games") { 
                foreach (var user in usersData)
                {
                    if(user.username == Login.username1)
                    {

                        user.borrowing.Add(JToken.FromObject("The Hunger Games"));
                        foreach(var b in bookData)
                        {
                            if (b.name == "The Hunger Games") 
                            {
                                int number = b.stock - 1;
                                b.stock = JToken.FromObject(number);
                            }
                        }


                    }
                    }
                }
                string dataToSave = JsonConvert.SerializeObject(usersData);
                File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json", dataToSave);
                string dataToSave2 = JsonConvert.SerializeObject(bookData);
                File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\books.json", dataToSave2);
                }
                foreach (var book in bookData)
                {
                    if (book.stock == 0 && book.name == "The Hunger Games")
                    {
                        foreach (var user in usersData)
                        {
                            if (user.username == Login.username1)
                            {
                                Console.WriteLine("Boken finns ej i lager så vi reserverar den för dig");
                                Thread.Sleep(3000);
                                user.reserved.Add(JToken.FromObject("The Hunger Games"));

                                foreach (var b in bookData)
                                {
                                    if (b.name == "The Hunger Games")
                                    {
                                        int number = b.number - 1;
                                        b.stock = JToken.FromObject(number);
                                    }
                                }


                            }
                        }
                    }
                    string dataToSave = JsonConvert.SerializeObject(usersData);
                    File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json", dataToSave);
                    string dataToSave2 = JsonConvert.SerializeObject(bookData);
                    File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\books.json", dataToSave2);
                }
            }
            if (answer1 == "2")
            {
                foreach (var book in bookData)
                {
                    if (book.stock > 0 && book.name == "Den odoliga Henrietta Lacks")
                    {
                        foreach (var user in usersData)
                        {
                            if (user.username == Login.username1)
                            {

                                user.borrowing.Add(JToken.FromObject("Den ododliga Henrietta Lacks"));
                                foreach (var b in bookData)
                                {
                                    if (b.name == "Den ododliga Henrietta Lacks")
                                    {
                                        int number = b.stock - 1;
                                        b.stock = JToken.FromObject(number);
                                    }
                                }


                            }
                        }
                    }
                    string dataToSave = JsonConvert.SerializeObject(usersData);
                    File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json", dataToSave);
                    string dataToSave2 = JsonConvert.SerializeObject(bookData);
                    File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\books.json", dataToSave2);
                }
                foreach (var book in bookData)
                {
                    if (book.stock == 0 && book.name == "Den odoliga Henrietta Lacks")
                    {
                        foreach (var user in usersData)
                        {
                            if (user.username == Login.username1)
                            {
                                Console.WriteLine("Boken finns ej i lager så vi reserverar den för dig");
                                Thread.Sleep(3000);
                                user.reserved.Add(JToken.FromObject("Den ododliga Henrietta Lacks"));
                                foreach (var b in bookData)
                                {
                                    if (b.name == "Den ododliga Henrietta Lacks")
                                    {
                                        int number = b.number - 1;
                                        b.stock = JToken.FromObject(number);
                                    }
                                }


                            }
                        }
                    }
                    string dataToSave = JsonConvert.SerializeObject(usersData);
                    File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json", dataToSave);
                    string dataToSave2 = JsonConvert.SerializeObject(bookData);
                    File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\books.json", dataToSave2);
                }
            }
            if (answer1 == "3")
            {
                foreach (var book in bookData)
                {
                    if (book.stock > 0 && book.name == "True History of the kelly Gang")
                    {
                        foreach (var user in usersData)
                        {
                            if (user.username == Login.username1)
                            {

                                user.borrowing.Add(JToken.FromObject("True History of the kelly Gang"));
                                foreach (var b in bookData)
                                {
                                    if (b.name == "True History of the kelly Gang")
                                    {
                                        int number = b.stock - 1;
                                        b.stock = JToken.FromObject(number);
                                    }
                                }


                            }
                        }
                    }
                    string dataToSave = JsonConvert.SerializeObject(usersData);
                    File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json", dataToSave);
                    string dataToSave2 = JsonConvert.SerializeObject(bookData);
                    File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\books.json", dataToSave2);
                }
                foreach (var book in bookData)
                {
                    if (book.stock == 0 && book.name == "True History of the kelly Gang")
                    {
                        foreach (var user in usersData)
                        {
                            if (user.username == Login.username1)
                            {
                                Console.WriteLine("Boken finns ej i lager så vi reserverar den för dig");
                                Thread.Sleep(3000);
                                user.reserved.Add(JToken.FromObject("True History of the kelly Gang"));
                                foreach (var b in bookData)
                                {
                                    if (b.name = "True History of the kelly Gang")
                                    {
                                        int number = b.number - 1;
                                        b.stock = JToken.FromObject(number);
                                    }
                                }


                            }
                        }
                    }
                    string dataToSave = JsonConvert.SerializeObject(usersData);
                    File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json", dataToSave);
                    string dataToSave2 = JsonConvert.SerializeObject(bookData);
                    File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\books.json", dataToSave2);
                }
            }
            Console.WriteLine("Du har lagt till boken vi skickar dig till huvudmenyn!");
            Thread.Sleep(3000);
            mainpage.Show();
            
        }
    } 
}
