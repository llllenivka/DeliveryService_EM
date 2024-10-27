using System;

namespace DeliveryService {

    class FilterOrders{
        public static List<OrderType> Filter(List<OrderType> orders) {
            string district = InputDistrictFilter();
            DateTime date = InputDateFilter();
            return GetFilterOrders(orders, district, date);
        }

        private static string InputDistrictFilter() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter delivery district: ");
            Console.ResetColor();

            string ? district = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(district)) {
                throw new Exception("Input error. An error occurred while reading the district name.");
            }

            return district;
        }

        private static DateTime InputDateFilter() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the date and time (yyyy-MM-dd HH:mm:ss) of the first delivery: ");
            Console.ResetColor();

            string ? dateString = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(dateString)) {
                throw new Exception("Input error. An error occurred while reading the date and time delivery.");
            }

            return ParsOrders.GetDeliveryDate(dateString);
        }

        private static List<OrderType> GetFilterOrders(List<OrderType> orders, string district, DateTime date){
            var result = new List<OrderType>();
            foreach (var order in orders) {
                if(order.deliveryDistrict == district && order.deliveryDate >= date && order.deliveryDate < date.AddMinutes(30)){
                    result.Add(order);
                }
            }

            if(result.Count < 1) {
                throw new Exception("No such orders were found.");
            }

            return result;
        }
    }



}