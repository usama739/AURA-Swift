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
    public partial class signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["user"] != null)
                {
                    txtUserName.Text = Request.Cookies["user"].Value;
                }
                if (Request.Cookies["password"] != null)
                {
                    txtPassword.Attributes.Add("value", Request.Cookies["password"].Value);

                }
                if (Request.Cookies["user"] != null && Request.Cookies["password"] != null)
                {
                    CheckBox1.Checked = true;
                }
            }
        }
        protected void SigninBuyer(object sender, EventArgs e)
        {

            String Name = txtUserName.Text;
            String pass = txtPassword.Text;
            DataTable DT = new DataTable();

            signinDal objMyDal = new signinDal();

            int found;

            found = objMyDal.SearchUser(Name, pass, ref DT);


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
                Response.Redirect("~/buyerpage.aspx");
            }
            else
            {

                lblError.Visible = true;
            }

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnLoginSeller_Click(object sender, EventArgs e)
        {
            String Name = txtUserName.Text;
            String pass = txtPassword.Text;
            DataTable DT = new DataTable();

            signinDal objMyDal = new signinDal();

            int found;

            found = objMyDal.SearchUserSupplier(Name, pass, ref DT);
            string notifyTitle = "Welcome!";
            string message = "You have been successfully logged in. Happy shopping!";
            string notification = string.Format("?notifyTitle={0}&notificationDescription={1}", notifyTitle, message);


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
                Response.Redirect("~/sellerpage.aspx" + notification);
            }
            else
            {

                lblError.Visible = true;
            }
        }

    }
}