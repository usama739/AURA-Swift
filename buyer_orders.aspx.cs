using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AURA_Swift.DAL;
using System.Data;
using System.IO;

namespace AURA_Swift
{
    public partial class buyer_orders : System.Web.UI.Page
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
                    string username = Session["user"].ToString();
                    DataTable DT = new DataTable();
                    searchresultsDAL objMyDal = new searchresultsDAL();

                    DT = objMyDal.filldatalist_for_buyer_orders(username);
                    if (DT != null)
                    {
                        buyer_orders_datalist.DataSource = DT;
                        buyer_orders_datalist.DataBind();
                    }

                }

            }
        }
    }
}