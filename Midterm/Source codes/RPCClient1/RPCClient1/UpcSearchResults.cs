using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace RPCClient1
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class UpcSearchResults : UpcResults
    {
        public int? result_count;
        public string search;
        public DateTime? noCacheAfterUTC;
        public UpcSearchResult[] results;
        public int? max_results;
    }
}
