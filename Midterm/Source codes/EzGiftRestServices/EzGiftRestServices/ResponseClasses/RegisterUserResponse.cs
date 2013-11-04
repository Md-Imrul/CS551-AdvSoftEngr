using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RegisterUserResponse
/// </summary>
public class RegisterUserResponse
{
    string _uid;
    string _errorCode;

    public RegisterUserResponse() { }

    public RegisterUserResponse(string uid, string error) { _uid = uid; _errorCode = error; }

    public string uid
    {
        get { return _uid; }
        set { _uid = value; }
    }

    public string errorCode
    {
        get { return _errorCode; }
        set { _errorCode = value; }
    }
}