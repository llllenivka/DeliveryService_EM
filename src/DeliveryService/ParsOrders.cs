using System;
using System.Numerics;
using Microsoft.VisualBasic;

namespace DeliveryService {

    class ParsOrders() {
        public static List<OrderType> Parser(string[] ordersString) {
            if(ordersString.Length < 1){
                throw new Exception("File is empty.");
            }

            var orders = new List<OrderType>();
            
            for(int i = 0; i < ordersString.Length; i++){
                OrderType newOrder = new OrderType();

                string[] line = ordersString[i].Split('|');
                newOrder.orderNumber = GetOrderNumber(line[0]);
                newOrder.weight = GetOrderWeight(line[1]);
                newOrder.deliveryDistrict = line[2];
                newOrder.deliveryDate = GetDeliveryDate(line[3]);

                orders.Add(newOrder);
            }

            return orders;
        }

        public static BigInteger GetOrderNumber(string numberString) {
            var number = new BigInteger();
            if(!BigInteger.TryParse(numberString, out number) || number < 0){
                throw new Exception("Incorrect order data.");
            } 

            return number;
        }

        public static double GetOrderWeight(string weightString) {
            var weight = new double();
            if(!double.TryParse(weightString, out weight)){
                throw new Exception("Incorrect order data.");
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
    }

}