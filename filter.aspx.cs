using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AURA_Swift
{
    public partial class filter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void filter_Click(object sender, EventArgs e)
        {
            int id = -1;
            String keyword = txtkeyword.Text;
            String Ctype = ddlCatogryType.SelectedValue;
            String City = ddlCity.Text;

            String Sprice = txtSprice.Text;
            String Eprice = txtEprice.Text;

            Response.Redirect("~/searchresults.aspx?id=" + id.ToString() + "&keyword=" + keyword + "&Ctype=" + Ctype + "&City=" + City + "&Sprice=" + Sprice + "&Eprice=" + Eprice);

        }
    }
}