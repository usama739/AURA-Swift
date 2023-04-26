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
    public partial class buyerprofile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/signin.aspx");
            }
            else
            {
                Label2.Visible = false;
                Label3.Visible = false;
                lblError.Visible = false;
                if (!IsPostBack)
                {
                    String Fname = "";
                    String Lname = "";
                    String userName = Session["user"].ToString();
                    String city = "";
                    String postalcode = "";
                    String Gender = "";
                    String country = "";
                    String phone = "";
                    String email = "";

                    String CreditID = "";
                    String Address = "";

                    DataTable DT = new DataTable();

                    buyerProfileDal objMyDal = new buyerProfileDal();

                    int found;

                    found = objMyDal.insertProfile_buyer(ref Fname, ref Lname, ref userName, ref city, ref postalcode, ref Gender, ref country, ref phone, ref email, ref CreditID, ref Address, ref DT);

                    txtFName.Text = Fname;
                    txtLName.Text = Lname;
                    txtUserName.Text = userName;
                    txtCity.Text = city;
                    txtPostalcode.Text = postalcode;
                    ddlGender.Text = Gender;
                    txtCountry.Text = country;
                    txtContact.Text = phone;
                    txtEmail.Text = email;
                    txtCreditId.Text = CreditID;
                    txtAddress.Text = Address;

                }
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
        protected void order_page(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("~/buyer_orders.aspx");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
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
            String olduserName = Session["user"].ToString();
            String CreditID = txtCreditId.Text;
            String Address = txtAddress.Text;
            int email_exists = 0;
            int userName_exists = 0;
            DataTable DT = new DataTable();

            buyerProfileDal objMyDal = new buyerProfileDal();

            int found;

            found = objMyDal.updateUser_buyer(ref Fname, ref Lname, ref userName, ref olduserName, ref city, ref postalcode, ref Gender, ref country, ref phone, ref email, ref CreditID, ref Address, ref DT, ref email_exists, ref userName_exists);


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

                txtFName.Text = Fname;
                txtLName.Text = Lname;
                txtUserName.Text = userName;
                txtCity.Text = city;
                txtPostalcode.Text = postalcode;
                ddlGender.Text = Gender;
                txtCountry.Text = country;
                txtContact.Text = phone;
                txtEmail.Text = email;
                txtCreditId.Text = CreditID;
                txtAddress.Text = Address;

                lblError.Text = Convert.ToString("Update Successfull");
                lblError.Visible = true;
                Session["user"] = txtUserName.Text;


            }
            else
            {
                lblError.Text = Convert.ToString("Update Fail");
                lblError.Visible = true;
            }
        }
    }
}