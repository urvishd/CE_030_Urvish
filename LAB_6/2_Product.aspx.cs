using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_lab6_2
{
    public partial class Product : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = (string)Session["user2"];
            con = new SqlConnection();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            foreach (ListItem lt in ListBox1.Items)
            {

                //Label2.Text += lt.Value + " ";
                if (lt.Selected == true)
                {
                    Label3.Text += lt.Value + " ";
                    try
                    {
                        using (con)
                        {
                            con.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\devan\source\repos\WebApplication_lab6_2\App_Data\Database1.mdf; Integrated Security = True";
                            con.Open();
                            string query = "INSERT INTO [order] (userid, pid) values (@userid, @pid)";
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@userid", Session["user2"]);
                            cmd.Parameters.AddWithValue("@pid", lt.Value);
                            cmd.CommandText = query;
                            cmd.ExecuteNonQuery();

                        }
                    }
                    catch (Exception err)
                    {
                        Label2.Text = "During place order, Error ocuured due to " + err.Message;
                    }

                }
            }
            con.Close();
            Response.Redirect("Order.aspx");
        }
    }
}