using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;


namespace abookf
{
    class Program
    {
        class person
        {
            //min objekt/klass
            public string name, addres, number, email;
            public person(string n, string a, string nr, string e)
            {
                name = n; number = nr; email = e; addres = a;
            }
        }
        static void Main(string[] args)
        {
            //källa https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-read-a-text-file-in-C-Sharp/
            System.Collections.Generic.List<person> abook = new List<person>();
            string filename = @"C:\Users\Dator 15\abook.txt";

            using (StreamReader file = new StreamReader(filename))
            {
                string l;
                while ((l = file.ReadLine()) != null)
                {
                    //this is so it know where to split in the txr file
                    string[] words = l.Split('#');
                    abook.Add(new person(n: words[0], nr: words[2], e: words[3], a: words[1]));
                }
                file.Close();
            }
            
            
            bool quit = false;
            //all th code of the commands
            string command;
            do
            {
                //meny
                Console.WriteLine("__________________________");
                Console.WriteLine("|pick a number between 1-4|");
                Console.WriteLine("|type quit to end program |");
                Console.WriteLine("|                         |");
                Console.WriteLine("|1: view contactlist      |");
                Console.WriteLine("|2: add contact           |");
                Console.WriteLine("|3: remove contact        |");
                Console.WriteLine("|_________________________|");
                
                Console.Write("> ");
                command = Console.ReadLine();
                // command to quit program
                if (command == "quit")
                {
                    //when the command quit it done this msg vill show and then quit
                    Console.WriteLine("adios amigo");
                    System.Environment.Exit(0);
                    quit = true;
                }
                // view contactlist
                else if (command == "1")
                {
                    Console.WriteLine("  {0,8}   {1,8}   {2,8}   {3,8}", "name", "number", "mail", "addres");
                    for (int i = 0; i < abook.Count(); i++)
                    {
                        Console.WriteLine(" {0,8}   {1,8}   {2,8}   {3,8}", abook[i].name, abook[i].number, abook[i].email, abook[i].addres);
                    }
                }
                //add a new person 
                else if (command == "2")
                {
                    Console.WriteLine("add name");//add name
                    string name = Console.ReadLine();
                    Console.WriteLine("add number");//add nr
                    string number = Console.ReadLine();
                    Console.WriteLine("add email");//add mail
                    string email = Console.ReadLine();
                    Console.WriteLine("add addres");//add addres
                    string addres = Console.ReadLine();
                    abook.Add(new person(name, email, number, addres));

                    using (StreamWriter writer = new StreamWriter(filename))
                    for (int i = 0; i < abook.Count(); i++)
                        {
                            writer.WriteLine(abook[i].name, abook[i].number, abook[i].email, abook[i].addres);
                           
                        }
                }
                // remove person
                else if (command == "3")
                {
                    //om du skriver in namnet på personen kommer den tasbort
                    Console.Write("type the name of the pearson you want to delete: ");
                    string n = Console.ReadLine();
                    
                    for (int i = 0; i < abook.Count(); i++)
                    {
                        if (n == abook[i].name)
                        {
                            Console.WriteLine($" {n} got removed");
                            abook.RemoveAt(i);
                        }
                    }
                    
                }



            } while (!quit);
        }

    }
}
