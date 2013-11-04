using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace RPCClient1
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class HelpResults : UpcResults
    {
        public string help;
    }
}
