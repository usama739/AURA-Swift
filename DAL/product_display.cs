using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace AURA_Swift.DAL
{
    public partial class searchresultsDAL
    {

        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["AURA_SwiftConnection"].ConnectionString;

        public DataTable filldatalist_for_seller_orders(string username)
        {
            DataTable dt;
            dt = null;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("get_seller_orders", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@input_username", SqlDbType.VarChar, 20);
                cmd.Parameters["@input_username"].Value = username;
                //con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch(SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }

            return dt;

        }

        public DataTable filldatalist_for_buyer_orders(string username)
        {
            DataTable dt;
            dt = null;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("get_buyer_orders", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@input_username", SqlDbType.VarChar, 20);
                cmd.Parameters["@input_username"].Value = username;
                //con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }

            return dt;

        }
        public DataTable display_product(int pid)
        {
            DataTable dt;
            dt = null;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            
            try
            {
                cmd = new SqlCommand("get_product", con);
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.Add("@input_productid", SqlDbType.Int);
                cmd.Parameters["@input_productid"].Value = pid;
                //con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable(); 
                da.Fill(dt);
            }
            finally
            {
                con.Close();
            }

            return dt;

        }
        public DataTable filldatalist(String keyword)
        {
            DataTable dt;
            dt = null;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            SqlDataAdapter da ;
            try
            {
                if (keyword != "")
                {
                    cmd = new SqlCommand("get_searched_products", con);
                    cmd.Parameters.Add("@input_searchedword", SqlDbType.VarChar, 200);
                    cmd.Parameters["@input_searchedword"].Value = keyword;
                    cmd.CommandType = CommandType.StoredProcedure; ;

                    //con.Open();
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                }
            }
            finally
            {
                con.Close();
            }

            return dt;

        }
        public DataTable filldatalist_category(String keyword)
        {
            DataTable dt;
            dt = null;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            SqlDataAdapter da;
            try
            {
                if (keyword != "")
                {
                    cmd = new SqlCommand("get_category_products", con);
                    cmd.Parameters.Add("@input_keyword", SqlDbType.VarChar, 50);
                    cmd.Parameters["@input_keyword"].Value = keyword;
                    cmd.CommandType = CommandType.StoredProcedure; ;

                    //con.Open();
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                }
            }
            finally
            {
                con.Close();
            }

            return dt;

        }
        public DataTable filldatalist_filter(String keyword,String Ctype,String city,String Sprice,String Eprice)
        {
            DataTable dt = null;
            dt = null;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("sFILTERED", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@KEYWORD", SqlDbType.VarChar, 40);
          
                cmd.Parameters.Add("@TYPE", SqlDbType.VarChar, 40);
              
                cmd.Parameters.Add("@CITY", SqlDbType.VarChar, 40);
    


                
                cmd.Parameters.Add("@STARTINGPRICE", SqlDbType.Int);
           
                cmd.Parameters.Add("@ENDINGPRICE", SqlDbType.Int);
              
                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;
                
                if(Sprice=="")
                {
                    Sprice = "0";
                }
                if(Eprice=="")
                {
                    Eprice = "0";
                }
                if(city=="-1")
                {
                    city = "";
                }
                if (Ctype == "-1")
                {
                    Ctype = "";
                }

                cmd.Parameters["@KEYWORD"].Value = keyword;
                
                cmd.Parameters["@TYPE"].Value =  Ctype;
              
                cmd.Parameters["@CITY"].Value = city;
          
                cmd.Parameters["@STARTINGPRICE"].Value = Convert.ToInt32(Sprice);
               
                cmd.Parameters["@ENDINGPRICE"].Value = Convert.ToInt32( Eprice);
                

               cmd.ExecuteNonQuery();

               int Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format


                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //con.Open();
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return dt;

        }
        public DataTable filldatalist_from_cart(String username)
        {
            DataTable dt = null;
            dt = null;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            
            try
            {
                cmd = new SqlCommand("get_cart", con);
                cmd.CommandType = CommandType.StoredProcedure; ;
                cmd.Parameters.Add("@input_username", SqlDbType.VarChar, 20);
                cmd.Parameters["@input_username"].Value = username;

                
                cmd.ExecuteNonQuery();

                

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //con.Open();
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return dt;

        }

        public DataTable filldatalist_for_product(int id)
        {
            DataTable dt = null;
            dt = null;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("get_product", con);
                cmd.CommandType = CommandType.StoredProcedure; ;
                cmd.Parameters.Add("@input_productid", SqlDbType.Int);
                cmd.Parameters["@input_productid"].Value = id;


                cmd.ExecuteNonQuery();



                SqlDataAdapter da = new SqlDataAdapter(cmd);

                //con.Open();
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());

            }
            finally
            {
                con.Close();
            }

            return dt;

        }
        public DataTable filldatalist_for_sellerlistproducts(String username) //idk yhn error kyu aa ra
        {
            //int Found = 0;
            DataTable dt = null;
            DataSet ds;
            ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("get_supplier_products", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@input_username", SqlDbType.VarChar, 20);
                cmd.Parameters["@input_username"].Value = username;

                //cmd.Parameters["@Password"].Value = pass;


                cmd.ExecuteNonQuery();

                // read output value 
                //Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format
                //Fname = Convert.ToString(cmd.Parameters["@Fname"].Value); //convert to output parameter to interger format
                //Lname = Convert.ToString(cmd.Parameters["@Lname"].Value); //convert to output parameter to interger format


                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    da.Fill(dt);

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
            return dt;
            //DataTable dt = null;
            //dt = null;
            //SqlConnection con = new SqlConnection(connString);
            //con.Open();
            //SqlCommand cmd;
            //SqlDataAdapter da = new SqlDataAdapter("get_supplier_products", con);
            //try
            //{
            //    cmd = new SqlCommand("get_supplier_products", con);
            //    //con.Open();
            //    dt = new DataTable();
            //    da.Fill(dt);
            //}
            //finally
            //{
            //    con.Close();
            //}

            //return dt;

        }
        public int Rating_for_product(int ProductID,int Stars,String Username)
        {
            int Found=0;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("rating_product", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.VarChar,20);
                cmd.Parameters.Add("@ProductID", SqlDbType.Int);
                cmd.Parameters.Add("@stars", SqlDbType.Int);
                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters["@username"].Value =Username;
                cmd.Parameters["@ProductID"].Value =ProductID;
                cmd.Parameters["@stars"].Value =Stars;



                cmd.ExecuteNonQuery();

                Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format


                
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
        public int ShowRating_for_product(int ProductID ,ref int Stars )
        {
            int Found = 0;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("show_Rating", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("@ProductID", SqlDbType.Int);
                cmd.Parameters.Add("@stars", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;
             
                cmd.Parameters["@ProductID"].Value = ProductID;
                



                cmd.ExecuteNonQuery();
                Stars = Convert.ToInt32(cmd.Parameters["@stars"].Value); //convert to output parameter to interger format

                Found = Convert.ToInt32(cmd.Parameters["@found"].Value); //convert to output parameter to interger format



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
        public int update_status(int orderid,String status)
        {
            int Found = 0;
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("update_status", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@status", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@orderID", SqlDbType.Int);

                cmd.Parameters["@status"].Value = status;
                cmd.Parameters["@orderID"].Value =  orderid;


                cmd.ExecuteNonQuery();

               


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