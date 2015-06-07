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
    public partial class UsersPage1 : System.Web.UI.Page
    {
        UserRepository _userRepository = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
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
                GridView.DataSource = _userRepository.GetAll();
            }
            catch (NullReferenceException)
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Invalid DataGridView population');</script>");
            }
            finally
            {
                GridView.DataBind();
            }

        }



        protected void GridView_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                if (e.Item.Cells[7].Text.Equals("1"))
                {
                    e.Item.Cells[7].Text = "Admin";
                }
                if (e.Item.Cells[7].Text.Equals("2"))
                {
                    e.Item.Cells[7].Text = "User";
                }
            }
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void GridView_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            GridView.CurrentPageIndex = e.NewPageIndex;
            RefreshDataGrid();
        }

    }
}