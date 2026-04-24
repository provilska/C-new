using System;

namespace SzyfrCezara
{
    public class Cezar
    {
        private string tekst;
        private int klucz;

        public Cezar(string tekst, int klucz)
        {
            this.tekst = tekst;
            this.klucz = klucz;
        }

        public string Szyfruj()
        {
            string wynik = "";

            int znormalizowanyKlucz = ((klucz % 26) + 26) % 26;

            foreach (char znak in tekst)
            {
                if (znak == ' ')
                {
                    wynik += znak;
                }
                else
                {
                    int kodAscii = (int)znak;
                    int nowaPozycja = (kodAscii - 97 + znormalizowanyKlucz) % 26 + 97;
                    wynik += (char)nowaPozycja;
                }
            }
            return wynik;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj tekst (małe litery): ");
            string wczytanyTekst = Console.ReadLine();

            Console.Write("Podaj klucz (liczba całkowita): ");
            if (int.TryParse(Console.ReadLine(), out int wczytanyKlucz))
            {
                Cezar szyfrator = new Cezar(wczytanyTekst, wczytanyKlucz);
                string wynik = szyfrator.Szyfruj();

                Console.WriteLine("---");
                Console.WriteLine($"Tekst zaszyfrowany: {wynik}");
            }
            else
            {
                Console.WriteLine("Błędny klucz. Podaj liczbę całkowitą.");
            }
        }
    }
}
