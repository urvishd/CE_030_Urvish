using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_lab6_2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\devan\source\repos\WebApplication_lab6_2\App_Data\Database1.mdf;Integrated Security=True";

            cnn = new SqlConnection(connetionString);
            Int32 verify;
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from Users where userid = '" + TextBox1.Text + "'AND password = '" + TextBox2.Text + "'", cnn);
            verify = Convert.ToInt32(cmd.ExecuteScalar());
            if(verify>0)
            {
                Session["user2"] = TextBox1.Text;
                Response.Redirect("Product.aspx");
            }
            else
            {
                Label1.Text = "Invalid Username or Password";
            }

            cnn.Close();
        }
    }
}