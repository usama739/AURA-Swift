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
    public partial class supplierSignup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Visible = false;
            Label3.Visible = false;
        }

        protected void btnSignupSeller_Click(object sender, EventArgs e)
        {
            String Fname = txtFName.Text;
            String Lname = txtLName.Text;
            String userName = txtUserName.Text;
            String city = txtCity.Text;
            String postalcode = txtPostalcode.Text;
            String Gender = ddlGender.Text;
            String country = txtCountry.Text;
            String phone = txtContact.Text;
            String email = txtEmail.Text;
            String password = txtPassword.Text;
            String companyName = txtCompanyname.Text;
            String shopAddress = txtAddress.Text;

            DataTable DT = new DataTable();

            signinDal objMyDal = new signinDal();
            int email_exists = 0;
            int userName_exists = 0;
            int found;

            found = objMyDal.insertUser_supplier(Fname, Lname, userName, city, postalcode, Gender, country, phone, email, password, companyName, shopAddress, ref DT, ref email_exists, ref userName_exists);
            string notifyTitle = "Welcome!";
            string message = "You have been successfully logged in. Happy shopping!";
            string notification = string.Format("?notifyTitle={0}&notificationDescription={1}", notifyTitle, message);
            if (email_exists > 0)
            {
                Label2.Text = Convert.ToString("Email Already exists");
                Label2.Visible = true;
            }
            if (userName_exists > 0)
            {
                Label3.Text = Convert.ToString("UserName Already exists");
                Label3.Visible = true;
            }

            if (found > 0)
            {
                if (CheckBox1.Checked == true)
                {
                    Response.Cookies["user"].Value = txtUserName.Text;
                    Response.Cookies["password"].Value = txtPassword.Text;
                    Response.Cookies["user"].Expires = DateTime.Now.AddDays(2);
                    Response.Cookies["password"].Expires = DateTime.Now.AddDays(2);

                }
                else
                {
                    Response.Cookies["user"].Expires = DateTime.Now.AddDays(-2);
                    Response.Cookies["password"].Expires = DateTime.Now.AddDays(-2);
                }
                Label1.Text = Convert.ToString("successfull");
                Label1.Visible = true;
                Session["user"] = txtUserName.Text;
                Response.Redirect("~/sellerprofile.aspx" + notification);
            }
            else
            {

                Label1.Visible = true;
            }
        }
    }
}