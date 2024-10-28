using System;

namespace DeliveryService {

    public class DeliveryService {
        public static void StartService(string[] inputData) {
            var dataForFilter = new DataForFilter();
            bool inputSucces = true;

            try {
                dataForFilter = ParsOrders.GetInputUser(inputData);
            } catch (Exception error) {
                inputSucces = false;
                Console.WriteLine("Error: " + error.Message);
            }

            if(inputSucces) {
                try {
                    DeliveryLogger.NewLog(dataForFilter.DeliveryLog, "The program is running.");
                    string[] ordersString = NewOrders.GetOrders();
                    List <OrderType> orders = ParsOrders.Parser(ordersString);
                    DeliveryLogger.NewLog(dataForFilter.DeliveryLog, $"{orders.Count} orders have been successfully read.");
                    List<OrderType> filter = FilterOrders.Filter(orders, dataForFilter);
                    FileEntry.Output(filter, dataForFilter);
                    DeliveryLogger.NewLog(dataForFilter.DeliveryLog, $"The orders were successfully filtered out.");
                    DeliveryLogger.NewLog(dataForFilter.DeliveryLog, $"Program successfully completed");
                } catch(Exception error) {
                    DeliveryLogger.NewLog(dataForFilter.DeliveryLog, $"The program terminated with an error: {error.Message}");
                }
            }
            
        }
    }

}