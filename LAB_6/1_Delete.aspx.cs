using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_lab6_1
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\devan\source\repos\WebApplication_lab6_1\App_Data\Database1.mdf;Integrated Security=True";

            cnn = new SqlConnection(connetionString);

            cnn.Open();
            int SID =Int32.Parse( TextBox1.Text);
            SqlCommand cmd = new SqlCommand("Delete From Student where ID = '" + SID + "'", cnn);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cnn.Close();
            Label1.Text = "Record Deleted Successfully!!";
        }
    }
}