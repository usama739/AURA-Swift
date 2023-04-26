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

    public partial class buyerPage : System.Web.UI.Page
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
                    String FName = "", Lname = "";
                    String Name = Session["user"].ToString();
                    DataTable DT = new DataTable();

                    buyerProfileDal objMyDal = new buyerProfileDal();

                    int found;

                    found = objMyDal.SearchUser_buyerPage(Name, ref FName, ref Lname);

                    fullnamedisplay.Text = FName + " " + Lname;
                    usernamedisplay.Text = Name;


                }
            }

            //{
            //    Response.Write("Welcome!" + Session["user"].ToString() + " You have been successfully logged in ");
            //}

        }
        protected void order_page(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("~/buyer_orders.aspx");
            }
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
    }
  }
