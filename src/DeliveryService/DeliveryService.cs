using System;

namespace DeliveryService {

    public class DeliveryService {
        public static void StartService() {
            try {
                DeliveryLogger.NewLog("The program is running.");

                string fileName = InputUser.GetFileNameUser();
                DeliveryLogger.NewLog($"Opening the {fileName} file.");

                string[] ordersString = NewOrders.GetOrders(fileName);
                List <OrderType> orders = ParsOrders.Parser(ordersString);
                DeliveryLogger.NewLog($"{orders.Count} orders have been successfully read.");

                string districtFilter = InputUser.GetDistrictFilterUser();
                DateTime dateFilter = InputUser.GetDateFilterUser();
                string dateString = dateFilter.ToString("yyyy-MM-dd HH:mm:ss");

                DeliveryLogger.NewLog($"Set up an order filter by {districtFilter} and {dateString}.");

                List<OrderType> filterOrders = FilterOrders.Filter(orders, districtFilter, dateFilter);
                DeliveryLogger.NewLog($"The orders were successfully filtered out.");

                Console.WriteLine("The result was written to " + FileEntry.Output(filterOrders));
                DeliveryLogger.NewLog($"Program successfully completed");
                
            } catch(Exception error) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {error.Message}");
                DeliveryLogger.NewLog($"The program terminated with an error: {error.Message}");
                Console.WriteLine("The logs was written to _deliveryLog");
                Console.ResetColor();
            }
        }
    }

}