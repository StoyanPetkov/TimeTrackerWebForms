using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeTracker.Entity;

namespace TimeTracker
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLogOut.Visible = false;
            Users user = (Users)Session["User"];  
            if (Session["User"] != null)
            {
                lblHelloUser.Text = "Hello " + user.UserName;
                lblLogOut.Visible = true;
            }
        }

        protected void lblLogOut_Click(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Session["User"] = null;
                lblLogOut.Visible = false;
                lblHelloUser.Visible = false;
                Response.Redirect("Default.aspx");
                
            }
        }
    }
}