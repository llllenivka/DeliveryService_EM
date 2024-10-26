using System.Numerics;

namespace DeliveryService {
    class DeliveryService {
        private List <OrderType> orders = new List<OrderType>();

        public void StartService() {
            try {
                string fileName = InputFileName();
                string[] ordersString = OpenFIle(fileName);
                ParseOrders(ordersString);
                List<OrderType> filterOrders = FilterOrders();

            } catch(Exception error) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {error.Message}");
                Console.ResetColor();
            }
            
        }

        private string InputFileName() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the file name...");
            Console.ResetColor();
            string? fileName = Console.ReadLine();
            if(fileName == null){
                throw new Exception("Input error. An error occurred while reading the file name.");
            }
            return fileName;
        }

        private string[] OpenFIle(string fileName) {
            FileInfo file = new FileInfo(fileName);
            if(!file.Exists) {
                throw new Exception("File does not exist.");
            }
            return File.ReadAllLines(fileName);
        }

        private void ParseOrders(string[] ordersString) {
            if(ordersString.Length < 1){
                throw new Exception("File is empty.");
            }
            for(int i = 0; i < ordersString.Length; i++){

                OrderType newOrder = new OrderType();
                string[] line = ordersString[i].Split('|');
                newOrder.orderNumber = GetOrderNumber(line[0]);
                newOrder.weight = GetOrderWeight(line[1]);
                newOrder.deliveryDistrict = line[2];
                newOrder.deliveryDate = GetDeliveryDate(line[3]);
                orders.Add(newOrder);
            }
        }

        private BigInteger GetOrderNumber(string numberString) {
            BigInteger number;
            if(!BigInteger.TryParse(numberString, out number) || number < 0){
                throw new Exception("Incorrect order data.");
            } 

            return number;
        }

        private double GetOrderWeight(string weightString) {
            double weight;
            if(!double.TryParse(weightString, out weight)){
                throw new Exception("Incorrect order data.");
            }
            return weight;
        }

        private DateTime GetDeliveryDate(string dateString) {
            DateTime date;
            if(!DateTime.TryParse(dateString, out date)) {
                throw new Exception("Incorrect order data.");
            }
            return date;
        }

        private List<OrderType> FilterOrders() {
            string district = InputDistrictFilter();
            DateTime date = InputDateFilter();
            return GetFilterOrders(district, date);
        }

        private string InputDistrictFilter() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the district to filter delivery: ");
            Console.ResetColor();

            string ? district = Console.ReadLine();

            if(district == null) {
                throw new Exception("Input error. An error occurred while reading the district name.");
            }

            return district;
        }

        private DateTime InputDateFilter() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the date and time to filter delivery: ");
            Console.ResetColor();

            string ? dateString = Console.ReadLine();

            if(dateString == null) {
                throw new Exception("Input error. An error occurred while reading the date and time delivery.");
            }

            return GetDeliveryDate(dateString);
        }

        private List<OrderType> GetFilterOrders(string district, DateTime date){
            List<OrderType> result = new List<OrderType>();
            for(int i = 0; i < orders.Count; i++) {
                if(orders[i].deliveryDistrict == district){
                    result.Add(orders[i]);
                }
            }

            Console.WriteLine(result.Count);

            if(result.Count < 1) {
                throw new Exception("No such orders were found.");
            }

            return result;
        }

    }
}