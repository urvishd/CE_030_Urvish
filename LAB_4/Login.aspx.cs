using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_lab4
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text=="admin" && TextBox2.Text=="admin")
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                Label1.Text = "Incorrect Credentials!!";
                Label1.ForeColor= System.Drawing.Color.Red;
            }
        }
    }
}