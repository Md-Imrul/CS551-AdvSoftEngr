using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOAPClient
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WebService.WebService service = new WebService.WebService();
            if (TBNum1.Text.Equals("")) TBNum1.Text = "0";
            if (TBNum2.Text.Equals("")) TBNum2.Text = "0";           
            int r = service.Add(TBNum1.Text, TBNum2.Text).Result;
            TBResult.Text = r + "";           
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            RemoteWebReference.WebService service = new RemoteWebReference.WebService();
            if (TBNum1.Text.Equals("")) TBNum1.Text = "0";
            if (TBNum2.Text.Equals("")) TBNum2.Text = "0";
            int r = service.Add(TBNum1.Text, TBNum2.Text).Result;
            TBResult.Text = r + ""; 
        }
    }
}