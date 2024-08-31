using HotelHero.WebMVC.Models;

namespace HotelHero.WebMVC.ViewModels
{
    public class SearchResultsViewModel
    {
        public string City { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? PeopleAmount { get; set; }
        public decimal? CostPerNight { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
