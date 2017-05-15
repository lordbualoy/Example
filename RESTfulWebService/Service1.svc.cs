using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTfulWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        public string GetData(string value1,string value2)
        {
            return value1 + value1 + value1 + " " + value2 + value2 + value2;
        }
    }

    //test การ request ผ่าน browser ด้วย http://localhost:64656/Service1.svc/GetData/abc/def
}
