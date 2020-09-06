using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_lab6_1
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Panel1.Visible = false;
            }
            else
            {
                Panel1.Visible = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\devan\source\repos\WebApplication_lab6_1\App_Data\Database1.mdf;Integrated Security=True";

            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand("update Student Set  Name = @Name, Sem = @sem, Mob_No = @Mobile, email_id = @Email where ID = @SID", cnn);

                cmd.Parameters.AddWithValue("@Name", TextBox2.Text);
                cmd.Parameters.AddWithValue("@sem", TextBox3.Text);
                cmd.Parameters.AddWithValue("@Mobile", TextBox4.Text);
                cmd.Parameters.AddWithValue("@Email", TextBox5.Text);
                cmd.Parameters.AddWithValue("SID", TextBox1.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();
            }
            catch(Exception err)
            {
                Label1.Text = " Error ocuured due to " + err.Message;
            }
            Label1.Text = "Record Updated Successfully!!";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\devan\source\repos\WebApplication_lab6_1\App_Data\Database1.mdf;Integrated Security=True";

            cnn = new SqlConnection(connetionString);
            string command = "select * from Student where ID=" + TextBox1.Text;
            cnn.Open();
            SqlCommand cmd = new SqlCommand(command, cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                TextBox2.Text = rdr["Name"].ToString();
                TextBox3.Text = rdr["Sem"].ToString();
                TextBox4.Text = rdr["Mob_No"].ToString();
                TextBox5.Text = rdr["email_id"].ToString();
            }
            cnn.Close();
        }
    }
}