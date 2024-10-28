using System;
using System.Numerics;

namespace DeliveryService {
    public class OrderType {
        public BigInteger OrderNumber { get; set; }
        public double Weight { get; set; }
        public string DeliveryDistrict { get; set; } = string.Empty;
        public DateTime DeliveryDate { get; set; }
    }

    public class DataForFilter {
        public string CityDistrict { get; set; } = string.Empty;
        public DateTime FirstDeliveryDateTime { get; set; }
        public string DeliveryLog { get; set; } = string.Empty;
        public string DeliveryOrder { get; set; } = string.Empty;
    }
}