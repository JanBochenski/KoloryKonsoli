using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace KoloryKonsoli
{
    internal class Kolor
    {
        private ConsoleColor naszKolor;
        private int? naszRodzaj = 0;

        public Kolor(string name,int? rodzaj)
        {
            rodzaj = ((rodzaj==null)?0:rodzaj);
            this.naszRodzaj = rodzaj;
            this.ZmienKolor(name);
        }
        public ConsoleColor DajKolor()
        {
            return this.naszKolor;
        }

        public void ZmienKolor(string name)
        {
            int indeks;
            bool jestWynik = false;
            ConsoleColor staryKolorKonsoli;
            string[] kolory = {"czarny","ciemnoniebieski","ciemnozielony","ciemnoturkusowy","ciemnoczerwony","filoletowy","ciemnożółty","szary","ciemnoszary","niebieski","zielony","turkusowy","czerwony","różowy","żółty","biały" };
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            if (!String.IsNullOrWhiteSpace(name))
            {
                name = name.ToLower();
                foreach (var color in colors)
                {
                    if (name == color.ToString().ToLower())
                    {
                        this.naszKolor = color;
                        jestWynik = true;
                    }
                }
                int i = 0;

                // długość tablicy kolory i colors identyczna

                foreach (var kolor in kolory)
                {
                    if (name == kolor.ToLower())
                    {
                        this.naszKolor = colors[i];
                        jestWynik = true;
                    }
                    i++;
                }
                if (!jestWynik && Char.IsNumber(name, 0))
                {
                    indeks = Convert.ToUInt16(name);
                    if (0 <= indeks && indeks <= colors.Length - 1)
                        this.naszKolor = colors[indeks];
                    jestWynik = true;
                }
                if (!jestWynik)
                {
                    Console.WriteLine("Możliwe kolory:");
                    i = 0;
                    foreach (var color in colors)
                    {
                        Console.ForegroundColor = color;
                        staryKolorKonsoli = Console.BackgroundColor;
                        if (Console.ForegroundColor == Console.BackgroundColor)
                        {            
                            Console.BackgroundColor = ((i==0)?colors[colors.Length-1]:colors[i-1]);
                        }
                        Console.WriteLine(color.ToString() + "(" + kolory[i] + ")");
                        Console.BackgroundColor = staryKolorKonsoli;
                        i++;
                    }
                    Console.ResetColor();
                    if (this.naszRodzaj == 0)
                        this.naszKolor = Console.ForegroundColor;
                    else
                        this.naszKolor = Console.BackgroundColor;
                }
            }
            else
            {
                Console.ResetColor();
                if (this.naszRodzaj == 0)
                    this.naszKolor = Console.ForegroundColor;
                else
                    this.naszKolor = Console.BackgroundColor;
            }
        }
    }
}

