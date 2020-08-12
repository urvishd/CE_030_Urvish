using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_lab5
{
    public class Data
    {
        public string name;
        public int price;
        public Data(string n, int p)
        {
            name = n;
            price = p;
        }
    }
    public partial class Home : System.Web.UI.Page
    {
        private const int V = 800;
        private const int V1 = 999;
        private const int V2 = 799;
        private const int V3 = 699;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["uname"]!=null)
            {
                Label1.Text = "Hello " + Session["uname"];
            }
            Session["The alchemist @ 375"] = 375;
            Session["Saurastra ni Rasdhar @ 180"] = 180;
            Session["shiva trilogy @ 800"] = V;
            Session["Hp Laptop @ 39999"] = 39999;
            Session["Realme 6 @ 7999"] = 7999;
            Session["Hp 64GB Pendrive @ 699"] = 699;

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            ListBox2.Items.Add(ListBox1.SelectedValue);
            ListBox1.Items.Remove(ListBox1.SelectedValue);
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "Electronics")
            {
                ListBox1.Items.Clear();
                ListBox1.Items.Add("Hp Laptop @ 39999");
                ListBox1.Items.Add("Realme 6 @ 7999");
                ListBox1.Items.Add("Hp 64GB Pendrive @ 699");
               
               

            }
            else if (RadioButtonList1.SelectedValue == "Books")
            {
                ListBox1.Items.Clear();
                ListBox1.Items.Add("The alchemist @ 375");
                ListBox1.Items.Add("Saurastra ni Rasdhar @ 180");
                ListBox1.Items.Add("shiva trilogy @ 800");
               
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (ListBox2.SelectedValue != null)
            {
                ListBox1.Items.Add(ListBox2.SelectedValue);
                ListBox2.Items.Remove(ListBox2.SelectedValue);
            }
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int products = ListBox2.Items.Count;
            Session["cnt"] = products;
            int i;
            for(i=0;i<products;i++)
            {
                Session[i] = ListBox2.Items[i].Value;
            }
            Response.Redirect("order.aspx");
        }

       
    }
}