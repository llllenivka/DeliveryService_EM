using System;
using System.Collections.Specialized;
using System.Numerics;

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
            // + нажать на кнопку esc для выхода
            AddOrderNumber();
            AddOrderWeight();
            AddDeliveryDistrict();
            AddDeliveryDate();

            ResultAddOrder();
        }

        private void AddOrderNumber() {
            Console.Clear();
            do {
                if(state == StateApp.ERROR) Console.WriteLine("Wrong order number, try again...");
                Console.WriteLine("Enter the order number: ");
                state = controller.NewOrderNumber(Console.ReadLine());
            } while(state == StateApp.ERROR);
        }

        private void AddOrderWeight() {
            Console.Clear();
            do {
                if(state == StateApp.ERROR) Console.WriteLine("Wrong order weight, try again...");
                Console.WriteLine("Enter the order weight: ");
                state = controller.NewOrderWeight(Console.ReadLine());
            } while(state == StateApp.ERROR);
        }

        private void AddDeliveryDistrict() {
            List<string> districts = controller.getListDistrict(); 
            Console.Clear();
            do {
                if(state == StateApp.ERROR) Console.WriteLine("Wrong delivery district, try again...");
                for(int i = 0; i < districts.Count(); i++) {
                    Console.WriteLine($"{i + 1} - {districts[i]}");
                }
                Console.WriteLine("Select id district for order delivery : ");
                state = controller.NewDeliveryDistrict(Console.ReadLine());
            } while(state == StateApp.ERROR);
        }

        private void AddDeliveryDate() {
            Console.Clear();
            do {
                if(state == StateApp.ERROR) Console.WriteLine("Wrong delivery date, try again...");
                Console.WriteLine("Enter the delivery date (yyyy-MM-dd HH:mm:ss.): ");
                state = controller.NewDeliveryDate(Console.ReadLine());
            } while(state == StateApp.ERROR);
        }

        private void ResultAddOrder() {
            Console.Clear();
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
            state = StateApp.MENU;
        }
    }
}