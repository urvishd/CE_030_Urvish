using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1_lab7_4
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (DataClasses1DataContext dbcontext = new DataClasses1DataContext())
            {
                Student obj = dbcontext.Students.SingleOrDefault(x => x.sid == Int32.Parse(TextBox1.Text));
                dbcontext.Students.DeleteOnSubmit(obj);
                dbcontext.SubmitChanges();
            }
            Label1.Text = "data deleted!!";
        }
    }
}