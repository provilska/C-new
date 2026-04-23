using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sp
{
    class Uczestnik
    {
        public string Imie { get; set; }
        public int Wiek { get; set; }
        public double Oplata { get; set; }
        public Uczestnik(string imie, int wiek, double oplata)
        {
            Imie = imie;   
            Wiek = wiek;
            Oplata = oplata;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Uczestnik[] uczestnicy = new Uczestnik[]
            {
                new Uczestnik("Sofia",18, 26.5),
                new Uczestnik("Lena",28, 27.0),
                new Uczestnik("Maksym",20, 26.2),
                new Uczestnik("David",26, 24.0),
                new Uczestnik("Michał",21, 25.5),
                new Uczestnik("Amelia",17, 24.5)
            };
            //wyszukiwanie liniowe
            Console.WriteLine("Podaj szukane imię: \n");
            string szukaneImie = Console.ReadLine();
            WyszukajPoImieniu(uczestnicy, szukaneImie);

            //uczęstnik z najwyższą opłatą
            Uczestnik najbogatszy = uczestnicy[0];
            for (int i = 0; i< uczestnicy.Length; i++)
            {
                if(uczestnicy[i].Oplata > najbogatszy.Oplata)
                {
                    najbogatszy = uczestnicy[i];
                }
            }
            Console.WriteLine($"Uczęstnikiem z najwyższą opłatą jest {najbogatszy.Imie}, jego opłata wynowi {najbogatszy.Oplata} zł\n");

            //średnia uczęstników
            double sum = 0;
            for( int i = 0; i < uczestnicy.Length; i++)
            {
                sum += uczestnicy[i].Oplata;
            }
            Console.WriteLine($"Średnia opłata wszystkich uczęstników wynosi {sum/uczestnicy.Length}\n");

            //uczęstnicy którzy mająmniej niż 25 lat
            int count = 0;
            for( int i = 0;i < uczestnicy.Length; i++)
            {
                if (uczestnicy[i].Wiek < 25)
                {
                    count++;
                }
            }
            Console.WriteLine($"Na liście znajdują się {count} osób które mają mniej niż 25 lat\n");


            //sortowanie według opłaty
            Console.WriteLine("Dane przed sortowaniem");
            foreach(var uc in uczestnicy)
            {
                Console.WriteLine($"{uc.Imie} -> {uc.Wiek} lat -> {uc.Oplata} zł\n");
            }
            SortujInsertionSort(uczestnicy);
            Console.WriteLine("Dane po sortowaniu");
            foreach (var uc in uczestnicy)
            {
                Console.WriteLine($"{uc.Imie} -> {uc.Wiek} lat -> {uc.Oplata} zł\n");
            }
        }

        private static void SortujInsertionSort(Uczestnik[] uczestnicy)
        {
            for(int i = 1; i < uczestnicy.Length; i++)
            {
                Uczestnik key = uczestnicy[i];
                int j = i - 1;
                while(j >= 0 && uczestnicy[j].Oplata > key.Oplata)
                {
                    uczestnicy[j + 1] = uczestnicy[j];
                    j--;
                }
                uczestnicy[j+1] = key;
            }
        }

        private static void WyszukajPoImieniu(Uczestnik[] uczestnicy, string szukaneImie)
        {
            for (int i = 0; i < uczestnicy.Length; i++)
            {
                if (uczestnicy[i].Imie == szukaneImie)
                {
                    Console.WriteLine($"Imie {szukaneImie} znaleziono. Informacje o uczęstniku: {uczestnicy[i].Wiek} lat, {uczestnicy[i].Oplata} zł\n");
                }
               
            }
        }
    }
}
