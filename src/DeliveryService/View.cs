using System;
using System.Collections.Specialized;

namespace DeliveryService {
    class View {

        private StateApp state = StateApp.MENU;
        private Controller controller = new Controller();

        public void AppRun() {
            do {
                Console.Clear();

                switch(state) {
                    case StateApp.MENU:
                        Menu();
                        break;
                    case StateApp.ADD_DATE:
                        AddNewOrder();
                        break;
                    case StateApp.FILTER_DATE:
                        break;
                    case StateApp.ERROR:
                        state = StateApp.MENU;
                        break;
                }

            } while(state != StateApp.EXIT);

            Console.Clear();
        }

        private void Menu() {
            Console.WriteLine("Add a new order - press A");
            Console.WriteLine("Filter delivery - press F");
            Console.WriteLine("Exit - press E");

            InputUserKey();
        }

        private  void InputUserKey() {
            var keyInfo = Console.ReadKey(intercept: true);
            state = controller.MoveUser(keyInfo.KeyChar);
        }

        private void AddNewOrder() {
            AddOrderNumber();
            AddOrderWeight();
            AddDeliveryDistrict();
            AddDeliveryDate();
            
            controller.UpdateDatabase();

            if(state != StateApp.ERROR) {
                Console.Clear();
                Console.WriteLine("The order has been successfully added!\nPress any key to exit this mode");
                Console.ReadKey(intercept: true);
            } else {
                Console.WriteLine("There was an error when creating a new order. Try again :(\nPress any key to exit this mode");
                state = StateApp.MENU;
                Console.ReadKey(intercept: true);
            } 
        } 

        private void AddOrderNumber() {
            do {
                if(state == StateApp.ERROR) Console.WriteLine("Wrong order number, try again...");
                Console.Write("Enter the order number: ");
                state = controller.NewOrderNumber(Console.ReadLine());
            } while(state == StateApp.ERROR);
        }

        private void AddOrderWeight() {
            do {
                if(state == StateApp.ERROR) Console.WriteLine("Wrong order weight, try again...");
                Console.Write("Enter the order weight: ");
                state = controller.NewOrderWeight(Console.ReadLine());
            } while(state == StateApp.ERROR);
        }

        private void AddDeliveryDistrict() {
            do {
                if(state == StateApp.ERROR) Console.WriteLine("Wrong delivery district, try again...");
                Console.Write("Enter the delivery district: ");
                state = controller.NewDeliveryDistrict(Console.ReadLine());
            } while(state == StateApp.ERROR);
        }

        private void AddDeliveryDate() {
            do {
                if(state == StateApp.ERROR) Console.WriteLine("Wrong delivery date, try again...");
                Console.Write("Enter the delivery date: ");
                state = controller.NewDeliveryDate(Console.ReadLine());
            } while(state == StateApp.ERROR);
        }
    }
}