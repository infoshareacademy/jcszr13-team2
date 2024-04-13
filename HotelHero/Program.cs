namespace MasterBooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Proszę podać dzień przyjazdu w formacie dd-mm-rrrr");    //nie ma walidacji
            string checkIn = Console.ReadLine();

            Console.WriteLine("Proszę podać dzień wyjazdu w formacie dd-mm-rrrr");      //nie ma walidacji
            string checkOut = Console.ReadLine();

            DateTime.TryParse(checkIn, out DateTime checkInDate);
            DateTime.TryParse(checkOut, out DateTime checkOutDate);

            TimeSpan nightsSpent = checkOutDate - checkInDate;
            Console.WriteLine($"Liczba nocy wynosi {nightsSpent}");      // format


            Console.WriteLine("Proszę podać liczbę gości");
            int  guestsNumber;
            guestsNumber = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Proszę wybrać typ pokoju"+
                "\nWskaż numer wybranej opcji:"+
                "\n1.Standard"+
                "\n2. Premium");
            int roomType = Convert.ToInt32 (Console.ReadLine());
            switch (roomType)
            {
                case 1:
                    Console.WriteLine("Wybrano pokój typu Standard");
                    break;
                case 2:
                    Console.WriteLine("Wybrano pokój typu Premium");
                    break;
            }


            if (guestsNumber == 1 && roomType == 1)
                {
                Console.WriteLine("Dostępny pokój 1-osobowy typu Standard");
                }

            if (guestsNumber == 2 && roomType == 1)
                {
                 Console.WriteLine("Dostępny pokój 2-osobowy typu Standard");
                }

            if (guestsNumber == 3 && roomType == 1)
                {
                 Console.WriteLine("Dostępny pokój 3-osobowy typu Standard");
                }

            if (guestsNumber == 4 && roomType == 1)
                {
                 Console.WriteLine("Dostępny pokój 4-osobowy typu Standard");
                }

            if (guestsNumber > 4 && roomType == 1)
                {
                 Console.WriteLine("Prosimy o kontakt z hotelem w sprawie rezerwacji");
                }

            if (guestsNumber == 1 && roomType == 2)
                {
                    Console.WriteLine("Dostępny pokój 1-osobowy typu Premium");
                }

            if (guestsNumber == 2 && roomType == 2)
                {
                    Console.WriteLine("Dostępny pokój 2-osobowy typu Premium");
                }

            if (guestsNumber == 3 && roomType == 2)
                {
                    Console.WriteLine("Dostępny pokój 3-osobowy typu Premium");
                }

            if (guestsNumber == 4 && roomType == 2)
                {
                    Console.WriteLine("Dostępny pokój 4-osobowy typu Premium");
                }

            if (guestsNumber > 4 && roomType == 2)
                {
                    Console.WriteLine("Prosimy o kontakt z hotelem w sprawie rezerwacji");
                }



        }
    }
}
