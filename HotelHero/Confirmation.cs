using System.ComponentModel.Design;

namespace MasterBooking
{
    internal class Confirmation
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Do you confirm selected offer?");
            Console.WriteLine($"Press 'Y' to proceed with your reservation");
            Console.WriteLine($"Press backspace to return to offer browser");
            var option = Console.ReadKey();

            if (option.Key != ConsoleKey.Backspace && option.Key != ConsoleKey.Y)
                {
                    Console.WriteLine("Plese press 'Y' or backspace");
                }

            if (option.Key == ConsoleKey.Backspace)
                {
                Console.WriteLine($"Search for your destination");
                }

            else if (option.Key == ConsoleKey.Y)
                {
                Console.WriteLine($"Please select your payment method");
                Console.WriteLine($"Press:");
                Console.WriteLine($"1 - for credit or debit card");
                Console.WriteLine($"2 - for bank transfer");
                }
            var payment = Console.ReadKey();
            
        }
    }
}
