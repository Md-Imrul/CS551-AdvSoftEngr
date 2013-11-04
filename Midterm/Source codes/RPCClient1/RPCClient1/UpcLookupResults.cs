using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace RPCClient1
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class UpcLookupResults : UpcResults
    {
        public string upc;
        public string description;
        public string issuerCountry;
        public string issuerCountryCode;
        public DateTime? lastModifiedUTC;
        public int? pendingUpdates;
        public bool? isCoupon;
        public string ean;
        public string size;
        public bool? found;
    }
}
