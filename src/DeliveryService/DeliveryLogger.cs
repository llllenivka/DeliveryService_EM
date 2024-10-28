using System;
using System.Xml.Serialization;

namespace DeliveryService {
    
    public class DeliveryLogger {
        
        private static void CheckLogFile(string fileName) {
            var file = new FileInfo(fileName);
            if(!file.Exists) {
                using (FileStream fs = File.Create(fileName)) {}
            }
        }

        public static void NewLog(string filename, string log) {
            CheckLogFile(filename);
            DateTime date = DateTime.Now;
            string text = $"{date.ToString("yyyy-MM-dd HH:mm:ss")}: {log}{'\n'}";
            File.AppendAllText(filename, text);
        }
    }


}