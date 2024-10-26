using System;
using Newtonsoft.Json;
using System.Numerics;
using System.Text.Json;

namespace DeliveryService {
    class OrderType {
        // переделать геттеры сетттеры ????
        public BigInteger orderNumber {get; set;}
        public double weight {get; set;}
        public string deliveryDistrict {get; set;}
        public DateTime deliveryDate {get; set;}

    }

    class Model {
        private OrderType order = new OrderType();
        private string fileName = "DS_Database.json";

        public StateApp CheckKey(char key) {
            StateApp state;
            switch(key) {
                case 'A':
                case 'a':
                    state = StateApp.ADD_DATE;
                    break;
                case 'e':
                case 'E':
                    state = StateApp.EXIT;
                    break;
                default:
                    state =  StateApp.ERROR;
                    break;
            }

            return state;
        }

        public StateApp WritingToFile() {
            StateApp state;
            
            if(CorrectFile()){
                string newOrder = JsonConvert.SerializeObject(order);
                Console.WriteLine("TEST \n" + newOrder);
                File.AppendAllText(fileName, newOrder + Environment.NewLine);
                state = StateApp.MENU;
            } else state = StateApp.ERROR;
            
            return state;
        }

        private bool CorrectFile() {
            bool code = false;

            FileInfo fileInfo = new FileInfo(fileName);
            if (!fileInfo.Exists)
            {
                using (File.Create(fileName)){}
                code = true;
            } else code = true;

            return code;
        }

        public StateApp NewOrderNumber(string? orderNumberString) {
            StateApp state;
            BigInteger orderNumber;

            if(!BigInteger.TryParse(orderNumberString, out orderNumber)) {
                state = StateApp.ERROR;
            } else if (orderNumber < 1) {
                state = StateApp.ERROR;
            } else {
                order.orderNumber = orderNumber;
                state = StateApp.ADD_DATE;
            }

            return state;
        }
        public StateApp NewOrderWeight(string? weightString) {
            StateApp state;
            double weight;

            if(!double.TryParse(weightString, out weight)) {
                state = StateApp.ERROR;
            } else if (weight <= 0.0f) {
                state = StateApp.ERROR;
            } else {
                order.weight = weight;
                state = StateApp.ADD_DATE;
            }
            
            return state;
        }

        public StateApp NewDeliveryDistrict(string? orderDistrictString) {
            StateApp state;
           
            if(orderDistrictString != null){
                order.deliveryDistrict = orderDistrictString;
                state = StateApp.ADD_DATE;
            } else {
                state = StateApp.ERROR;
            }
            
            return state;
        }

        public StateApp NewDeliveryDate(string? deliveryDateString) {
            StateApp state;
            DateTime date;

            if(!DateTime.TryParse(deliveryDateString, out date)) {
                state = StateApp.ERROR;
            } else {
                order.deliveryDate = date;
                state = StateApp.ADD_DATE;
            }
            
            return state;
        }





    }
}