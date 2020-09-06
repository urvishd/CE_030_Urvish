using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_lab6_1
{
    public partial class insert : System.Web.UI.Page
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
            var sql = "INSERT INTO Student(Name,Sem,Mob_No,email_id) VALUES(@fname,@sem,@mobile,@mail)";
            using (var cmd = new SqlCommand(sql, cnn))
            {
                cmd.Parameters.AddWithValue("@fname", TextBox1.Text);
                cmd.Parameters.AddWithValue("@sem", TextBox2.Text);
                cmd.Parameters.AddWithValue("@mobile", TextBox3.Text);
                cmd.Parameters.AddWithValue("@mail", TextBox4.Text);

                cmd.ExecuteNonQuery();
            }
            Label1.Text = "Record inserted Successfully!!";
            Response.Write("Connection Made");
            cnn.Close();
        }
    }
}