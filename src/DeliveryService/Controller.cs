using System;
using System.Security.Permissions;

namespace DeliveryService {
    
    class Controller {
        private Model model = new Model();

        public StateApp MoveUser(char key) {
            return model.CheckKey(key);
        }
        public StateApp NewOrderNumber(string? orderNumberString) {
            return model.NewOrderNumber(orderNumberString);
        }
        public StateApp NewOrderWeight(string? orderWeightString) {
            return model.NewOrderWeight(orderWeightString);
        }
        public StateApp NewDeliveryDistrict(string? deliveryDistrictString) {
            return model.NewDeliveryDistrict(deliveryDistrictString);
        }
        public StateApp NewDeliveryDate(string? deliveryDateString) {
            return model.NewDeliveryDate(deliveryDateString);
        }
        public StateApp UpdateDatabase(){
            return model.WritingToFile();;
        }

        public List<string> getListDistrict() {
            return model.Districts;
        }
    }
}