using System;
using System.Collections.Specialized;

namespace DeliveryService {
    class View {
        public View() { state = StateApp.MENU; }
        private StateApp state = new StateApp();
        private Controller controller = new Controller();
        public void AppRun() {
            do {
                Console.Clear();

                switch(state) {
                    case StateApp.MENU:
                        Menu();
                        state = InputUserKey();
                        break;
                    case StateApp.ADD_DATE:
                        state = AddNewOrder();
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
        }

        private  StateApp InputUserKey() {
            var keyInfo = Console.ReadKey(intercept: true);
            state = controller.MoveUser(keyInfo.KeyChar);
            return state;
        }

        private StateApp AddNewOrder() {
            do {
                if(state == StateApp.ERROR) Console.WriteLine("Wrong order number, try again...");
                Console.Write("Enter the order number: ");
                state = controller.NewOrderNumber(Console.ReadLine());
            } while(state == StateApp.ERROR);

            do {
                if(state == StateApp.ERROR) Console.WriteLine("Wrong order weight, try again...");
                Console.Write("Enter the order weight: ");
                state = controller.NewOrderNumber(Console.ReadLine());
            } while(state == StateApp.ERROR);

            do {
                if(state == StateApp.ERROR) Console.WriteLine("Wrong order weight, try again...");
                Console.Write("Enter the order weight: ");
                state = controller.NewOrderNumber(Console.ReadLine());
            } while(state == StateApp.ERROR);

            // do {
            //     if(state == StateApp.ERROR) Console.WriteLine("Wrong order weight, try again...");
            //     Console.Write("Enter the order weight: ");
            //     state = controller.NewOrderNumber(Console.ReadLine());
            // } while(state == StateApp.ERROR);
            
            state = controller.UpdateDatabase();
            
            return state;
        } 
    }
}