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
    public partial class searchresults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string product = Request.QueryString["id"].ToString();
                int id = Convert.ToInt32(product);
                if (id < 0)
                {
                    String keyword = Request.QueryString["keyword"].ToString();
                    String Ctype = Request.QueryString["Ctype"].ToString();
                    String City = Request.QueryString["City"].ToString();
                   
                    String Sprice = Request.QueryString["Sprice"].ToString();
                    String Eprice = Request.QueryString["Eprice"].ToString();
                   
                    searchresultsDAL productobj = new searchresultsDAL();
                    DataTable dt = productobj.filldatalist_filter(keyword, Ctype, City, Sprice, Eprice);
                    if (dt != null)
                    {
                        furniture_products.DataSource = dt;
                        furniture_products.DataBind();
                    }
                }
                else if(id==2)
                {
                    String keyword = Request.QueryString["keyword"].ToString();
                    searchresultsDAL productobj = new searchresultsDAL();
                    DataTable dt = productobj.filldatalist_category(keyword);
                    if (dt != null)
                    {
                        furniture_products.DataSource = dt;
                        furniture_products.DataBind();
                    }
                }

                //int id = Convert.ToInt32(product);
                else
                {
                    String keyword = Request.QueryString["keyword"].ToString();
                    //declare method
                    searchresultsDAL productobj = new searchresultsDAL();
                    DataTable dt = productobj.filldatalist(keyword);
                    if (dt != null)
                    {
                        furniture_products.DataSource = dt;
                        furniture_products.DataBind();
                    }
                }
               
            }
        }
        protected void view_product(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int product_id = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect("~/product.aspx?Product=" + product_id.ToString());
        }
    } 
}