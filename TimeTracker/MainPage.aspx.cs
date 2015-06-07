using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeTracker.Repository;
using TimeTracker.Entity;

namespace TimeTracker
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        UserRepository userRepo = new UserRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = (Users)Session["User"];
            if (user.UserRole == 2)
            {
                imgbtnAdmins.Visible = false;
            }

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            GridView GridViewUsers = new GridView();
            GridViewUsers.DataSource = userRepo.GetAll();
        }

        protected void imgbtnUsers_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UsersPage.aspx");
        }

        protected void imgbtnAdmins_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AdminsPage.aspx");
        }
    }
}