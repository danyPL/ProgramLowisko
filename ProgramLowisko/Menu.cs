using ProgramLowisko.Model;
using ProgramLowisko.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramLowisko
{
    internal class Menu
    {
        bool repeat = true;
        public void ShowFishes(DataBaseManagement db)
        {
            Console.Clear();
            Console.WriteLine("Ryby:");
            db.ShowFishes();
            foreach(Ryba ryba in db.Ryby)
            {
                Console.WriteLine($"{ryba.id} | {ryba.nazwa} | {ryba.wystepowanie} | {(ryba.styl_zycia == 1 ? "drapieżne" : "spokojnego żeru")}");

            }
            Console.ReadLine();
        }
        public void ShowLowiwska(DataBaseManagement db)
        {
            Console.Clear();
            Console.WriteLine("Lowiska:");
            db.ShowLowiska();
            foreach (LowiskoEx lowisko in db.LowiskoE)
            {
                Console.WriteLine($"{lowisko.id} | {lowisko.nazwa} | {lowisko.akwen} | {lowisko.wojewodztwo} | {lowisko.rodzaj}");

            }
            Console.ReadLine();
        }
        public Menu() {
            DataBaseManagement db = new();
            while(repeat)
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Lowisko");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("1. Wyswietl wszystkie ryby");
                Console.WriteLine("2. Wyswietl wszystkie lowiska");
                Console.WriteLine("3. Dodaj nowego rybaka");
                Console.WriteLine("5. Wyjdź");

                Console.WriteLine("------------------------------------------");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        ShowFishes(db);
                        break;
                    case 2:
                        ShowLowiwska(db);
                        break;
                    case 3:

                        break;
                case 4:
                        repeat = false;
                        break;
                
                }
            }
        
        
        }
    }
}
