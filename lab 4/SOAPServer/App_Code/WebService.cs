using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod(Description = "Add two numbers.")]
    public OpResponse Add(string x, string y)
    {
        int ix = (x != null) ? Int32.Parse(x) : 0;
        int iy = (y != null) ? Int32.Parse(y) : 0;

        return new OpResponse("Addition", ix, iy, ix + iy);
    }

    [WebMethod(Description = "Subtract y from x.")]
    public OpResponse Subtract(string x, string y)
    {
        int ix = (x != null) ? Int32.Parse(x) : 0;
        int iy = (y != null) ? Int32.Parse(y) : 0;

        return new OpResponse("Subtract", ix, iy, ix - iy);
    }

    [WebMethod(Description = "Multiply two numbers.")]
    public OpResponse Multiply(string x, string y)
    {
        int ix = (x != null) ? Int32.Parse(x) : 0;
        int iy = (y != null) ? Int32.Parse(y) : 0;

        return new OpResponse("Multiply", ix, iy, ix * iy);
    }

    [WebMethod(Description = "Divide x by y.")]
    public OpResponse Divide(string x, string y)
    {
        int ix = (x != null) ? Int32.Parse(x) : 0;
        int iy = (y != null) ? Int32.Parse(y) : 0;
        int r = -1;
        string error = null;
        if (iy > 0) r = ix / iy;
        else { error = "Divide by zero exception."; }
        OpResponse response = new OpResponse("Divide", ix, iy, r);
        if (error != null) response.Error = error;
        return response;
    }

    public class OpResponse
    {
        int _result = 0;
        int _x, _y;
        string _opName;
        string _error = null;

        public OpResponse(string name, int x, int y, int r)
        {
            _opName = name;
            _x = x;
            _y = y;
            _result = r;
        }

        public OpResponse() { _result = 0; }

        public string OpName
        {
            get { return _opName; }
            set { _opName = value; }
        }
        public int x
        {
            get { return _x; }
            set { _x = value; }
        }

        public int y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int Result
        {
            get { return _result; }
            set { _result = value; }
        }

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }
    }
}

