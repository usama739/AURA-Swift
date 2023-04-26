using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace AURA_Swift.DAL
{
    public class buyerProfileDal
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["AURA_SwiftConnection"].ConnectionString;

        public int SearchUser_buyerPage(String Name, ref String Fname, ref String Lname)
        {

            int Found = 0;
            DataSet ds;
            ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("ProfilePage_Procedure", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20);
                

                cmd.Parameters.Add("@Fname", SqlDbType.VarChar,20).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Lname", SqlDbType.VarChar,20).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@Username"].Value = Name;

                //cmd.Parameters["@Password"].Value = pass;


                cmd.ExecuteNonQuery();

                // read output value 
                //Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format
               Fname = Convert.ToString( cmd.Parameters["@Fname"].Value); //convert to output parameter to interger format
               Lname = Convert.ToString(cmd.Parameters["@Lname"].Value); //convert to output parameter to interger format

               
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
        public int SearchUser_sellerPage(String Name, ref String Fname, ref String Lname,ref int Orders,ref int sale)
        {

            int Found = 0;
            DataSet ds;
            ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("ProfilePage_Procedure_seller", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@userName", SqlDbType.VarChar, 20);


                cmd.Parameters.Add("@Fname", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Lname", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@Orders", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@sale", SqlDbType.Int).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@Username"].Value = Name;

                //cmd.Parameters["@Password"].Value = pass;


                cmd.ExecuteNonQuery();

                // read output value 
                Orders = Convert.ToInt32(cmd.Parameters["@Orders"].Value);
                sale = Convert.ToInt32(cmd.Parameters["@sale"].Value); //convert to output parameter to interger format
                Fname = Convert.ToString(cmd.Parameters["@Fname"].Value); //convert to output parameter to interger format
                Lname = Convert.ToString(cmd.Parameters["@Lname"].Value); //convert to output parameter to interger format               

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

        public int insertProfile_buyer(ref String Fname, ref String Lname, ref String userName, ref String city, ref String postalcode, ref String Gender, ref String country, ref String phone, ref String email, ref String CreditID, ref String Address, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("BuyerProfile_input_Procedure", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20);
               

                cmd.Parameters.Add("@Fname", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output; ;
                cmd.Parameters.Add("@Lname", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@city", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@postalcode", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 7).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@phone", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CreditID", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@country", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                          

                // set parameter values
                cmd.Parameters["@userName"].Value = userName;
                
                cmd.ExecuteNonQuery();

                // read output value 

                Fname = Convert.ToString(cmd.Parameters["@Fname"].Value); //convert to output parameter to interger format
                Lname = Convert.ToString(cmd.Parameters["@Lname"].Value); //convert to output parameter to interger format
                city = Convert.ToString(cmd.Parameters["@city"].Value); //convert to output parameter to interger format
                postalcode = Convert.ToString(cmd.Parameters["@postalcode"].Value); //convert to output parameter to interger format
                Gender = Convert.ToString(cmd.Parameters["@Gender"].Value); //convert to output parameter to interger format
                phone = Convert.ToString(cmd.Parameters["@phone"].Value); //convert to output parameter to interger format
                email = Convert.ToString(cmd.Parameters["@email"].Value); //convert to output parameter to interger format
                CreditID = Convert.ToString(cmd.Parameters["@CreditID"].Value); //convert to output parameter to interger format
                Address = Convert.ToString(cmd.Parameters["@Address"].Value); //convert to output parameter to interger format
                country = Convert.ToString(cmd.Parameters["@country"].Value); //convert to output parameter to interger format


                //if (Found == 1)
                //{
                //    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                //    {
                //        // da.Fill(ds);

                //    }

                //    //  DT = ds.Tables[0];

                //}


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
        public int insertProfile_supplier(ref String Fname, ref String Lname, ref String userName, ref String city, ref String postalcode, ref String Gender, ref String country, ref String phone, ref String email, ref String companyName, ref String shopAddress, ref DataTable DT)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SupplierProfile_input_Procedure", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 20);


                cmd.Parameters.Add("@Fname", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output; ;
                cmd.Parameters.Add("@Lname", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@city", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@postalcode", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 7).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@phone", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@companyName", SqlDbType.VarChar, 30).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@shopAddress", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@country", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;

                // set parameter values
                cmd.Parameters["@userName"].Value = userName;
                cmd.ExecuteNonQuery();

                // read output value 
                Fname = Convert.ToString(cmd.Parameters["@Fname"].Value); //convert to output parameter to interger format
                Lname = Convert.ToString(cmd.Parameters["@Lname"].Value); //convert to output parameter to interger format
                city = Convert.ToString(cmd.Parameters["@city"].Value); //convert to output parameter to interger format
                postalcode = Convert.ToString(cmd.Parameters["@postalcode"].Value); //convert to output parameter to interger format
                Gender = Convert.ToString(cmd.Parameters["@Gender"].Value); //convert to output parameter to interger format
                phone = Convert.ToString(cmd.Parameters["@phone"].Value); //convert to output parameter to interger format
                email = Convert.ToString(cmd.Parameters["@email"].Value); //convert to output parameter to interger format
                companyName = Convert.ToString(cmd.Parameters["@companyName"].Value); //convert to output parameter to interger format
                shopAddress = Convert.ToString(cmd.Parameters["@shopAddress"].Value); //convert to output parameter to interger format
                country = Convert.ToString(cmd.Parameters["@country"].Value); //convert to output parameter to interger format



                //if (Found == 1)
                //{
                //    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                //    {
                //        // da.Fill(ds);

                //    }

                //    //  DT = ds.Tables[0];

                //}


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
        public int updateUser_buyer(ref String Fname, ref String Lname, ref String userName, ref String olduserName, ref String city, ref String postalcode, ref String Gender, ref String country, ref String phone, ref String email, ref String CreditID, ref String Address, ref DataTable DT, ref int email_exits, ref int userName_exits)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("buyerProfile_update_Procedure", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Fname", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@Lname", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@userName", SqlDbType.VarChar, 20);

                cmd.Parameters.Add("@olduserName", SqlDbType.VarChar, 20);
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

                cmd.Parameters["@olduserName"].Value = olduserName;

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
        public int updateUser_supplier(ref String Fname, ref String Lname, ref String userName, ref String olduserName, ref String city, ref String postalcode, ref String Gender, ref String country, ref String phone, ref String email, ref String companyName, ref String Address, ref DataTable DT, ref int email_exits, ref int userName_exits)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("supplierProfile_update_Procedure", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Fname", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@Lname", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@userName", SqlDbType.VarChar, 20);

                cmd.Parameters.Add("@olduserName", SqlDbType.VarChar, 20);
            
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

                cmd.Parameters["@olduserName"].Value = olduserName;

                cmd.Parameters["@Fname"].Value = Fname;
                cmd.Parameters["@Lname"].Value = Lname;
                cmd.Parameters["@city"].Value = city;
                cmd.Parameters["@postalcode"].Value = postalcode;
                cmd.Parameters["@Gender"].Value = Gender;
                cmd.Parameters["@country"].Value = country;
                cmd.Parameters["@phone"].Value = phone;
                cmd.Parameters["@email"].Value = email;
                cmd.Parameters["@companyName"].Value = companyName;
                cmd.Parameters["@shopAddress"].Value = Address;



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
        public int user_type(String Name)
        {

            int Found = 0;
            DataSet ds;
            ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("check_userType", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@userName", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;



                // set parameter values
                cmd.Parameters["@Username"].Value = Name;

                //cmd.Parameters["@Password"].Value = pass;


                cmd.ExecuteNonQuery();

                // read output value 
                
                Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format

                //if (Found == 1)
                //{
                //    using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                //    {
                //        da.Fill(ds, "SearchUser");

                //    }

                //    DT = ds.Tables[0];

                //}


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
    }
}