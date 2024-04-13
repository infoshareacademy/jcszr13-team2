using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.HotelsDatabase
{
    internal class HotelsRepository
    {
        public List<Hotel> Repository {  get; set; }  

        public HotelsRepository()
        {
            initialisation();
        }

        private void initialisation()
        {
            Repository = new List<Hotel>()
            {
                new Hotel(){ Name = "Hotel 1",Address = "Słowackiego 1", City = "Warszawa", Description = "Hotel w Warszawie", Stars = 4, Rating = 4.5f },
                new Hotel(){ Name = "Hotel 2",Address = "Sienkiewicza 3", City = "Warszawa", Description = "Najlepszy hotel w Warszawie", Stars = 5, Rating = 5.0f },
                new Hotel(){ Name = "Hotel 3",Address = "Mickiewicza 45", City = "Kraków", Description = "Hotel w Krakowie", Stars = 3, Rating = 3.7f },
                new Hotel(){ Name = "Hotel 4",Address = "Fredry 36", City = "Poznań", Description = "Hotel w Poznaniu", Stars = 5, Rating = 4.7f },
            };

        }
    }
}
