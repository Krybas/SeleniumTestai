using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTestai;
using SeleniumTestai.testai;
using System;
using System.Reflection;
using System.Threading;

namespace Terminalas
{
    class Program
    {
        static void Main(string[] args)
        {
            Functions funkcijos = new Functions();
            DarbuotojoPridejimas Pirmas_testas = new DarbuotojoPridejimas();
            DarbuotojoPakeitimai Antras_testas = new DarbuotojoPakeitimai();
            KandidatoPridėjimas Trecias_testas = new KandidatoPridėjimas();
            BuzzFeed Ketvirtas_testas = new BuzzFeed();
            NaujaAtaskaita Penktas_testas = new NaujaAtaskaita();
            string? userURL = null;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nPasirinkite testą:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1 - Pridėti naują darbuotoją ir atlikti paiešką");
                Console.WriteLine("2 - Sukurto darbuotojo asmeninių duomenų pakeitimai");
                Console.WriteLine("3 - Pridėti i darbą naują kandidatą");
                Console.WriteLine("4 - Pranešimai 'BuzzFeed'");
                Console.WriteLine("5 - Naujos ataskaitos kūrimas");
                Console.WriteLine("9 - Išvalyti terminalą");
                Console.WriteLine("0 - Išeiti");
                Console.Write("Įveskite savo pasirinkimą: ");

                string pasirinkimas = Console.ReadLine() ?? " ";

                switch (pasirinkimas)
                {
                    case "1":
                        userURL = Pirmas_testas.DarbuotojoPridėjimoTestas();
                        break;
                    case "2":
                        funkcijos.ExecuteTestIfUserExists(userURL, Antras_testas.DarbuotojoPakeitimoTestas);
                        break;
                    case "3":
                        funkcijos.ExecuteTestIfUserExists(userURL, Trecias_testas.KandidatoPridejimoTestas);
                        break;
                    case "4":
                        Ketvirtas_testas.BuzzFeedTestai();
                        break;
                    case "5":
                        Penktas_testas.NaujaAtaskaitaTestas();
                        break;
                    case "9":
                        Console.Clear();
                        break;
                    case "0":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nNeteisingas pasirinkimas. Bandykite dar kartą.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }
    }
}