using System;

namespace DeliveryService {

    class FileEntry {
        public static void Output(List<OrderType> orders) {
            string filePath = "_deliverOrder.txt";
            if(File.Exists(filePath)){
                File.Delete(filePath);
            }
            using (FileStream fs = File.Create(filePath)) {}

            foreach (var order in orders) {
                string date = order.deliveryDate.ToString("yyyy-MM-dd HH:mm:ss");
                string orderString = $"{order.orderNumber}\t{order.weight}\t{order.deliveryDistrict}\t{date}";
                File.AppendAllText(filePath, orderString + Environment.NewLine);
            }
        }
    }

}