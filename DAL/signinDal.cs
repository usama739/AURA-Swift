using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;


namespace AURA_Swift.DAL
{
    public class signinDal
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["AURA_SwiftConnection"].ConnectionString;

        public int SearchUser(String Name,String pass, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Search_Username_fromBuyer", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);
              
                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@Username"].Value = Name;
                
                cmd.Parameters["@Password"].Value = pass;


                cmd.ExecuteNonQuery();

                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds,"SearchUser");

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }
        public int SearchUserSupplier(String Name, String pass, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Search_Username_fromSupplier", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);

                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@Username"].Value = Name;

                cmd.Parameters["@Password"].Value = pass;


                cmd.ExecuteNonQuery();
                 // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }
        public int insertUser_buyer( String Fname, String Lname, String userName, String city, String postalcode, String Gender, String country, String phone, String email, String password, String CreditID , String Address, ref DataTable DT,ref int email_exits,ref int userName_exits )
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Buyer_SignupProcedure", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);

                cmd.Parameters.Add("@Fname", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@Lname", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@city", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@postalcode", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 7);
                cmd.Parameters.Add("@phone", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@CreditID", SqlDbType.VarChar, 30);
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@country", SqlDbType.VarChar, 20);
                


                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@email_Exists", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@userName_Exists", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@userName"].Value = userName;

                cmd.Parameters["@password"].Value = password;

                cmd.Parameters["@Fname"].Value = Fname;
                cmd.Parameters["@Lname"].Value = Lname;
                cmd.Parameters["@city"].Value = city;
                cmd.Parameters["@postalcode"].Value = postalcode;
                cmd.Parameters["@Gender"].Value = Gender;
                cmd.Parameters["@country"].Value = country;
                cmd.Parameters["@phone"].Value = phone;
                cmd.Parameters["@email"].Value = email;
                cmd.Parameters["@CreditID"].Value = CreditID;
                cmd.Parameters["@Address"].Value = Address;
                


                cmd.ExecuteNonQuery();

                // read output value 
                email_exits = Convert.ToInt32(cmd.Parameters["@email_Exists"].Value); //convert to output parameter to interger format
                userName_exits = Convert.ToInt32(cmd.Parameters["@userName_Exists"].Value); //convert to output parameter to interger format

                Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format

               

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                       // da.Fill(ds);

                    }

                  //  DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }
        public int insertUser_supplier(String Fname, String Lname, String userName, String city, String postalcode, String Gender, String country, String phone, String email, String password, String companyName, String shopAddress, ref DataTable DT, ref int email_exits, ref int userName_exits)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("supplier_SignupProcedure", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);

                cmd.Parameters.Add("@Fname", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@Lname", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@city", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@postalcode", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 7);
                cmd.Parameters.Add("@phone", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@companyName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@shopAddress", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@country", SqlDbType.VarChar, 20);


                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@email_Exists", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@userName_Exists", SqlDbType.Int).Direction = ParameterDirection.Output;
                // set parameter values
                cmd.Parameters["@userName"].Value = userName;

                cmd.Parameters["@password"].Value = password;

                cmd.Parameters["@Fname"].Value = Fname;
                cmd.Parameters["@Lname"].Value = Lname;
                cmd.Parameters["@city"].Value = city;
                cmd.Parameters["@postalcode"].Value = postalcode;
                cmd.Parameters["@Gender"].Value = Gender;
                cmd.Parameters["@country"].Value = country;
                cmd.Parameters["@phone"].Value = phone;
                cmd.Parameters["@email"].Value = email;
                cmd.Parameters["@companyName"].Value = companyName;
                cmd.Parameters["@shopAddress"].Value = shopAddress;


                cmd.ExecuteNonQuery();

                // read output value 
                email_exits = Convert.ToInt32(cmd.Parameters["@email_Exists"].Value); //convert to output parameter to interger format
                userName_exits = Convert.ToInt32(cmd.Parameters["@userName_Exists"].Value); //convert to output parameter to interger format

                Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                       // da.Fill(ds);

                    }

                    //DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return Found;

        }

        public int forgetPasswprd(String Name, String email, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("forget_password", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@userName", SqlDbType.VarChar, 20);

                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@userName"].Value = Name;

                cmd.Parameters["@email"].Value = email;


                cmd.ExecuteNonQuery();
                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    {
                        da.Fill(ds);

                    }

                    DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return Found;
        }
        public int ChangePasswprd(String Name, String pass, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Change_password", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@password", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@userName", SqlDbType.VarChar, 20);

                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@userName"].Value = Name;

                cmd.Parameters["@password"].Value = pass;


                cmd.ExecuteNonQuery();
                // read output value 
                Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    //using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    //{
                    //    da.Fill(ds);

                    //}

                    //DT = ds.Tables[0];

                }


                con.Close();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }
            return Found;
        }

        //public int Activation(String email, ref String code)
        //{

        //    int Found = 0;
        //    DataSet ds = new DataSet();
        //    SqlConnection con = new SqlConnection(connString);
        //    con.Open();
        //    SqlCommand cmd;
        //    try
        //    {
        //        cmd = new SqlCommand("ActivationCode", con); //name of your procedure
        //        cmd.CommandType = CommandType.StoredProcedure;


        //        cmd.Parameters.Add("@email", SqlDbType.VarChar, 50);



        //        cmd.Parameters.Add("@code", SqlDbType.Int).Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;

        //        set parameter values


        //        cmd.Parameters["@email"].Value = email;



        //        cmd.ExecuteNonQuery();

        //        read output value

        //       Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format
        //        code = Convert.ToString(cmd.Parameters["@code"].Value);
        //        if (Found == 1)
        //        {
        //            using (SqlDataAdapter da = new SqlDataAdapter(cmd))

        //            {
        //                da.Fill(ds);

        //            }

        //            DT = ds.Tables[0];

        //        }


        //        con.Close();


        //    }
        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine("SQL Error" + ex.Message.ToString());

        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //  return Found;

        //}
    }
   
}