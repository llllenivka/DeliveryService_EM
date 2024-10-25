using System;
using System.Security.Permissions;

namespace DeliveryService {
    
    class Controller {
        private Model model = new Model();

        public StateApp MoveUser(char key) {
            StateApp code;
            code = model.CheckKey(key);
            return code;
        }

        public StateApp NewOrderNumber(string? orderNumberString) {
            StateApp code;
            ulong orderNumber;
            if(ulong.TryParse(orderNumberString, out orderNumber)) {
                model.orderNumber = orderNumber;
                code = StateApp.ADD_DATE;
            } else {
                code = StateApp.ERROR;
            }
            
            return code;
        }
        
       

        

    }
}