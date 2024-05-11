using HotelHero.HotelsDatabase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelHero
{
    class FiltryOgólne
    {
        HotelsRepository hotelsRepository;

        public FiltryOgólne()
        {
            hotelsRepository = new HotelsRepository();
        }


        public void OfferSearch()
        {
            Console.WriteLine("Filtr wyszukiwania - wybierz opcje");

            var filtry = new Dictionary<string, string>
            {
                { "Dokąd jedziesz?", "" },
                { "Data przyjazdu dd.MM.yyyy", "" },
                { "Data wyjazdu dd.MM.yyyy", "" },
                { "W ile osób podróżujecie?", "" },
            };
            foreach (var filter in filtry.Keys.ToList())
            {
                Console.WriteLine($"Podaj wartość dla filtru '{filter}': ");
                filtry[filter] = Console.ReadLine();
            }

            var rezerwacje = new List<Rezerwacja>
            {
                new Rezerwacja(hotelsRepository.GetHotel(3), new DateTime(2024, 6, 15), new DateTime(2024, 6, 20), 3),
                new Rezerwacja(hotelsRepository.GetHotel(2), new DateTime(2024, 6, 30), new DateTime(2024, 7, 5), 2),
                new Rezerwacja(hotelsRepository.GetHotel(3), new DateTime(2024, 7, 10), new DateTime(2024, 7, 15), 1),
                new Rezerwacja(hotelsRepository.GetHotel(4), new DateTime(2025, 2, 6), new DateTime(2025, 2, 10), 3),
                new Rezerwacja(hotelsRepository.GetHotel(1), new DateTime(2025, 3, 5), new DateTime(2025, 3, 10), 2),
            };

            var miejscePobytu = filtry["Dokąd jedziesz?"];

            DateTime dataPrzyjazdu;
            DateTime.TryParse(filtry["Data przyjazdu dd.MM.yyyy"], out dataPrzyjazdu);

            DateTime dataWyjazdu;
            DateTime.TryParse(filtry["Data wyjazdu dd.MM.yyyy"], out dataWyjazdu);

            int iloscOsob;
            int.TryParse(filtry["W ile osób podróżujecie?"], out iloscOsob);

            var wyniki = rezerwacje.Where(r =>
            (string.IsNullOrEmpty(miejscePobytu) || r.MiejscePobytu.City == miejscePobytu) &&
            (dataPrzyjazdu == DateTime.MinValue || r.DataPrzyjazdu <= dataPrzyjazdu) &&
            (dataWyjazdu == DateTime.MinValue || r.DataWyjazdu >= dataWyjazdu) &&
            (iloscOsob == 0 || r.IloscOsob >= iloscOsob)
            ).ToList();

            if (wyniki.Any())
            {
                Console.WriteLine("\nZnalezione rezerwacje hotelowe:");
                foreach (var rezerwacja in wyniki)
                {
                    Console.WriteLine($"Miejsce pobytu: {rezerwacja.MiejscePobytu}");
                    Console.WriteLine($"Data przyjazdu: {rezerwacja.DataPrzyjazdu.ToShortDateString()}, Data wyjazdu: {rezerwacja.DataWyjazdu.ToShortDateString()}, Ilość osób: {rezerwacja.IloscOsob}");
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
        public Hotel MiejscePobytu { get; }
        public DateTime DataPrzyjazdu { get; }
        public DateTime DataWyjazdu { get; }
        public int IloscOsob { get; }
        public Rezerwacja(Hotel miejscePobytu, DateTime dataPrzyjazdu, DateTime dataWyjazdu, int iloscOsob)
        {
            MiejscePobytu = miejscePobytu;
            DataPrzyjazdu = dataPrzyjazdu;
            DataWyjazdu = dataWyjazdu;
            IloscOsob = iloscOsob;
        }
    }
}


