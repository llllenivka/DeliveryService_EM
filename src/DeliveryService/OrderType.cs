using System;
using System.Numerics;

namespace DeliveryService {
    public class OrderType {
        public BigInteger orderNumber {get; set;}
        public double weight {get; set;}
        public string deliveryDistrict {get; set;} = string.Empty;
        public DateTime deliveryDate {get; set;}
    }
}