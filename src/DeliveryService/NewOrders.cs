using System;

namespace DeliveryService {
    public class NewOrders{
        public static string[] GetOrders() {
            string[] orders = ReadFIle("Example.txt");
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