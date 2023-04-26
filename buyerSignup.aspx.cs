using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AURA_Swift.DAL;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace AURA_Swift
{
    public partial class buyerSignup : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Visible = false;
            Label3.Visible = false;
        }

        protected void btnSignupBuyer_Click(object sender, EventArgs e)
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
            String CreditID = txtCreditId.Text;
            String Address = txtAddress.Text;
            int email_exists = 0;
            int userName_exists = 0;
            DataTable DT = new DataTable();

            signinDal objMyDal = new signinDal();

            int found;

            found = objMyDal.insertUser_buyer(Fname, Lname, userName, city, postalcode, Gender, country, phone, email, password, CreditID, Address, ref DT, ref email_exists, ref userName_exists);


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
                lblError.Text = Convert.ToString("successfull");
                lblError.Visible = true;
                Session["user"] = txtUserName.Text;
                Response.Redirect("~/buyerPage.aspx");
            }
            else
            {
                lblError.Text = Convert.ToString("User Already exists");
                lblError.Visible = true;
            }

        }
        //private void sendcode()
        //{
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.gmail.com";
        //    smtp.Port = 587;
        //    smtp.Credentials = new System.Net.NetworkCredential("muhammadburhansheikh31@gmail.com", "burhan32");
        //    MailMessage msg = new MailMessage();
        //    msg.Subject = "Activation Code To verify Email Address";
        //    msg.Body = "Dear " + txtUserName + ", Your activation code is : " + activationcode + "\n\n";
        //    string reciver = txtEmail.Text;
        //    msg.To.Add(reciver);
        //    string sender = "muhammadburhansheikh31 @gmail.com";
        //    msg.From = new MailAddress(sender);
        //    try
        //    {
        //        smtp.Send(msg);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
}
