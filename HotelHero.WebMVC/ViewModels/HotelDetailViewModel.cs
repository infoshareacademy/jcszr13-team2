using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.ViewModels
{
    public class HotelDetailViewModel
    {
        public Hotel Hotel { get; set; }
        public List<ReservationData> ReservationDatas { get; set; }
    }
}
