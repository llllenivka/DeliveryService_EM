using System;
using System.Xml.Serialization;

namespace DeliveryService {
    
    public class DeliveryLogger {
        
        private static void CheckLogFile() {
            string fileName = "_deliveryLog.txt";
            var file = new FileInfo(fileName);
            if(!file.Exists) {
                using (FileStream fs = File.Create(fileName)) {}
            }
        }

        public static void NewLog(string log) {
            CheckLogFile();
            File.AppendAllText("_deliveryLog.txt", log + '\n');
        }
    }


}