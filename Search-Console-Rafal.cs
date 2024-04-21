namespace FiltryWyszukiwania
{
    class FiltryOgólne
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fitr wyszukiwania - wybierz opcje");

            var filtry = new Dictionary<string, string>
            {
                { "Dokąd jedziesz?", "" },
                { "Podaj daty pobytu", "" },
                { "W ile osób podróżujecie?", "" },
            };
            foreach (var filter in filtry)
            {
                Console.WriteLine($"Podaj wartość dla filtru '{filter.Key}': ");
                filtry[filter.Key] = Console.ReadLine();
            }

            var rezerwacje = new List<Rezerwacja>
            {
                new Rezerwacja("Zakopane", new DateTime(2024, 6, 15), 3),
                new Rezerwacja("Kraków", new DateTime(2024, 6, 30), 2),
                new Rezerwacja("Warszawa", new DateTime(2024, 7, 10), 1),
                new Rezerwacja("Gdańsk", new DateTime(2025, 2, 6), 3),
                new Rezerwacja("Wrocław", new DateTime(2025, 3, 5), 2),
            };

            var miejscePobytu = filtry["Dokąd jedziesz?"];
            var dniPobytu = Convert.ToInt32(filtry["Podaj daty pobytu"]);
            var iloscOsob = Convert.ToInt32(filtry["W ile osób podróżujecie?"]);

            var wyniki = rezerwacje.Where(r =>
            (string.IsNullOrEmpty(miejscePobytu) || r.MiejscePobytu == miejscePobytu) &&
            (dniPobytu == 0 || (r.DataPrzyjazdu <= DateTime.Today && r.DataWyjazdu >= DateTime.Today.AddDays(dniPobytu))) &&
            (iloscOsob == 0 || r.IloscOsob >= iloscOsob)
            ).ToList();

            if (wyniki.Any())
            {
                Console.WriteLine("\nZnalezione rezerwacje hotelowe:");
                foreach (var rezerwacja in wyniki)
                {
                    Console.WriteLine($"Miejsce pobytu: {rezerwacja.MiejscePobytu}, Data przyjazdu: {rezerwacja.DataPrzyjazdu.ToShortDateString()}, Data wyjazdu: {rezerwacja.DataWyjazdu.ToShortDateString()}, Ilość osób: {rezerwacja.IloscOsob}");
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
}
            
