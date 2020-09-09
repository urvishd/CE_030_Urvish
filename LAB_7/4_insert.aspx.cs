using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1_lab7_4
{
    public partial class insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using(DataClasses1DataContext dbcontext=new DataClasses1DataContext())
            {
                Student s1 = new Student
                {
                    Name = TextBox2.Text,
                    sem = Convert.ToInt32(TextBox3.Text),
                    cpi = float.Parse(TextBox4.Text),
                    contactno = TextBox5.Text,
                    emailid=TextBox6.Text
                };
                dbcontext.Students.InsertOnSubmit(s1);
                dbcontext.SubmitChanges();

            }
            Label1.Text = "Record Inserted Successfully";
        }
    }
}