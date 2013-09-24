using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        
        [WebInvoke (Method="GET", ResponseFormat=WebMessageFormat.Json, UriTemplate="add?x={v1}&y={v2}")]
        public OperationResponse Add(string v1, string v2)
        {
            int x = ((v1 != null) ? Int32.Parse(v1) : 0);
            int y = ((v2 != null) ? Int32.Parse(v2) : 0);
            int result = x + y;
            return new OperationResponse("addition", x, y, result);
            
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "subtract?x={v1}&y={v2}")]
        public OperationResponse Subtract(string v1, string v2)
        {
            int x = ((v1 != null) ? Int32.Parse(v1) : 0);
            int y = ((v2 != null) ? Int32.Parse(v2) : 0);
            int result = x - y;
            return new OperationResponse("subtract", x, y, result);

        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "multiply?x={v1}&y={v2}")]
        public OperationResponse Multiply(string v1, string v2)
        {
            int x = ((v1 != null) ? Int32.Parse(v1) : 0);
            int y = ((v2 != null) ? Int32.Parse(v2) : 0);
            int result = x * y;
            return new OperationResponse("multiply", x, y, result);

        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "divide?x={v1}&y={v2}")]
        public OperationResponse Divide(string v1, string v2)
        {
            int x = ((v1 != null) ? Int32.Parse(v1) : 0);
            int y = ((v2 != null) ? Int32.Parse(v2) : 0);
            int result = -1; 
            string error = null;
            if(y > 0) result = x / y;
            else {
                error = "Divide by zero exception.";
            }
            OperationResponse r = new OperationResponse("divide", x, y, result);
            if (error != null) r.ErrorMessage = error; 
            return r;

        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
