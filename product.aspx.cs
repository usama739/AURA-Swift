using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AURA_Swift.DAL;
using System.Data;
//using AjaxControlToolkit;
namespace AURA_Swift
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (!IsPostBack)
            {
                lblError.Visible = false;
                string product = Request.QueryString["Product"].ToString();
                int productid = Convert.ToInt32(product);
                //declare method

                searchresultsDAL productobj = new searchresultsDAL();
                DataTable dt = productobj.display_product(productid);
                if (dt != null)
                {
                    display_product.DataSource = dt;
                    display_product.DataBind();
                }
            }
        }
        protected void Addcart_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/signin.aspx");
            }
            Button btn = sender as Button;
            int product_id = Convert.ToInt32(btn.CommandArgument);
            String userName = Session["user"].ToString();
            cartDal myobj = new cartDal();

            int found = myobj.Addproduct_to_cart(product_id, userName);
            if (found == 0)
            {
                lblError.Visible = true;
            }
            else
            {
                lblError.Text = "Product add to cart successfully";
                lblError.Visible = true;
            }

        }
        /*protected void Rating_product(object sender, RatingEventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/signin.aspx");
            }

            string product = Request.QueryString["Product"].ToString();
            int productid = Convert.ToInt32(product);
            String username = Session["user"].ToString();
            int Starts = Int16.Parse(e.Value.ToString());
            searchresultsDAL myobj = new searchresultsDAL();

            int found = myobj.Rating_for_product(productid, Starts, username);
            if (found == 1)
            {

            }
        }*/

    }
}
