using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQPretraga
{
    class Program
    {
        public class Osoba
        {
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public int Starost { get; set; }
        }

        static void Main(string[] args)
        {
            List<Osoba> osobe = new List<Osoba>
            {
                new Osoba { Ime = "Ana", Prezime = "Horvat", Starost = 25 },
                new Osoba { Ime = "Marko", Prezime = "Ivić", Starost = 30 },
                new Osoba { Ime = "Ivana", Prezime = "Kovač", Starost = 22 },
                new Osoba { Ime = "Petar", Prezime = "Novak", Starost = 28 },
                new Osoba { Ime = "Luka", Prezime = "Marić", Starost = 35 }
            };

            Console.WriteLine("Izaberite kriterij za pretragu:");
            Console.WriteLine("1. Ime");
            Console.WriteLine("2. Prezime");
            Console.WriteLine("3. Starost");
            Console.Write("Unesite broj za kriterij: ");

            int izbor = int.Parse(Console.ReadLine());

            IEnumerable<Osoba> rezultat = null;

            switch (izbor)
            {
                case 1:
                    Console.Write("Unesite ime: "); 
                    string imePretrage = Console.ReadLine(); 
                    rezultat = osobe.Where(o => o.Ime.Equals(imePretrage, StringComparison.OrdinalIgnoreCase)); 
                    break;

                case 2:
                    Console.Write("Unesite prezime: "); 
                    string prezimePretrage = Console.ReadLine(); 
                    rezultat = osobe.Where(o => o.Prezime.Equals(prezimePretrage, StringComparison.OrdinalIgnoreCase));
                    break;

                case 3:
                    Console.Write("Unesite starost: "); 
                    int starostPretrage = int.Parse(Console.ReadLine()); 
                    rezultat = osobe.Where(o => o.Starost == starostPretrage); 
                    break;

                default:
                    Console.WriteLine("Nepoznat kriterij.");
                    break;
            }

            if (rezultat != null && rezultat.Any())
            {
                Console.WriteLine("\nRezultati pretrage:");
                foreach (var osoba in rezultat)
                {
                    Console.WriteLine($"{osoba.Ime} {osoba.Prezime}, Starost: {osoba.Starost}");
                }
            }
            else
            {
                Console.WriteLine("Nema rezultata za traženi kriterij.");
            }
        }
    }
}
