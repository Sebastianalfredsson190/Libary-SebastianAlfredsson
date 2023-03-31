using Libary;
using System;
using System.ComponentModel;
using System.IO;
public class Login
{
    public static string path = "C:\\Users\\Elev\\Documents\\inlogg.txt";
    public static string password1 = null;
    public static string username1 = null;
    public static void Show()
    {
        Console.Clear();
        Console.WriteLine("Var vänligen att skriva in ditt personnummer");
        string username = Console.ReadLine();
        Console.WriteLine("Skriv in ditt lösenord");
        string password  = Console.ReadLine();
        password1=password;
        username1=username;
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Elev\Documents\inlogg.txt");

        foreach (string line in lines)
        {
            var lineParts = line.Split(' ');
            var uname = lineParts[0];
            var pword = lineParts[1];

            if (uname == username && pword==password)
            { 
                Console.WriteLine("Du är nu inloggad");
                Thread.Sleep(3000);
                mainpage.Show();
                return;
            }
        }
        Console.WriteLine("Ditt inlogg är ej korrekt försök igen!");
        Thread.Sleep(3000);
        Login.Show();
        

    }
}
