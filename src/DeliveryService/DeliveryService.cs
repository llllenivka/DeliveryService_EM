using System;

namespace DeliveryService {

    class DeliveryService {
        public void StartService() {
            try {
                string[] ordersString = InputOrders.GetOrders();
                List <OrderType> orders = ParsOrders.Parser(ordersString);
                List<OrderType> filterOrders = FilterOrders.Filter(orders);
                FileEntry.Output(filterOrders);
            } catch(Exception error) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {error.Message}");
                Console.ResetColor();
            }
        }
    }

}