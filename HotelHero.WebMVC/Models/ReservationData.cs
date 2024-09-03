namespace HotelHero.WebMVC.Models
{
    public class ReservationData
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int AmountOfPeople { get; set; }
        public decimal CostPerNight { get; set; }
    }
}
