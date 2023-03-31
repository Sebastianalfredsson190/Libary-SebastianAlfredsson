using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.IO;
using System.ComponentModel;

namespace Libary
{
    class mainpage
    {
        public static void Show()
        {
            Console.Clear();
            Console.WriteLine("Du är nu inloggad! \n 1: Gå till min profil\n 2: låna böcker\n 3: Kolla vilka böcker du lånar just nu, där kan du även lämna tillbaka böcker");
            string answer1 = Console.ReadLine();

            if (answer1.Contains("1"))
            {
                Profil.Show();
            }
            if (answer1.Contains("2"))
            {
                Borrow.Show();
            }
            if (answer1.Contains("3"))
            {
                MyBooks.Show();
            }
        }

    }
}