using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
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