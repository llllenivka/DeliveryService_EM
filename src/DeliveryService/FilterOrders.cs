using System;

namespace DeliveryService {

    class FilterOrders{
        public static List<OrderType> Filter(List<OrderType> orders, string district, DateTime date){
            var result = new List<OrderType>();
            foreach (var order in orders) {
                if(order.deliveryDistrict == district && order.deliveryDate >= date && order.deliveryDate < date.AddMinutes(30)){
                    result.Add(order);
                }
            }

            if(result.Count < 1) {
                throw new Exception("No such orders were found.");
            }

            return result;
        }
    }



}