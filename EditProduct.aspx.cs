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
    public partial class EditProduct : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    string ProductID = Request.QueryString["Product"].ToString();
                    //int ProductID = Int16.Parse(Sid);
                    String ProductName = "";
                    String ProductDescription = "";

                    String categorytype = "";
                    String UnitPrice = "";
                    String AvailableColor = "";
                    String UnitWeight = "";
                    String picture = "";
                    String AvailableUnit = "";
                    addProduct objMyDal = new addProduct();


                    objMyDal.Show_Product(ref ProductID, ref ProductName, ref ProductDescription, ref categorytype, ref UnitPrice, ref AvailableColor, ref UnitWeight, ref picture, ref AvailableUnit);

                    txtName.Text = ProductName;
                    txtDescription.Text = ProductDescription;

                    ddlCategory.Text = categorytype;
                    txtPrice.Text = UnitPrice;
                    txtAvailableColors.Text = AvailableColor;
                    txtWeight.Text = UnitWeight;

                    txtUnit.Text = AvailableUnit;
                }
            }
        }
        protected void UpdateProduct_Click(object sender, EventArgs e)
        {
            String ProductID = Request.QueryString["Product"].ToString();
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

            found = objMyDal.update_product(ref ProductID, ref ProductName, ref ProductDescription, ref categorytype, ref UnitPrice, ref AvailableColor, ref UnitWeight, ref picture, ref AvailableUnit);
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
            string ProductID = Request.QueryString["Product"].ToString();
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