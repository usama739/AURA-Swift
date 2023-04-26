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
    public partial class cart : System.Web.UI.Page
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
                    String userName = Session["user"].ToString();
                    DataTable DT = new DataTable();
                    searchresultsDAL objMyDal = new searchresultsDAL();



                    DT = objMyDal.filldatalist_from_cart(userName);
                    if (DT != null)
                    {
                        cart_products.DataSource = DT;
                        cart_products.DataBind();
                    }

                    int Tprice = 0;
                    cartDal myobj = new cartDal();
                    int found = myobj.cart_price(userName, ref Tprice);
                    txttotal.Text = Tprice.ToString();
                    if (found == 1)
                    {

                    }
                }
            }


        }
        protected void updateUnits_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            String[] commandArgs = btn.CommandArgument.ToString().Split(new char[] { ',' });
            String product_id = commandArgs[0];
            String Quantity = commandArgs[1];
            String MaxQuantity = commandArgs[2];

            Response.Redirect("~/UpdateUnits.aspx?ProductID=" + product_id + "&Quantity=" + Quantity + "&Max=" + MaxQuantity);
        }
        protected void removeProduct_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            String product_id = btn.CommandArgument.ToString();
            String username = Session["user"].ToString();
            cartDal myobj = new cartDal();
            int found = myobj.remove_product(Convert.ToInt32(product_id), username);
            if (found > 0)
            {

            }
        }
        protected void checkout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/payment?Tprice=" + txttotal.Text);
        }

    }
}