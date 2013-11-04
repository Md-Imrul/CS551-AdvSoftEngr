using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace RPCClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Out.WriteLine(getHelp().status);
            //Console.Out.WriteLine(getHelp().message);
            Console.Out.WriteLine(lookup().description);
            ;
        }

        public static HelpResults getHelp()
        {
            string key = "c63b57a8895157e138c60bc8cd3fca2ad02ff1d0";
            UPChelp upcObj = XmlRpcProxyGen.Create<UPChelp>();
            HelpResults result = upcObj.help(new UpcParameters { rpc_key = key });
            return result;
        }

        public static UpcLookupResults lookup()
        {
            string key = "c63b57a8895157e138c60bc8cd3fca2ad02ff1d0";
            string _upc = "016000431645";
            UPChelp upcObj = XmlRpcProxyGen.Create<UPChelp>();
            UpcLookupResults myLookup = upcObj.lookup(new UpcParameters { rpc_key = key, upc = _upc });
            return myLookup;
        }
    }
}
