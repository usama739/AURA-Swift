using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using AURA_Swift.DAL;
using System.Data;
namespace AURA_Swift
{
    public partial class seller_orders : System.Web.UI.Page
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



                    DT = objMyDal.filldatalist_for_seller_orders(username);
                    if (DT != null)
                    {
                        seller_orders_datalist.DataSource = DT;
                        seller_orders_datalist.DataBind();
                    }

                }


            }
        }

        protected void editstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList l1 = sender as DropDownList;
            String status = l1.SelectedItem.Text;
            int orderid = Int16.Parse(l1.DataMember);
            searchresultsDAL myobj = new searchresultsDAL();
            myobj.update_status(orderid, status);
        }

        protected void seller_orders_datalist_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {



                DataRowView row = (DataRowView)e.Item.DataItem;

                DropDownList StatusLabelSelected = (DropDownList)e.Item.FindControl("editstatus");

                int Value = 0;

                if (row["Statement"].ToString() == "pending")
                {
                    Value = 1;
                }
                else if (row["Statement"].ToString() == "left warehouse")
                {
                    Value = 2;
                }
                else if (row["Statement"].ToString() == "delivered")
                {
                    Value = 3;
                }

                StatusLabelSelected.SelectedValue = Value.ToString();

            }
        }
    }
}