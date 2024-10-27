using System;

namespace DeliveryService {
    public class NewOrders{
        public static string[] GetOrders(string fileName) {
            string[] orders = ReadFIle(fileName);
            return orders;
        }

        private static string[] ReadFIle(string fileName) {
            var file = new FileInfo(fileName);
            if(!file.Exists) {
                throw new Exception("File does not exist.");
            }
            return File.ReadAllLines(fileName);
        }
    }
}