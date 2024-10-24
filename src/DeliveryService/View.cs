using System;
using System.Collections.Specialized;

namespace DeliveryService {
    class View {
        public static void AppRun() {
            
            
        }
        public static char Menu() {
            Console.WriteLine("Add a new order - press A");
            Console.WriteLine("Filter delivery - press F");
            Console.WriteLine("Exit - press E");

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            return keyInfo.KeyChar;
        }
    }
}