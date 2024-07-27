namespace HotelHero.WebMVC.Models
{
    public class AdditionalService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public bool IsSelected { get; set; }

        public AdditionalService()
        {
        }
        public AdditionalService(int id, string name, decimal cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }
    }
}
