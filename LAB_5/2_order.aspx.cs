using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_lab5
{
    public partial class order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int i;
            long total = 0;
            string s = "";
            

            for (i = 0; i < (int)Session["cnt"]; i++)
            {
                string pr = (string)Session[i];
                string res="Item: "+ pr + "         Price: " + Session[pr] + "  <br>  ";
                s += res;
                int a;
                total += (int)Session[pr];
            }
            Label1.Text = s;
           Label2.Text = total.ToString();
            
        }
    }
}