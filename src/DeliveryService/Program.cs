using System;

namespace DeliveryService
{
    enum StateApp {
        MENU,
        ADD_DATE,
        FILTER_ORDERS,
        ERROR,
        EXIT = -1 
    };
    class Program
    {
        static void Main(string[] args) {
            // View App = new View();
            // App.AppRun();

            DeliveryService service = new DeliveryService();
            service.StartService();
        }

    }
}