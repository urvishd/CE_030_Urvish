using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_lab6_2
{
    public partial class Order : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\devan\source\repos\WebApplication_lab6_2\App_Data\Database1.mdf; Integrated Security = True";
            try
            {
                using (con)
                {
                    con.Open();
                    string query = "SELECT Product.pid, Product.pname, Product.description, Product.Cost FROM Product INNER JOIN [order] ON Product.pname = [order].pid and [order].userid = @userid";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@userid", Session["user2"]);
                    cmd.CommandText = query;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    int total = 0;
                    while (rdr.Read())
                    {
                        Label1.Text +="  " + rdr["pname"] + "           " +
                            rdr["cost"].ToString() + "<br>";
                        total += int.Parse(rdr["cost"].ToString());
                    }
                    Label2.Text = " Total : " + total.ToString();
                }
            }
            catch (Exception err)
            {
                Label2.Text = "Error occured due to " + err.Message;
            }
        }
    }
}