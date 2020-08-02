using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication_lab4
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if(IsPostBack && DropDownList1.SelectedValue=="Gujarat")
            {
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add("Ahmedabad");
                DropDownList2.Items.Add("Vadodara");

            }
            if (IsPostBack && DropDownList1.SelectedValue == "Maharashtra")
            {
                DropDownList2.Items.Clear();
                DropDownList2.Items.Add("Mumbai");
                DropDownList2.Items.Add("Pune");

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = TextBox1.Text;

            int age = Int32.Parse(TextBox2.Text);

            Label2.Text = age.ToString();


            Label3.Text = RadioButtonList1.SelectedValue;

            Label4.Text = TextBox5.Text;

            System.Text.StringBuilder sb = new StringBuilder();
            foreach (ListItem lst in CheckBoxList1.Items)
            {
               if(lst.Selected==true)
                {
                    Label5.Text += lst.Value;
                    Label5.Text += " ";
                }

               
            }

            Label6.Text= DropDownList1.SelectedValue;

            Label7.Text= DropDownList2.SelectedValue;

            Label8.Text = TextBox6.Text;


        }

        protected void pan_verify(object source, ServerValidateEventArgs args)
        {
            if(args.Value==" ")
            {
                args.IsValid = false;
            }
            else
            {
                string strRegex = @"[AB]\d{9}";
                Regex regex = new Regex(strRegex);
                if (regex.IsMatch(args.Value))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }
    }
}