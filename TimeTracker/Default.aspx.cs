using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using TimeTracker.Repository;
using TimeTracker.Entity;

namespace TimeTracker
{
    public partial class Default : System.Web.UI.Page
    {
        UserRepository _userRepository = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                Users user = _userRepository.GetByUserNameAndPassword(tbUserName.Text.Trim(), tbPassword.Text);

                if (user.Id != 0)
                {
                    Session["User"] = user;
                    Response.Redirect("MainPage.aspx");
                }
                else
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Invalid Username or Password');document.location='" + ResolveClientUrl("~/Default.aspx") + "';</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Users user = new Users();

            if (CheckForEmptyBoxes())
            {
                user.Password = loginTbPassword.Text;
                user.FirstName = loginTbFirstName.Text;
                user.LastName = loginTbLastName.Text;
                user.Mail = loginTbMail.Text;
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Please fill all fields');</script>");
                return;
            }
            if (_userRepository.CheckForDuplicateUser(loginTbUserName.Text) == null)
            {
                user.UserName = loginTbUserName.Text;
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Invalid username');</script>");
                return;
            }
            if (_userRepository.ValidatePhoneNumber(loginTbPhone.Text))
            {
                user.PhoneNumber = loginTbPhone.Text;
                _userRepository.Insert(user);
                Response.Redirect("UsersPage.aspx");
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Invalid phone number');</script>");
                return;
            }
        }

        private bool CheckForEmptyBoxes()
        {
            if (loginTbFirstName.Text != "" && loginTbLastName.Text != "" &&
                loginTbMail.Text != "" && loginTbPassword.Text != "" && loginTbPhone.Text != "" && loginTbUserName.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}