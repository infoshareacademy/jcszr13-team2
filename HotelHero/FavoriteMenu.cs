using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero
{
    internal class FavoriteMenu
    {
        public List<string> FavoriteList { get; set; }
        public bool _initialized = false;
        public void Initialize()
        {
            _initialized = true;
            FavoriteList = new List<string>();
            FavoriteList.Add("Hotel 1");
            FavoriteList.Add("Hotel 2");
            FavoriteList.Add("Hotel 3");
        }
        public static void Favorite()
        { 
            
        }
    }
}
