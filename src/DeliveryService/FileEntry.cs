using System;

namespace DeliveryService {

    class FileEntry {
        public static string Output(List<OrderType> orders) {
            string filePath = "_deliveryOrder.txt";
            if(File.Exists(filePath)){
                File.Delete(filePath);
            }
            using (FileStream fs = File.Create(filePath)) {}

            foreach (var order in orders) {
                string date = order.deliveryDate.ToString("yyyy-MM-dd HH:mm:ss");
                string orderString = $"{order.orderNumber}\t|\t{order.weight}\t|\t{order.deliveryDistrict}\t|\t{date}";
                File.AppendAllText(filePath, orderString + Environment.NewLine);
            }

            return filePath;
        }
    }

}