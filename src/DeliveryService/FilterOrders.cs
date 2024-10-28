using System;

namespace DeliveryService {

    public class FilterOrders{
        public static List<OrderType> Filter(List<OrderType> orders, DataForFilter data){
            var result = new List<OrderType>();
            foreach (var order in orders) {
                if(order.DeliveryDistrict == data.CityDistrict && order.DeliveryDate >= data.FirstDeliveryDateTime && order.DeliveryDate < data.FirstDeliveryDateTime.AddMinutes(30)){
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