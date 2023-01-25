using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zaliczenie;

namespace Bank
{
    internal class Program
    {
        private static int interest;
        private static int numberOfYears;

        static void Main(string[] args)
        {

            

            kontoBankowe kontoBankowe = new kontoBankowe();
            Console.WriteLine("Podaj swoje imie:");
            kontoBankowe.imie = Console.ReadLine();
            Console.WriteLine("Ile masz pieniędzy na koncie?");
            kontoBankowe.stanKonta = Console.ReadLine();
            if (double.TryParse(kontoBankowe.stanKonta, out double result) == false || kontoBankowe.stanKonta == "")
            {
                Console.WriteLine("Wprowadzono złą wartość, spróbuj jeszcze raz.");
                Console.ReadLine();
                Main(args);

            }
            else
            {
                Console.WriteLine("Witaj " + kontoBankowe.imie + " na ten moment posiadasz: " + result + " PLN");
                Console.WriteLine("Podaj numer operacji którą chcesz wykonać:");
                Console.WriteLine("1. Dodaj saldo");
                Console.WriteLine("2. Wypłać pieniądze");
                Console.WriteLine("3. Sprawdź stan konta");
                Console.WriteLine("4. Oblicz ratę kredytu");
                int wybor = int.Parse(Console.ReadLine());
                if (wybor == 1)
                {
                    Console.WriteLine("Ile pieniędzy chcesz wpłacić na konto?");
                    double wplata = double.Parse(Console.ReadLine());
                    Console.WriteLine("Wpłata ukończona pomyślnie, teraz posiadasz: " + (result + wplata));
                    Console.ReadLine();
                }
                else if (wybor == 2)
                {
                    Console.WriteLine("Ile pieniędzy chcesz wypłacić?");
                    double wyplata = double.Parse(Console.ReadLine());
                    Console.WriteLine("Pomyślnie wypłacono " + wyplata + " PLN, teraz posiadasz:" + (result - wyplata));
                    Console.ReadLine();

                }
                else if (wybor == 3)
                {
                    Console.WriteLine(kontoBankowe.stanKonta);
                    Console.ReadLine();
                }
                else if (wybor == 4)
                {
                    RataKredytu rataKredytu = new RataKredytu();
                    Console.Write("Wpisz kwotę kredytu: ");
                    rataKredytu.loanAmount = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Wybierz oprocentowanie:");
                    rataKredytu.interest = Convert.ToDouble(Console.ReadLine());
                    rataKredytu.interestG = (rataKredytu.interest / 100);
                    Console.WriteLine("Na ile miesiecy chcesz kredyt: ");
                    rataKredytu.numberOfYears = Convert.ToDouble(Console.ReadLine()); //miesiace a nie rok  
                    rataKredytu.paymentAmount = (rataKredytu.loanAmount + (rataKredytu.loanAmount * rataKredytu.interestG));
                    rataKredytu.paymentAmountG = (rataKredytu.paymentAmount / rataKredytu.numberOfYears);

                    Console.WriteLine("Rata miesięczna dla: " + kontoBankowe.imie + " wynosi: " + Math.Round(rataKredytu.paymentAmountG, 2));
                    Console.WriteLine("Po wzięciu kredytu stan twojego konta będzie wynosił: " + ((Convert.ToDouble(kontoBankowe.stanKonta) + (Convert.ToDouble(rataKredytu.loanAmount)))));
                    Console.ReadLine();





                }
                else
                {
                    Console.WriteLine("Podano nieprawidłową wartość.");
                    Console.ReadLine();

                }
                


            }
        }
           
               

            
        
    }
}