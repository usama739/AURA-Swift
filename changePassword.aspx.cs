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
    public partial class changePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            String Name = Session["user"].ToString();
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