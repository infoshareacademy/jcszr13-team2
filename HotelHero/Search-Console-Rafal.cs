using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelHero
{
    class FiltryOgólne
    {
        public static void OfferSearch()
        {
            Console.WriteLine("Filtr wyszukiwania - wybierz opcje");

            var filtry = new Dictionary<string, string>
            {
                { "Dokąd jedziesz?", "" },
                { "Data przyjazdu", "" },
                { "Data wyjazdu", "" },
                { "W ile osób podróżujecie?", "" },
            };
            foreach (var filter in filtry.Keys.ToList())
            {
                Console.WriteLine($"Podaj wartość dla filtru '{filter}': ");
                filtry[filter] = Console.ReadLine();
            }

            var rezerwacje = new List<Rezerwacja>
            {
                new Rezerwacja("Zakopane", new DateTime(2024, 6, 15), new DateTime(2024, 6, 20), 3),
                new Rezerwacja("Kraków", new DateTime(2024, 6, 30), new DateTime(2024, 7, 5), 2),
                new Rezerwacja("Warszawa", new DateTime(2024, 7, 10), new DateTime(2024, 7, 15), 1),
                new Rezerwacja("Gdańsk", new DateTime(2025, 2, 6), new DateTime(2025, 2, 10), 3),
                new Rezerwacja("Wrocław", new DateTime(2025, 3, 5), new DateTime(2025, 3, 10), 2),
            };

            var miejscePobytu = filtry["Dokąd jedziesz?"];

            DateTime dataPrzyjazdu;
            DateTime.TryParse(filtry["Data przyjazdu DD.MM.YYYY"], out dataPrzyjazdu);

            DateTime dataWyjazdu;
            DateTime.TryParse(filtry["Data wyjazdu DD.MM.YYYY"], out dataWyjazdu);

            int iloscOsob;
            int.TryParse(filtry["W ile osób podróżujecie?"], out iloscOsob);

            var wyniki = rezerwacje.Where(r =>
            (string.IsNullOrEmpty(miejscePobytu) || r.MiejscePobytu == miejscePobytu) &&
            (dataPrzyjazdu == DateTime.MinValue || r.DataPrzyjazdu <= dataPrzyjazdu) &&
            (dataWyjazdu == DateTime.MinValue || r.DataWyjazdu >= dataWyjazdu) &&
            (iloscOsob == 0 || r.IloscOsob >= iloscOsob)
            ).ToList();

            if (wyniki.Any())
            {
                Console.WriteLine("\nZnalezione rezerwacje hotelowe:");
                foreach (var rezerwacja in wyniki)
                {
                    Console.WriteLine($"Miejsce pobytu: {rezerwacja.MiejscePobytu}, Data przyjazdu: {rezerwacja.DataPrzyjazdu.ToShortDateString()}, Data wyjazdu: {rezerwacja.DataWyjazdu.ToShortDateString()}, Ilość osób: {rezerwacja.IloscOsob}");
                }
            }

            else
            {
                Console.WriteLine("\nBrak pasujących rezerwacji");
            }

        }
    }

    class Rezerwacja
    {
        public string MiejscePobytu { get; }
        public DateTime DataPrzyjazdu { get; }
        public DateTime DataWyjazdu { get; }
        public int IloscOsob { get; }
        public Rezerwacja(string miejscePobytu, DateTime dataPrzyjazdu, DateTime dataWyjazdu, int iloscOsob)
        {
            MiejscePobytu = miejscePobytu;
            DataPrzyjazdu = dataPrzyjazdu;
            DataWyjazdu = dataWyjazdu;
            IloscOsob = iloscOsob;
        }
    }
}


