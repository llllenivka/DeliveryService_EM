using System;

namespace DeliveryService {
    class InputUser {
        public static string GetFileNameUser() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the file name...");
            Console.ResetColor();

            string? fileName = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(fileName)){
                throw new Exception("Input error. An error occurred while reading the file name.");
            }
            return fileName;
        }

        public static string GetDistrictFilterUser() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter delivery district: ");
            Console.ResetColor();

            string ? district = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(district)) {
                throw new Exception("Input error. An error occurred while reading the district name.");
            }

            return district;
        }

        public static DateTime GetDateFilterUser() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the date and time (yyyy-MM-dd HH:mm:ss) of the first delivery: ");
            Console.ResetColor();

            string ? dateString = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(dateString)) {
                throw new Exception("Input error. An error occurred while reading the date and time delivery.");
            }

            return ParsOrders.GetDeliveryDate(dateString);
        }
    }

}