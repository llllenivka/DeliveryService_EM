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
        public StateApp UpdateDatabase(){
            return model.WritingToFile();;
        }

        class ParsDate {
            public virtual StateApp UpdateDate(string? orderNumberString) {
                StateApp state;
                
                return state;
            }
        }
        
       

        

    }
}