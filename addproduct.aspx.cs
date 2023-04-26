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
    public partial class addproduct : System.Web.UI.Page
    {
        System.Guid guid = System.Guid.NewGuid();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/signin.aspx");
            }
            else
            {
                lblStatus.Visible = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            String ProductName = txtName.Text;
            String ProductDescription = txtDescription.Text;
            String userName = Session["user"].ToString();
            String categorytype = ddlCategory.Text;
            String UnitPrice = txtPrice.Text;
            String AvailableColor = txtAvailableColors.Text;
            String UnitWeight = txtWeight.Text;
            String picture = Check_ImageUpload();
            String AvailableUnit = txtUnit.Text;
            addProduct objMyDal = new addProduct();

            int found;

            found = objMyDal.add_Product(ProductName, ProductDescription, userName, categorytype, UnitPrice, AvailableColor, UnitWeight, picture, AvailableUnit);
            if (found == 1)
            {
                lblStatus.Visible = true;
            }
            else
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Product not add";
            }
        }
        private string Check_ImageUpload()
        {
            string SavePath = "";

            // if a file was uploaded
            if (flImageUpload.HasFile)
            {
                string extension = System.IO.Path.GetExtension(flImageUpload.FileName);

                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                {
                    // Save Path
                    string path = Server.MapPath("SellerProducts\\");

                    string imageName = guid.ToString() + flImageUpload.FileName;
                    // Save Image
                    flImageUpload.SaveAs(path + imageName);

                    SavePath = "SellerProducts\\" + imageName;
                }
                else
                {
                    Response.Write("<script> alert('Please upload a valid image!'); </script>");
                }
            }

            return SavePath;
        }
    }
}