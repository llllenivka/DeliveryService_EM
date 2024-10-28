using System;

namespace DeliveryService {
    public class NewOrders{
        public static string[] GetOrders() {
            string rootDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName = string.Empty;
            string filePath = Path.Combine(rootDirectory, "Example.txt");
            string[] orders = ReadFIle(filePath);
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