using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1_lab7_4
{
    public partial class Show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sid = Int32.Parse(GridView1.SelectedRow.Cells[1].Text);
            DataClasses1DataContext dbcontext = new DataClasses1DataContext();

            GridView2.DataSource = from student in dbcontext.Students where student.sid == sid select student;
            GridView2.DataBind();
        }
    }
}