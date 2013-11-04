using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace RPCClient1
{
    [XmlRpcUrl("http://www.upcdatabase.com/xmlrpc")]
    public interface UPChelp : IXmlRpcProxy
    {
        [XmlRpcMethod]
        UpcLookupResults lookup(UpcParameters parameters);
        [XmlRpcMethod]
        HelpResults help(UpcParameters parameters);
        [XmlRpcMethod]
        UpcSearchResults search(UpcParameters parameters);
        // ... other methods
        
    }    
        

    
}
