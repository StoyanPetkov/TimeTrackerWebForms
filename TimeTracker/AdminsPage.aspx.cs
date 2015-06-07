using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimeTracker.Repository;
using TimeTracker.Entity;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace TimeTracker
{
    public partial class UsersPage : System.Web.UI.Page
    {
        UserRepository _userRepository = new UserRepository();
        int editIndex = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Users user = (Users)Session["User"];
            if (user.UserRole != 1)
            { 
                Response.Redirect("MainPage.aspx");
            }
            
            if (Page.IsPostBack)
            {
                return;
            }
            else
            {
                RefreshDataGrid();
            }
        }

        private void RefreshDataGrid()
        {
            try
            {
                GridViewUsers.DataSource = _userRepository.GetAll();
            }
            catch (NullReferenceException)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Invalid DataGridView population');</script>");
            }
            finally
            {
                GridViewUsers.DataBind();
            }

        }

        protected void GridViewUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lbl = (Label)GridViewUsers.Rows[e.RowIndex].FindControl("lblId");
            int id = Convert.ToInt32(lbl.Text);
            try
            {
                _userRepository.Delete(id);
                RefreshDataGrid();
            }
            catch (SqlException ex)
            {
                Response.Write("Exception occurred during deleting user");
                Response.Write(ex.Message);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void GridViewUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Users user = new Users();
            Users sessionUser = (Users)Session["User"];
            GridViewRow selectedRow = GridViewUsers.Rows[e.RowIndex];
            user.Id = (int)GridViewUsers.DataKeys[e.RowIndex].Value;
            TextBox tbFirstName = (TextBox)selectedRow.FindControl("tbFirstName");
            user.FirstName = tbFirstName.Text;
            TextBox tbLastName = (TextBox)selectedRow.FindControl("tbLastName");
            user.LastName = tbLastName.Text;
            TextBox tbMail = (TextBox)selectedRow.FindControl("tbMail");
            user.Mail = tbMail.Text;
            Label lblUserName = (Label)selectedRow.FindControl("lblUserName");
            user.UserName = lblUserName.Text;
            TextBox tbPassword = (TextBox)selectedRow.FindControl("tbPassword");
            user.Password = tbPassword.Text;
            TextBox tbPhoneNumber = (TextBox)selectedRow.FindControl("tbPhoneNumber");
            user.PhoneNumber = tbPhoneNumber.Text;
            DropDownList ddl = (DropDownList)selectedRow.FindControl("ddlRole");
            if (ddl.SelectedIndex != 0)
            {
                user.UserRole = Convert.ToInt32(ddl.SelectedItem.Value);
            }
            else
            {
                user.UserRole = _userRepository.GetUserRole(user.Id);
            }
            
            try
            {
                if (!_userRepository.ValidatePhoneNumber(user.PhoneNumber))
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Invalid phone number');</script>");
                }
                else if (_userRepository.Update(user) != 1)
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Invalid username');</script>");
                }
                else
                {

                    Response.Redirect("AdminsPage.aspx", false);
                }
            }
            catch (InvalidCastException ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Error! Invalid input.');</script>");
                Response.Write(ex.Message);
            }
            catch (SqlException ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Error occurred during (Update) operation.');</script>");
                Response.Write(ex.Message);
            }
            catch (Exception ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Error occurred during operation.');</script>");
                Response.Write(ex.Message);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            Users user = new Users();
            user.FirstName = tbFirstName.Text;
            user.LastName = tbLastName.Text;
            user.Mail = tbMail.Text;
            user.Password = tbPassword.Text;
            user.UserName = tbAccountName.Text;
            user.PhoneNumber = tbPhoneNumber.Text;
            try
            {
                if (! _userRepository.ValidatePhoneNumber(user.PhoneNumber))
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Invalid phone number');</script>");
                }
                else if (_userRepository.Insert(user) != 1)
                {
                    Response.Write("<script LANGUAGE='JavaScript' >alert('Invalid username');</script>");
                }
                else
                {
                    Response.Redirect("AdminsPage.aspx",false);
                }
            }
            catch (InvalidCastException ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Error! Invalid input.');</script>");
                Response.Write(ex.Message);
            }
            catch (SqlException ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Error occurred during (Insert) operation.');</script>");
                Response.Write(ex.Message);
            }
            catch (Exception ex)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Error occurred during operation.');</script>");
                Response.Write(ex.Message);
            }
        }

        protected void GridViewUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewUsers.EditIndex = e.NewEditIndex;
            editIndex = e.NewEditIndex;
            GridViewUsers.Columns[4].Visible = true;
            RefreshDataGrid();
        }

        protected void GridViewUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewUsers.EditIndex = -1;
            RefreshDataGrid();
        }

        protected void GridViewUsers_DataBound(object sender, EventArgs e)
        {
            if (GridViewUsers.EditIndex >= 0)
                return;
            GridViewUsers.Columns[4].Visible = false;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            tbAccountName.Text = "";
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbMail.Text = "";
            tbPassword.Text = "";
            tbPhoneNumber.Text = "";
        }

        protected void GridViewUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewUsers.PageIndex = e.NewPageIndex;
            RefreshDataGrid();
        }
    }
}