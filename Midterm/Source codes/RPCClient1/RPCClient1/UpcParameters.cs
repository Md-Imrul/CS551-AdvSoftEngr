using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace RPCClient1
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class UpcParameters
    {
        public string rpc_key;
        public string upc;
        public string search;
        public int? max_results;
        // ... parameters for other methods
    }
}
