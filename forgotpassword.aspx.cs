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
    public partial class forgotpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            txtAgainPassword.Visible = false;
            txtPassword.Visible = false;
            btnChangePass.Visible = false;
            btnPasswordRecover.Visible = true;
        }

        protected void btnPasswordRecover_Click(object sender, EventArgs e)
        {

            String Name = txtUserName.Text;
            String email = txtEmail.Text;
            DataTable DT = new DataTable();

            signinDal objMyDal = new signinDal();

            int found;

            found = objMyDal.forgetPasswprd(Name, email, ref DT);


            if (found > 0)
            {

                lblError.Text = Convert.ToString("successfull");
                lblError.Visible = true;

                txtPassword.Visible = true;
                txtAgainPassword.Visible = true;
                btnPasswordRecover.Visible = false;
                btnChangePass.Visible = true;
            }
            else
            {

                lblError.Visible = true;
                lblError.Text = Convert.ToString("Incorrect Username or Email");
            }

        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            String Name = txtUserName.Text;
            String pass = txtPassword.Text;

            DataTable DT = new DataTable();

            signinDal objMyDal = new signinDal();

            int found;

            found = objMyDal.ChangePasswprd(Name, pass, ref DT);


            if (found > 0)
            {

                lblError.Text = Convert.ToString("successfull");
                lblError.Visible = true;

                Response.Redirect("~/signin.aspx");
            }
            else
            {

            }
        }
    }
}