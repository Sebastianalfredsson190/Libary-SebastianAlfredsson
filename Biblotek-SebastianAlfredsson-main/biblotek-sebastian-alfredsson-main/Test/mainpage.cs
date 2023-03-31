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
    class mainpage
    {
        public static void Show()
        {
            Console.Clear();
            string data = File.ReadAllText(@"C:\Users\sebastian.alfredsso\Documents\Biblotek-SebastianAlfredsson-main\biblotek-sebastian-alfredsson-main\Test\users.json");
            dynamic usersData = JsonConvert.DeserializeObject<dynamic>(data);

            Console.WriteLine("Vad vill du göra?\n 1: Gå till min profil\n 2: Söka böcker \n 3: Gå till dina nuvarande böcker du lånar");

            foreach(var user in usersData){
                if(user.username == Login.username1)
                {
                    if (user.admin == true)
                    {
                        Console.WriteLine(" 4: Gå till biblotikarie inställningarna");
                        Console.WriteLine(" 5: Redigera böcker");
                    }
                }

            }


            string answer1 = Console.ReadLine();
            Console.Clear();

            if (answer1.Contains("1"))
            {
                Profil.Show();
            }
            if (answer1.Contains("2"))
            {
                SearchBook.Show();
            }
            if (answer1.Contains("3"))
            {
                MyBooks.Show();
            }
            if(answer1 == "4")
            {
                Biblotikarie.Show();
            }
            if (answer1 == "5")
            {
                AdminAddBooks.Show();
            }
        }

    }
}