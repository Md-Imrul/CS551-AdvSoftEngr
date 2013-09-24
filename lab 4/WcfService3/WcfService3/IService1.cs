using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        OperationResponse Add(string v1, string v2);

        [OperationContract]
        OperationResponse Subtract(string v1, string v2);

        [OperationContract]
        OperationResponse Multiply(string v1, string v2);

        [OperationContract]
        OperationResponse Divide(string v1, string v2);

        // TODO: Add your service operations here
        //[OperationContract]
        //AddResponse Addition(AddRequest request);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }


    [DataContract(Name="AddResponse")]
    public class OperationResponse {
        int _result = 0;
        int _x, _y;
        string _opName = "";
        string _errorMessage = "";

        public OperationResponse(string opName, int x, int y, int r) {
            _opName = opName;
            _x = x; 
            _y = y;
            _result = r; 
        }        

        [DataMember]
        public string OpName
        {
            get { return _opName; }
            set { _opName = value; }
        }

        [DataMember]
        public int x
        {
            get { return _x; }
            set { _x = value; }
        }

        [DataMember]
        public int y
        {
            get { return _y; }
            set { _y = value; }
        }

        [DataMember]
        public int result {
            get { return _result; }
            set { _result = value;}
        }

        [DataMember]
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
    }
}
