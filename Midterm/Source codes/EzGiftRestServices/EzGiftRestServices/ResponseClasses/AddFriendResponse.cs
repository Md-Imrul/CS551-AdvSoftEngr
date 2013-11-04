using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class AddFriendResponse
    {
        string _errorCode;

        public AddFriendResponse() { }

        public AddFriendResponse(string errorCode) { _errorCode = errorCode; }

        public string errorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }
    }
