namespace HotelHero.WebMVC.ViewModels
{
    public class SearchViewModel
    {
        public string City { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? PeopleAmount { get; set; }
    }
}
