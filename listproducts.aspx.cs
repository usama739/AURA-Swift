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
    public partial class listproducts : System.Web.UI.Page
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
                    String username = Session["user"].ToString();

                    DataTable DT = new DataTable();

                    searchresultsDAL objMyDal = new searchresultsDAL();



                    DT = objMyDal.filldatalist_for_sellerlistproducts(username);
                    if (DT != null)
                    {
                        supplier_products.DataSource = DT;
                        supplier_products.DataBind();
                    }

                }
            }

        }
        protected void EditProduct_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            int ProductID = Convert.ToInt32(btn.CommandArgument);

            Response.Redirect("~/EditProduct.aspx?Product=" + ProductID.ToString());
        }
        protected void DeleteProduct_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            int PID = Convert.ToInt32(btn.CommandArgument);
            String ProductID = PID.ToString();

            string SavePath = "";
            addProduct objMyDal = new addProduct();
            string PrevPicture = "";
            objMyDal.get_Product_pic(ref ProductID, ref PrevPicture);
            // if a file was uploaded
            if (PrevPicture != "" && PrevPicture != "images\\Default.png")
            {
                string path = Server.MapPath(PrevPicture);
                FileInfo file = new FileInfo(path);

                if (file.Exists)//check file exsit or not  
                {
                    file.Delete();
                }

            }
            objMyDal.Delete_product(ProductID);
            // Response.Redirect("~/EditProduct.aspx?Product=" + ProductID.ToString());
            Page_Load(sender, e);
        }

    }
}