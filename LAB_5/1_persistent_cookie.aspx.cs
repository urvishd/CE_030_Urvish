using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_lab5
{
    public partial class persistent_cookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("products");
            cookie["p1"] = "Boat headphones";
            cookie["p2"] = "Realme 6";
            cookie["p3"] = "Puma watch";
            cookie.Expires = DateTime.Now.AddSeconds(15);
            Response.Cookies.Add(cookie);

            HttpCookie cookies = Request.Cookies["products"];
            if(cookies==null)
            {
                Label1.Text = "No products. You are first time user!";
            }
            else
            {
                Label1.Text = cookies["p1"] + " ," + cookies["p2"] + ", " + cookies["p3"];
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
        
            HttpCookie cookies = Request.Cookies["products"];
            
            if (cookies!=null)
            {
                Response.Cookies["products"].Expires = DateTime.Now.AddDays(-1);
               
            }
            if(Request.Cookies["products"]==null)
            {
                Label1.Text = "Cookies Deleted!";
            }
        }
    }
}