using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie02;

namespace Zadania
{
    class Pesel
    {
        public string pesel;
        public DateTime data_ur;
        public string plec;
    }
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
                Console.WriteLine("3. Test liczby pierwszej");
                Console.WriteLine("4. Employee class");
                Console.WriteLine("5. Zamiana liczb arabskich na rzymskie i odwrotnie");
                Console.WriteLine("6. PESEL weryfikator");
                Console.WriteLine("7. Wyznacz Wielkanoc");
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
                    case '3':
                        Liczba_pierwsza();
                        break;
                    case '4' :
                        PracownikClass();
                        break;
                    case '5':
                        Konwertyj_liczby();
                        break;
                    case '6':
                        PESEL();
                        break;                        
                    case '7':
                        Wielkanoc();
                        break;
                default:
                        break;
                }
                                                
            } while (wybor != (byte)ConsoleKey.Escape);

        }

        private static void Konwertyj_liczby()
        {
            int n;
            double liczba;
            string liczba_rzymska;

            Console.Clear();
            Console.WriteLine("Konwertuj liczby: ZK 1.0");
            Console.WriteLine();

            if (!Pobierz_z_konsoli("Podaj liczbę arabską z zakresu 1-3999: ", out liczba))
                return;
            Console.WriteLine();
            n = (int)liczba;
            liczba_rzymska = ArabskieNaRzymskie(n);

            Console.WriteLine("Odpowiednik rzymski: {0}", liczba_rzymska);
            Console.Write("\nPodaj liczbę rzymską: ");

            liczba_rzymska =  Console.ReadLine();

            n = ArabskieNaRzymskie(liczba_rzymska);

            Console.WriteLine("Odpowiednik arabski: {0}", n);
            Console.WriteLine("Naciśnij dowolny klawisz aby zamknąć...");
            Console.ReadKey();
        }

        private static int ArabskieNaRzymskie(string liczba_rzymska)
        {
            int n = 0;
            int[] arabskie = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            String[] rzymskie = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            while (liczba_rzymska.Length > 0)
            {
                for (int i = 0; i < arabskie.Length -1; i++)
                {
                    while (liczba_rzymska.Substring(0, rzymskie[i].Length > liczba_rzymska.Length? 1:rzymskie[i].Length) == rzymskie[i])
                    {
                        n += arabskie[i];
                        liczba_rzymska = liczba_rzymska.Substring(rzymskie[i].Length);
                    }

                }
            }

            return n;
        }

        private static string ArabskieNaRzymskie(int liczba)
        {
            string liczba_rzymska = "";
            int kk = 0;
            kk = liczba;
            //TODO: tablica wielowymiarowa?? z różnych typów.
            int[] arabskie = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            String[] rzymskie = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            if (liczba < 1 || liczba > 3999)
            {
                Console.WriteLine("Liczna jest z poza zakresu: 1-3999");
                return "";
            }


            
            
                for (int i = 0; i < arabskie.Length - 1; i++)
                {
                    while (kk >= arabskie[i]) 
                    {
                        liczba_rzymska += rzymskie[i];
                        kk -= arabskie[i];
                    }
                }

            


            return liczba_rzymska;
        }

        private static void Wielkanoc()
        {
            int rok;
            double liczba;
            DateTime data;

            Console.Clear();
            Console.WriteLine("wyznaczenie daty Wielkanocy: ZK 1.0");

            if (!Pobierz_z_konsoli("Podaj rok: ", out liczba))
                return;
            Console.WriteLine();

            rok = (int)liczba;

            data = Podaj_Wielkanoc(rok);

            Console.WriteLine("Data Wielkanocy to: {0}", data.ToString());
            Console.WriteLine("Naciśnij dowolny klawisz aby zamknąć...");
            Console.ReadKey();

            
        }

        private static DateTime Podaj_Wielkanoc(int rok)
        {
            int a, b, c, d, e, f, g, h, i, k, l, m, p;
            int dzien, miesiac;

            //Dzielimy liczbę roku na 19 i wyznaczamy resztę a.
            a = rok % 19;
            //Dzielimy liczbę roku przez 100, wynik zaokrąglamy w dół(odcinamy część ułamkową) i otrzymujemy liczbę b.
            b = (int)(rok / 100);
            //Dzielimy liczbę roku przez 100 i otrzymujemy resztę c.
            c = rok % 100;
            //Liczymy: b: 4 i wynik zaokrąglamy w dół i otrzymujemy liczbę d.
            d = (int)b / 4;
            //Liczymy: b: 4 i wyznaczamy resztę e.
            e = b % 4;
            //Liczymy: (b + 8) : 25 i wynik zaokrąglamy w dół i otrzymujemy liczbę f.
            f = (int)((b + 8) / 25);
            //Liczymy: (b – f + 1) : 3 i wynik zaokrąglamy w dół i otrzymujemy liczbę g.
            g = (b - f + 1) / 3;
            //Liczymy: (19 × a + b – d – g + 15) : 30 i wyznaczamy resztę h.
            h = (19 * a + b - d - g + 15) % 30;
            ///Liczymy: c: 4 i wynik zaokrąglamy w dół i otrzymujemy cyfrę i.
            i = (int)(c / 4);
            //Liczymy: c: 4 i wyznaczamy resztę k.
            k = c % 4;
            //Liczymy: (32 + 2 × e + 2 × i – h – k) : 7 i otrzymujemy resztę l.
            l = (32 + 2 * e + 2 * i - h - k) % 7;
            //Liczymy: (a + 11 × h + 22 × l) : 451 i wynik zaokrąglamy w dół i otrzymujemy liczbę m.
            m = (int)((a + 11 * h + 22 * l) / 451);
            //Liczymy: (h + l – 7 × m + 114) : 31 i otrzymujemy resztę p.
            dzien = (h + l - 7 * m + 114) % 31;
            //Dzień Wielkanocy = p + 1.
            dzien += 1;
            //Miesiąc = Zaokrąglenie w dół dzielenia(h + l – 7 × m + 114) przez 31.
            miesiac = (int)((h + l - 7 * m + 114) / 31);


            return Convert.ToDateTime(rok.ToString() + "-" + miesiac.ToString() + "-" + dzien.ToString() );
        }

        private static void Liczba_pierwsza()
        {
            double liczba = 0.0;
            Console.Clear();
            Console.WriteLine("Witam w kalkulatorze: ZK 1.0");

            if (!Pobierz_z_konsoli("Podaj liczbę do testów na liczbę pierwszą: ", out liczba))
                return;
            Console.WriteLine();

            if (Czy_liczba_pierwsza(liczba))
                Console.WriteLine("Liczba {0} jest liczbą pierwszą.", liczba);
            else
                Console.WriteLine("!!!! Liczba {0} nie jest liczbą pierwszą.", liczba);

            Console.WriteLine("Naciśnij dowolny klawisz aby zamknąć...");
            Console.ReadKey();
        }

        private static bool Czy_liczba_pierwsza(double liczba)
        {
            int l;
            //liczba 2 jest liczbą pierwszą.
            if (liczba == 2)
                return true;

            //liczby parzyste nie sią liczbami pierwszymi 
            if (liczba % 2 == 0)
                return false;

            //Zawężamy przedział do spardzania 
            l = (int)Math.Sqrt(liczba);
            for (int k = 3; k < l; k++)
            {
                if (liczba % k == 0)
                    return false;
            }


            return true;
        }

        private static void PESEL()
        {
            string pesel;
            Pesel pesel_obiekt;
            Console.Clear();
            Console.WriteLine("Kontrla PESEL ZK 1.0\n\n");

            Console.Write("Podaj nr PESEL: ");
            pesel = Console.ReadLine();

            pesel_obiekt = Czy_pesel(pesel);
            //obiekt zawierający informację o dacie urodzenia z PESELu oraz płeć, gdy PESEL jest poprawny

            if (pesel_obiekt is null)
            Console.WriteLine("PESEL jest nieprawidłowy.");
            else
            {
                Console.WriteLine("PESEL jest prawidłowy: {0}", pesel_obiekt.pesel);
                Console.WriteLine("Płeć: {0}", pesel_obiekt.plec);
                Console.WriteLine("Data urodzenia: {0} ", pesel_obiekt.data_ur);
            }

            Console.WriteLine("Naciśnij dowolny klawisz aby zamknąć...");
            Console.ReadKey();

        }

        private static Pesel Czy_pesel( string pesel)
        {
            //Sparwdzamy PESEL ma 11 znaków.
            if (pesel.Length != 11)
                return null;

            //Sparwdzamy czy każdy znak jest cyfrą.
            for (int i = 0; i < 11; i++)
            {
                if (!"0123456789".Contains(pesel[i]))
                    return null;
            }

            //Obliczamy cyfrę kontrolną
            //Każdą pozycję numeru ewidencyjnego mnoży się przez odpowiednią wagę,
            //są to kolejno: 1 3 7 9 1 3 7 9 1 3.
            //Następnie utworzone iloczyny dodaje się i wynik dzieli się modulo 10.
            //Wynik ten należy odjąć od 10 i znów podzielić przez modulo 10
            //(to zabezpieczenie gdybyśmy w poprzednim kroku otrzymali 10).

            int waga = 0;
            int suma = 0;
            int cyfra = 0;
            int miesiac = 0;
            int rok = 0;

            for (int i = 0; i < 10; i++)
            {
                switch (i)
                {
                    case 0: waga = 1; break;
                    case 1: waga = 3; break;
                    case 2: waga = 7; break;
                    case 3: waga = 9; break;
                    case 4: waga = 1; break;
                    case 5: waga = 3; break;
                    case 6: waga = 7; break;
                    case 7: waga = 9; break;
                    case 8: waga = 1; break;
                    case 9: waga = 3; break;
                }

                suma +=  waga * Int32.Parse(pesel[i].ToString());

            }

            cyfra = suma % 10;
            cyfra = 10 - cyfra;
            cyfra = cyfra % 10;

            if (cyfra != Int32.Parse(pesel[10].ToString()))
                return null;


            Pesel pesel_obj = new Pesel();
            pesel_obj.pesel = pesel;            
            pesel_obj.plec = (Int32.Parse(pesel[9].ToString()) % 2 == 0) ? "K" : "M";

            miesiac = (int.Parse(pesel.Substring(2, 2)));

            if (miesiac >= 80)
            {
                rok = 1800; miesiac -= 80;
            }
            else if (miesiac >= 60)
            {
                rok = 2200; miesiac -= 60;
            }
            else if (miesiac >= 40)
            {
                rok = 2100; miesiac -= 40;
            }
            else if (miesiac >= 20)
            { 
                rok = 2000; miesiac -= 20;
            }
            else
                rok = 1900;

            pesel_obj.data_ur = Convert.ToDateTime( (rok + int.Parse(pesel.Substring(0, 2))).ToString() + "-" + miesiac.ToString() + "-" + pesel.Substring(4,2));

            return pesel_obj;
        }

        private static void PracownikClass()
        {
            string imie;
            string nazwisko;
            double stawka = 0.00;
            double godziny = 0.00;

            Console.Clear();
            Console.WriteLine("System RCP ZK 1.0\n\n");

            Console.Write("Podaj imię: ");
            imie = Console.ReadLine();

            Console.Write("Podaj nazwisko: ");
            nazwisko = Console.ReadLine();

            Pobierz_z_konsoli("Podaj stawkę: ", out stawka);

            Employee pracownik = new Employee(imie, nazwisko, stawka);


            Pobierz_z_konsoli("Podaj ilość godzin 1/3: ", out godziny);
            pracownik.RegisterTime(godziny);
            Pobierz_z_konsoli("Podaj ilość godzin 2/3: ", out godziny);
            pracownik.RegisterTime(godziny);
            Pobierz_z_konsoli("Podaj ilość godzin 3/3: ", out godziny);
            pracownik.RegisterTime(godziny);

            Console.WriteLine("\n\nWypłata: {0}", pracownik.PaySalary());

            Pobierz_z_konsoli("Podaj ilość godzin 1/1: ", out godziny);
            pracownik.RegisterTime(godziny);

            Console.WriteLine("\n\nWypłata: {0}", pracownik.PaySalary());

            Console.WriteLine("Naciśnij dowolny klawisz aby zamknąć...");
            Console.ReadKey();

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
