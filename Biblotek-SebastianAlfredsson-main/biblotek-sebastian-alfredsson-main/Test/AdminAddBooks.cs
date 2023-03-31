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
    class AdminAddBooks
    {
        public static void Show()
        {
            string data2 = File.ReadAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\books.json");
            dynamic bookData = JsonConvert.DeserializeObject<dynamic>(data2);

            Console.WriteLine("Vill du: \n (1) Lägga till en bok\n (2) Ta bort en bok\n (3) Redigera en bok");
            string answer = Console.ReadLine();

            if (answer == "1")
            {
                Console.Write("Enter title: ");
                string title = Console.ReadLine();

                Console.Write("Enter Author: ");
                string author = Console.ReadLine();

                Console.Write("Enter realease date: ");
                string year = Console.ReadLine();

                Console.Write("Enter isbn: ");
                string isbn = Console.ReadLine();

                Console.WriteLine("Skriv hur många vi har i lagret");
                string stock1 = Console.ReadLine();
                int stock = int.Parse(stock1);

                int lastIndex = 0;

                foreach(var book in bookData) {
                    var i = 0;
                    i++;

                    lastIndex = i;
                }
                string number = lastIndex.ToString();

                Book newbook = new Book(title, author, year, isbn, stock, number);

                bookData.Add(JToken.FromObject(newbook));

                string dataToSave2 = JsonConvert.SerializeObject(bookData);
                File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\books.json", dataToSave2);


            }
            if (answer == "2")
            {
                Console.Clear();
                Console.WriteLine("Vilken bok vill du ta bort. Var vänlig och skriv in book numret");

                int i = 0;
                

                foreach (var book in bookData)
                {
                    i++;
                    Console.WriteLine(" ");
                    Console.WriteLine(i + ":");
                    Console.WriteLine("Title: " + book.name);
                    Console.WriteLine("Author: " + book.author);
                    Console.WriteLine("Year Realease date : " + book.year);
                    Console.WriteLine(" ");

                }
                string answer1 = Console.ReadLine();
                int number2 = int.Parse(answer1);

                int b = bookData.Count;

                //for (int i1 = b - 1; i1 >= 0; i1--)
                for (int index = 0; index < b; index++)
                {
                    if (bookData[index].number == number2)
                    {
                        bookData.RemoveAt(index);
                        break;
                    }
                }

                string dataToSave2 = JsonConvert.SerializeObject(bookData);
                File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\books.json", dataToSave2);
                mainpage.Show();
            }
            if (answer == "3")
            {
                Console.WriteLine("Välj vilken bok du vill redigera information hos. Var vänlig och skriv in boknumret");
              
               
                int i = 0; 
                
                foreach (var book in bookData)
                {
                    i++;
                    Console.WriteLine(" ");
                    Console.WriteLine(i + ":");
                    Console.WriteLine("Title: " + book.name);
                    Console.WriteLine("Author: " + book.author);
                    Console.WriteLine("Year Realease date : " + book.year);
                    Console.WriteLine(" ");

                }

                string answer1 = Console.ReadLine();

                foreach (var book in bookData)
                {
                    if(book.number == answer1)
                    {
                        Console.WriteLine("Vilken information vill du redigera?");
                        Console.WriteLine("(1) Title: " + book.name);
                        Console.WriteLine("(2) Author: " + book.author);
                        Console.WriteLine("(3) Year Realease date : " + book.year);
                    }

                    string answer2 = Console.ReadLine();

                    if (answer2 == "1")
                    {
                        Console.WriteLine("Vad vill du att mailet ska vara?");
                        string answer3 = Console.ReadLine();
                        book.name = answer3;
                        string dataToSave2 = JsonConvert.SerializeObject(bookData);
                        File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\books.json", dataToSave2);
                    }
                    if (answer2 == "2")
                    {
                        Console.WriteLine("Vad ska författarens namn vara?");
                        string answer3 = Console.ReadLine();
                        book.author = answer3;
                        string dataToSave2 = JsonConvert.SerializeObject(bookData);
                        File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\books.json", dataToSave2);
                    }
                    if (answer2 == "3")
                    {
                        Console.WriteLine("Vad vill du att realease datet ska vara?");
                        string answer3 = Console.ReadLine();
                        book.year = answer3;
                        string dataToSave2 = JsonConvert.SerializeObject(bookData);
                        File.WriteAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\books.jsonn", dataToSave2);
                    }
                }
            }
        }
    }
}
