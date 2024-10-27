using System;

namespace DeliveryService {
    class InputOrders{
        public static string[] GetOrders() {
            string fileName = InputFileName();
            string[] orders = ReadFIle(fileName);
            return orders;
        }
        private static string InputFileName() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the file name...");
            Console.ResetColor();
            string? fileName = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(fileName)){
                throw new Exception("Input error. An error occurred while reading the file name.");
            }
            return fileName;
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