using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KoloryKonsoli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string kolorTekstu="", kolorTla="";
            Kolor kolor1 = new Kolor(Console.ForegroundColor.ToString(), 0);
            Kolor kolor2 = new Kolor(Console.BackgroundColor.ToString(), 1);
            while (true)
            {
                Console.Write("Podaj proszę kolor tekstu: ");
                kolorTekstu = Console.ReadLine();
                kolor1.ZmienKolor(kolorTekstu);
                Console.Write("Podaj proszę kolor tła: ");
                kolorTla = Console.ReadLine();
                kolor2.ZmienKolor(kolorTla);

                Console.ForegroundColor = kolor1.DajKolor();
                Console.BackgroundColor = kolor2.DajKolor();

                Console.WriteLine("Wybrałeś Kolor tekstu: " + kolorTekstu);
                Console.WriteLine("Wybrałeś Kolor tła: " + kolorTla);
                Console.WriteLine("Proszę napisz coś, zakończ klawiszem <Enter>");
                Console.ReadLine();
            }

        }
    }
}
