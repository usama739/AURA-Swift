using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace AURA_Swift.DAL
{
    public class cartDal
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["AURA_SwiftConnection"].ConnectionString;

        public int Addproduct_to_cart(int ProductID, String username)
        {
            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("add_To_cart", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@username", SqlDbType.VarChar, 20);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int);

                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;



                cmd.Parameters["@ProductID"].Value = ProductID;
                cmd.Parameters["@username"].Value = username;


                //cmd.Parameters["@Password"].Value = pass;

                if (cmd.ExecuteNonQuery() == -1)
                {

                }

                // read output value 

                Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    //using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    //{
                    //    da.Fill(ds, "SearchUser");

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
        public int remove_product(int ProductID, String username)
        {
            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Remove_product_cart", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@username", SqlDbType.VarChar, 20);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int);
             

                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;



                cmd.Parameters["@ProductID"].Value = ProductID;
                cmd.Parameters["@username"].Value = username;
               

                //cmd.Parameters["@Password"].Value = pass;

                if (cmd.ExecuteNonQuery() == -1)
                {

                }

                // read output value 

                Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    //using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    //{
                    //    da.Fill(ds, "SearchUser");

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
        public int update_productUnits(int ProductID, String username, int Quantity)
        {
            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("update_productUnits_cart", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@username", SqlDbType.VarChar, 20);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int);
                cmd.Parameters.Add("@Quantity", SqlDbType.Int);

                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;



                cmd.Parameters["@ProductID"].Value = ProductID;
                cmd.Parameters["@username"].Value = username;
                cmd.Parameters["@Quantity"].Value = Quantity;

                //cmd.Parameters["@Password"].Value = pass;

                if (cmd.ExecuteNonQuery() == -1)
                {

                }

                // read output value 

                Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    //using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    //{
                    //    da.Fill(ds, "SearchUser");

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
        public int cart_price(String username, ref int Tprice)
        {
            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("cart_price", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@username", SqlDbType.VarChar, 20);

                cmd.Parameters.Add("@Tprice", SqlDbType.Int).Direction = ParameterDirection.Output;


                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;



                
                cmd.Parameters["@username"].Value = username;


                //cmd.Parameters["@Password"].Value = pass;

                if (cmd.ExecuteNonQuery() == -1)
                {

                }

                // read output value 

                Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format
                Tprice = Convert.ToInt32(cmd.Parameters["@Tprice"].Value); //convert to output parameter to interger format

                if (Found == 1)
                {
                    //using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    //{
                    //    da.Fill(ds, "SearchUser");

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
        public int payment_pay(String username)
        {
            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("SellerBuyer_order", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@userName", SqlDbType.VarChar, 20);

                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;



                cmd.Parameters["@userName"].Value = username;


                //cmd.Parameters["@Password"].Value = pass;

                if (cmd.ExecuteNonQuery() == -1)
                {

                }

                // read output value 

                Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format
               
                if (Found == 1)
                {
                    //using (SqlDataAdapter da = new SqlDataAdapter(cmd))

                    //{
                    //    da.Fill(ds, "SearchUser");

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
    }
}