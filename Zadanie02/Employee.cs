using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie02
{
   

    class Employee
    {
        string imie;
        string nazwisko;
        double stawka;
        double do_zaplaty = 0.0;

        public Employee(string imie, string nazwisko, double stawka)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.stawka = stawka;
            this.do_zaplaty = 0;
        }

        public void RegisterTime(double godziny)
        {
            
            
            if (godziny > 8)
                do_zaplaty += ((godziny - 8) * stawka * 2) + (8*stawka);
            else
                do_zaplaty += godziny * stawka;
            
        }

        public double PaySalary()
        {
            double wyplata;
            wyplata = do_zaplaty;
            do_zaplaty = 0;
            return wyplata;
        }
    }
}
