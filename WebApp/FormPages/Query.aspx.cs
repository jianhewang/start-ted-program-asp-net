using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Addtional Namespace
using StarTEDSystem.Entities;
using StarTEDSystem.BLL;
#endregion

namespace WebApp.FormPages
{
    public partial class Query : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
           
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            Message.Text = "";

            if (string.IsNullOrEmpty(ProgramSearch.Text.Trim()))
            {
                Message.Text = "Search value cannot be empty";
            }
        }
    }
}