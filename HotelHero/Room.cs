using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero
{
    internal class Room
    {
        public int NumberOfBeds { get; set; }
        public string RoomType { get; set; }
        public int Price { get; set; }

        public Room(int NumberOfBeds, string RoomType, int Price)
        {
            this.NumberOfBeds = NumberOfBeds;
            this.RoomType = RoomType;
            this.Price = Price;
        }

        /*

        RoomsList = new List<Room>()
            {
                new Room() { NumberOfBeds = 1, RoomType = "Standard", Price = 100 };
                new Room() { NumberOfBeds = 2, RoomType = "Standard", Price = 90 };
                new Room() { NumberOfBeds = 3, RoomType = "Standard", Price = 80 },
                new Room() { NumberOfBeds = 4, RoomType = "Standard", Price = 70 },
                new Room() { NumberOfBeds = 1, RoomType = "Premium", Price = 150 },
                new Room() { NumberOfBeds = 2, RoomType = "Premium", Price = 130 },
                new Room() { NumberOfBeds = 3, RoomType = "Premium", Price = 120 },
                new Room() { NumberOfBeds = 4, RoomType = "Premium", Price = 110 },
 
            };
        */
        
}
