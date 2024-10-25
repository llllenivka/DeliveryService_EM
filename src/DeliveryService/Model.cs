using System;
using Newtonsoft.Json;
using System.Numerics;
using System.Text.Json;

namespace DeliveryService {
    class OrderType {
        // переделать геттеры сетттеры ????
        private BigInteger orderNumber;
        private double orderWeight;
        private string orederDistrict;
        private DateTime orderDate;

        public void setOrderNumber(BigInteger number) {
            orderNumber = number;
        }

        public void setOrderWeight(double weight) {
            orderWeight = weight;
        }


    }
    class Model {
        private OrderType order = new OrderType();
        private string fileName = "DS_Database.json";

        public StateApp CheckKey(char key) {
            StateApp state;
            switch(key) {
                case 'A':
                case 'a':
                    state = StateApp.ADD_DATE;
                    break;
                case 'e':
                case 'E':
                    state = StateApp.EXIT;
                    break;
                default:
                    state =  StateApp.ERROR;
                    break;
            }

            return state;
        }

        public StateApp WritingToFile() {
            StateApp state;
            
            if(CorrectFile()){
                string newOrder = JsonConvert.SerializeObject(order);
                File.AppendAllText(fileName, newOrder + Environment.NewLine);
                state = StateApp.MENU;
            } else state = StateApp.ERROR;
            
            return state;
        }

        private bool CorrectFile() {
            bool code = false;

            FileInfo fileInfo = new FileInfo(fileName);
            if (!fileInfo.Exists)
            {
                File.Create(fileName);
                code = true;
            } else code = true;

            return code;
        }

        public StateApp NewOrderNumber(string? orderNumberString) {
            StateApp state;
            BigInteger orderNumber;

            if(!BigInteger.TryParse(orderNumberString, out orderNumber)) {
                state = StateApp.ERROR;
            } else if (orderNumber < 1) {
                state = StateApp.ERROR;
            } else {
                order.setOrderNumber(orderNumber);
                state = StateApp.ADD_DATE;
            }

            return state;
        }
        public StateApp NewOrderWeight(string? orderWeightString) {
            StateApp state;
            double orderWeight;

            if(!double.TryParse(orderWeightString, out orderWeight)) {
                state = StateApp.ERROR;
            } else if (orderWeight <= 0) {
                state = StateApp.ERROR;
            } else {
                order.setOrderWeight(orderWeight);
                state = StateApp.ADD_DATE;
            }
            
            return state;
        }





    }
}