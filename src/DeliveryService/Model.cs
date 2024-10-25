using System;
using System.Reflection.Metadata;
using System.Security.Permissions;

namespace DeliveryService {
    class Model {
        public ulong orderNumber {get; set;}
        public StateApp CheckKey(char key) {
            StateApp code;
            switch(key) {
                case 'A':
                case 'a':
                    code = StateApp.ADD_DATE;
                    break;
                case 'e':
                case 'E':
                    code = StateApp.EXIT;
                    break;
                default:
                    code =  StateApp.ERROR;
                    break;
            }

            return code;
        }


    }
}