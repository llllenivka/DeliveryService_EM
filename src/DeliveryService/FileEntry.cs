using System;

namespace DeliveryService {

    class FileEntry {
        public static string Output(List<OrderType> orders, DataForFilter data) {
            string filePath = data.DeliveryOrder;
            if(File.Exists(filePath)){
                File.Delete(filePath);
            }
            using (FileStream fs = File.Create(filePath)) {}

            foreach (var order in orders) {
                string date = order.DeliveryDate.ToString("yyyy-MM-dd HH:mm:ss");
                string orderString = $"{order.OrderNumber}\t|\t{order.Weight}\t|\t{order.DeliveryDistrict}\t|\t{date}";
                File.AppendAllText(filePath, orderString + Environment.NewLine);
            }

            return filePath;
        }
    }

}