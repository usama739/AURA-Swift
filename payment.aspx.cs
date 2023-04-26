using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AURA_Swift.DAL;

namespace AURA_Swift
{
    public partial class payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/signin.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    String price = Request.QueryString["Tprice"];
                    txtAmount.Text = price;
                }
            }
        }
        protected void pay_Click(object sender, EventArgs e)
        {
            String Name = Session["user"].ToString();
            cartDal myobj = new cartDal();
            int found = myobj.payment_pay(Name);
            if (found == 1)
            {

            }
        }

    }
}