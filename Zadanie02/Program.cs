using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Console.Clear();
                Rezerwacja();
                Console.WriteLine("ESC - Zakończ, inny klawisz ponowna kalkulacja.....");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

        }

        private static void Rezerwacja()
        {
            int wiek = 0;
            int ilosc_nocy = 0;
            double cena_do_18 = 140.00;
            double cena_std = 200.00;
            double cena_promo_01 = 180.00;
            double cena_promo_02 = 150.00;
            double rabat_65 = 10.00;

            double wartosc = 0.00;
            double stawka = 0.00;

            Console.WriteLine("System rezerwacji (ZK v.1.0)");
            Console.WriteLine("Osoby poniżej 18lat: {0}", cena_do_18);
            Console.WriteLine("Osoby dorosłe:\n  - jedna noc: {0}", cena_std);
            Console.WriteLine("  - dwie, trzy, cztery noce: {0}", cena_promo_01);
            Console.WriteLine("  - pięć i więcej: {0}: ", cena_promo_02);
            Console.WriteLine("Seniorzy: rabat: {0}% \n\n", rabat_65);

            Console.Write("Podaj wiek: ");
            wiek = Convert.ToInt32(Console.ReadLine());
            Console.Write("Podaj ilosć nocy: ");
            ilosc_nocy = Convert.ToInt32(Console.ReadLine());

            if (wiek < 18)
                stawka = cena_do_18;
            else
            {
                if (ilosc_nocy == 1)
                    stawka = cena_std;
                else if (ilosc_nocy >= 5)
                    stawka = cena_promo_02;
                else stawka = cena_promo_01;
            }

            wartosc = stawka * ilosc_nocy;

            wartosc = wiek >= 65 ? wartosc * ((100 - rabat_65) / 100) : wartosc;

            Console.WriteLine("Koszt rezerwacji: {0}\n\n    ZAPRASZAMY", wartosc);

        }
    }
}
