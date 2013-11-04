using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class AcceptRequest
{
    string _errorCode;
    /*  0 success
     * -1 Invalid Params
     * -2 Friend request deleted before accepting
     */
    public AcceptRequest() { }
    public AcceptRequest(string errorCode) { _errorCode = errorCode; }

    public string errorCode
    {
        get { return _errorCode; }
        set { _errorCode = value; }
    }
}
