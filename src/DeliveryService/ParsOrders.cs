using System;
using System.Numerics;
using Microsoft.VisualBasic;

namespace DeliveryService {

    public class ParsOrders {
        public static List<OrderType> Parser(string[] ordersString) {
            if(ordersString.Length < 1){
                throw new Exception("File is empty.");
            }

            var orders = new List<OrderType>();
            
            for(int i = 0; i < ordersString.Length; i++){
                OrderType newOrder = new OrderType();

                string[] line = ordersString[i].Split('|');
                newOrder.OrderNumber = GetOrderNumber(line[0]);
                newOrder.Weight = GetOrderWeight(line[1]);
                newOrder.DeliveryDistrict = line[2];
                newOrder.DeliveryDate = GetDeliveryDate(line[3]);

                orders.Add(newOrder);
            }

            return orders;
        }

        public static BigInteger GetOrderNumber(string numberString) {
            var number = new BigInteger();
            if(!BigInteger.TryParse(numberString, out number) || number < 0){
                throw new Exception("Incorrect order number.");
            } 

            return number;
        }

        public static double GetOrderWeight(string weightString) {
            var weight = new double();
            if(!double.TryParse(weightString, out weight)){
                throw new Exception("Incorrect order weight.");
            }
            return weight;
        }

        public static DateTime GetDeliveryDate(string dateString) {
            var date = new DateTime();
            if(!DateTime.TryParse(dateString, out date)) {
                throw new Exception("Incorrect order data.");
            }
            return date;
        }

        public static DataForFilter GetInputUser(string [] inputUser) {
            if (inputUser.Length < 4 || inputUser.All(item => string.IsNullOrEmpty(item))) {
                throw new Exception("The entered data is incorrect or missing");
            }

            var data = new DataForFilter {
                CityDistrict = inputUser[0],
                FirstDeliveryDateTime = GetDeliveryDate($"{inputUser[1]} {inputUser[2]}"),
                DeliveryLog = inputUser[3],
                DeliveryOrder = inputUser[4]
            };

            return data;
        }
    }

}