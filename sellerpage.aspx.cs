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
    public partial class sellerpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/signin.aspx");
            }

            else
            {
                String Name = Session["user"].ToString();
                buyerProfileDal myobj = new buyerProfileDal();
                int found = myobj.user_type(Name);
                if (found == 1)
                {
                    Response.Redirect("~/buyerPage.aspx");
                }
            }

            if (!IsPostBack)
            {
                String FName = "", Lname = "";
                String Name = Session["user"].ToString();
                int orders = 0;
                int sale = 0;
                DataTable DT = new DataTable();

                buyerProfileDal objMyDal = new buyerProfileDal();

                int found;

                found = objMyDal.SearchUser_sellerPage(Name, ref FName, ref Lname, ref orders, ref sale);

                fullnamedisplay.Text = FName + " " + Lname;
                usernamedisplay.Text = Name;
                totalorders.Text = orders.ToString();
                totalrevenue.Text = sale.ToString();


            }

            //{
            //    Response.Write("Welcome!" + Session["user"].ToString() + " You have been successfully logged in ");
            //}

        }


        protected void logout_Click(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Session.Abandon();
                Session["user"] = null;
                Session.Remove("user");
                Response.Redirect("~/signin.aspx");
            }
        }

        protected void order_page(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("~/seller_orders.aspx");
            }
        }

        protected void hlListProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/listproducts.aspx");
        }
    }   
}