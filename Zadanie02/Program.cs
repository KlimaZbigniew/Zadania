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

            char wybor;
            
            
            do
            {
                Console.Clear();
                Console.WriteLine("Wybierz zadanie");
                Console.WriteLine("1. Kalkulator");
                Console.WriteLine("2. System rezerwacji");
                Console.WriteLine("\n ESC - wyjście");

                wybor = Console.ReadKey().KeyChar;
                switch (wybor)
                {
                    case '1' :
                        Kalkulator();
                        break;
                    case  '2' :  
                          Rezerwacja();
                        break;
                default:
                        break;
                }
                                                
            } while (wybor != (byte)ConsoleKey.Escape);

        }

        private static void Kalkulator()
        {
            double zmienna_1 = 0.00, zmienna_2= 0.00, wynik = 0.00;
            string zmienna_1_str = "";
            char dzialanie;

            Console.Clear();
            Console.WriteLine("Witam w kalkulatorze: ZK 1.0");

            if (!Pobierz_z_konsoli("Podaj pierwszą liczbę: ", out zmienna_1))
                return;

            Console.Write("\nPodaj co robimy [+|-|/|*]: ");
            do {
                dzialanie = Console.ReadKey(true).KeyChar;
            } while (!"+-/*".Contains(dzialanie));
            
            Console.WriteLine(dzialanie);

            if (!Pobierz_z_konsoli("Podaj drugą liczbę: ", out zmienna_2))
                return;

            switch (dzialanie)
            {
                
                case '+': wynik = zmienna_1 + zmienna_2; break;
                case '-': wynik = zmienna_1 - zmienna_2; break;
                case '*': wynik = zmienna_1 * zmienna_2; break;
                case '/': wynik = (zmienna_2 != 0) ?  zmienna_1 / zmienna_2:  0; break;
                default:
                    break;
            }

            if (dzialanie == '/' && zmienna_2 == 0)
                Console.WriteLine("!!! Nie dzielimy przez zero !!!");
            else
                Console.WriteLine("\n\nObliczyłem: {0} {1} {2} = {3}", zmienna_1, dzialanie, zmienna_2, wynik);

            Console.WriteLine("Naciśnij dowolny klawisz aby zamknąć...");
            Console.ReadKey();
        }

        private static bool Pobierz_z_konsoli(string opis, out double liczba)
        {            
            Char znak;
            string liczba_str = "";
            bool result;

            Console.Write(opis);
            liczba = 0;
            
            do
            {
                znak = Console.ReadKey(true).KeyChar;

                if (znak == (char)ConsoleKey.Escape)
                    return false;

                if (znak == (Char)ConsoleKey.Enter &&  (liczba_str.Length) > 0)
                    break;                                    

                if ("1234567890.,".Contains(znak))
                {
                    liczba_str += znak;
                    Console.Write(znak);
                }
                else
                    Console.Beep();

                        //Console.ReadKey().Key != ConsoleKey.Escape
            } while (true);
            
            liczba = Convert.ToDouble(liczba_str.Replace(".", ","));
            return true;            
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

            Console.Clear();
            Console.WriteLine("                                System rezerwacji ZK v.1.0\n");
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

            Console.WriteLine("\n\nNaciśnij dowolny klawisz aby zamknąć...");
            Console.ReadKey();


        }
    }
}
