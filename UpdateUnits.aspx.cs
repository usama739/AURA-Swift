using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AURA_Swift.DAL;
using System.Data;

namespace AURA_Swift
{
    public partial class UpdateUnits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/signin.aspx");
            }
            else
            {
                lblError.Visible = false;
                if (!IsPostBack)
                {
                    String maxQ = Request.QueryString["Max"].ToString();
                    txtMaxUits.Text = maxQ;
                }
            }
        }
        protected void submit_click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtUits.Text)> Convert.ToInt32(txtMaxUits.Text))
            {
                lblError.Visible = true;
            }
            else
            {
                String ProductID = Request.QueryString["ProductID"].ToString();
                String username = Session["user"].ToString();
                String Quantity = txtUits.Text;
                cartDal myobj = new cartDal();
                int found=myobj.update_productUnits(Convert.ToInt32(ProductID), username, Convert.ToInt32( Quantity));
            if(found==0)
                {
                    lblError.Visible = true;
                }
            else
                {
                    lblError.Visible = true;
                    lblError.Text = "Update Successfull";
                    Response.Redirect("~/mycart.aspx");
                }
            }
        }
        
    }
}