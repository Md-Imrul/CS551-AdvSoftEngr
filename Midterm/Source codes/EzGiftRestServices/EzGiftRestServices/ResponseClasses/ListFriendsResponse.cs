using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class ListFriendsResponse
    {        
        public ListFriendsResponse() { }
   
        public List<Friend> Records { get; set; }

        public string Result { get; set; }
        
    }
