using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1_lab7_4
{
    public partial class update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            using (DataClasses1DataContext dbcontext = new DataClasses1DataContext())
            {
                Student obj = dbcontext.Students.SingleOrDefault(x => x.sid == Int32.Parse(TextBox1.Text));
                obj.Name = TextBox2.Text;
                obj.sem = Int32.Parse(TextBox3.Text);
                obj.cpi =Convert.ToDouble(TextBox4.Text);
                obj.contactno = TextBox5.Text;
                obj.emailid = TextBox6.Text;
                dbcontext.SubmitChanges();

            }
            Label1.Text = "data updated!!";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (DataClasses1DataContext dbcontext = new DataClasses1DataContext())
            {
                Student obj = dbcontext.Students.SingleOrDefault(x => x.sid == Int32.Parse(TextBox1.Text));
                TextBox2.Text = obj.Name;
                TextBox3.Text = obj.sem.ToString();
                TextBox4.Text = obj.cpi.ToString();
                TextBox5.Text = obj.contactno;
                TextBox6.Text = obj.emailid;

            }
        }
    }
}