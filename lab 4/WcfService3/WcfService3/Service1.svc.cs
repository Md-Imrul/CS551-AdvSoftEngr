using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
            addToDB("rest:add", x, y, "");
            return new OperationResponse("addition", x, y, result);
            
        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "subtract?x={v1}&y={v2}")]
        public OperationResponse Subtract(string v1, string v2)
        {
            int x = ((v1 != null) ? Int32.Parse(v1) : 0);
            int y = ((v2 != null) ? Int32.Parse(v2) : 0);
            int result = x - y;
            addToDB("rest:sub", x, y, "");
            return new OperationResponse("subtract", x, y, result);

        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "multiply?x={v1}&y={v2}")]
        public OperationResponse Multiply(string v1, string v2)
        {
            int x = ((v1 != null) ? Int32.Parse(v1) : 0);
            int y = ((v2 != null) ? Int32.Parse(v2) : 0);
            int result = x * y;
            addToDB("rest:sub", x, y, "");
            return new OperationResponse("multiply", x, y, result);

        }

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "divide?x={v1}&y={v2}")]
        public OperationResponse Divide(string v1, string v2)
        {
            int x = ((v1 != null) ? Int32.Parse(v1) : 0);
            int y = ((v2 != null) ? Int32.Parse(v2) : 0);
            int result = -1; 
            string error = "";
            if(y > 0) result = x / y;
            else {
                error = "Divide by zero exception.";
            }
            addToDB("rest:div", x, y, error);
            OperationResponse r = new OperationResponse("divide", x, y, result);
            r.ErrorMessage = error; 
            return r;

        }

        private bool addToDB(string opName, int x, int y, string error)
        {

            //string test = "undefined";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbString"].ConnectionString);
            conn.Open();
            SqlCommand slcmd = new SqlCommand("insert into opRequest(opName, x_val, y_val, error) values(@op,@x,@y,@e)", conn);
            slcmd.Parameters.Add("@op", System.Data.SqlDbType.NChar).Value = opName;
            slcmd.Parameters.Add("@x", System.Data.SqlDbType.Int).Value = x;
            slcmd.Parameters.Add("@y", System.Data.SqlDbType.Int).Value = y;
            slcmd.Parameters.Add("@e", System.Data.SqlDbType.Text).Value = error;
            slcmd.ExecuteScalar();
            
            return true;
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
