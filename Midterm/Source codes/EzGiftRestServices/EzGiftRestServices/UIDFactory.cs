using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class UIDFactory
{
    static HashSet<string> uidTable = new HashSet<string>(); // stores active uids

    public UIDFactory()
    {
    }

    public static string generateUID()
    {
        Random r = new Random(DateTime.Now.Millisecond);
        string uid = null;
        do
        {
            uid = r.Next() + "";
        } while (uidTable.Add(uid) == false);

        return uid;
    }

    public static bool exists(string uid)
    {
        return uidTable.Contains(uid);
    }

    public static bool remove(string uid)
    {
        return uidTable.Remove(uid);
    }
}