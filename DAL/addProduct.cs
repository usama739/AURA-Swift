using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace AURA_Swift.DAL
{
    public class addProduct
    {
        private static readonly string connString = System.Configuration.ConfigurationManager.ConnectionStrings["AURA_SwiftConnection"].ConnectionString;

        public int add_Product(String ProductName , String ProductDescription ,String userName ,String categorytype, String UnitPrice ,String AvailableColor,String UnitWeight ,String picture ,String AvailableUnit )
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("add_product", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 500);
                cmd.Parameters.Add("@userName", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@categorytype", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Int);
                cmd.Parameters.Add("@AvailableColors", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@UnitWeight", SqlDbType.Int);
                cmd.Parameters.Add("@picture", SqlDbType.VarChar, 200);
                cmd.Parameters.Add("@AvailableUnit", SqlDbType.Int);

                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;

                int Price = Convert.ToInt32(UnitPrice);
                int weight = Convert.ToInt32(UnitWeight);
                int aunits = Convert.ToInt32(AvailableUnit);
                // set parameter values
                cmd.Parameters["@ProductName"].Value = ProductName;
                cmd.Parameters["@ProductDescription"].Value = ProductDescription;
                cmd.Parameters["@userName"].Value = userName;
                cmd.Parameters["@categorytype"].Value = categorytype;
                cmd.Parameters["@UnitPrice"].Value = Price;
                cmd.Parameters["@AvailableColors"].Value = AvailableColor;
                cmd.Parameters["@UnitWeight"].Value = weight;
                if (picture == "")
                {
                    picture = "images\\Default.png";
                }
                cmd.Parameters["@picture"].Value = picture;
                cmd.Parameters["@AvailableUnit"].Value = aunits;

                //cmd.Parameters["@Password"].Value = pass;
                
              if( cmd.ExecuteNonQuery()==-1)
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

        public int Show_Product(ref String ProductID,ref String ProductName, ref String ProductDescription, ref String categorytype, ref String UnitPrice, ref String AvailableColor, ref String UnitWeight, ref String picture, ref String AvailableUnit)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Show_product_Attributes", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProdutID", SqlDbType.Int);
                cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                cmd.Parameters.Add("@categorytype", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@AvailableColors", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@UnitWeight", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@picture", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@AvailableUnit", SqlDbType.Int).Direction = ParameterDirection.Output;

                int pid = Convert.ToInt32(ProductID);
                // set parameter values
                cmd.Parameters["@ProdutID"].Value = pid;
                
                
          

                //cmd.Parameters["@Password"].Value = pass;

                if (cmd.ExecuteNonQuery() == -1)
                {

                }

                // read output value 

                ProductName = Convert.ToString(cmd.Parameters["@ProductName"].Value); //convert to output parameter to interger format
                ProductDescription = Convert.ToString(cmd.Parameters["@ProductDescription"].Value);
                categorytype = Convert.ToString(cmd.Parameters["@categorytype"].Value);
                UnitPrice = Convert.ToString(cmd.Parameters["@UnitPrice"].Value);
                AvailableColor = Convert.ToString(cmd.Parameters["@AvailableColors"].Value);
                UnitWeight = Convert.ToString(cmd.Parameters["@UnitWeight"].Value);
                picture = Convert.ToString(cmd.Parameters["@picture"].Value);
                AvailableUnit = Convert.ToString(cmd.Parameters["@AvailableUnit"].Value);
                

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
        public int get_Product_pic(ref String ProductID,ref String picture)
        {

            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("get_product_pic", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int);
               
                cmd.Parameters.Add("@Picture", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
               
                int pid = Convert.ToInt32(ProductID);
                // set parameter values
                cmd.Parameters["@ProductID"].Value = pid;




                //cmd.Parameters["@Password"].Value = pass;

                if (cmd.ExecuteNonQuery() == -1)
                {

                }

                // read output value 

                
                picture = Convert.ToString(cmd.Parameters["@Picture"].Value);
                


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
        public int update_product(ref String ProductID, ref String ProductName, ref String ProductDescription, ref String categorytype, ref String UnitPrice, ref String AvailableColor, ref String UnitWeight, ref String picture, ref String AvailableUnit)
        {
            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("update_products", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 500);
                cmd.Parameters.Add("@ProdutID", SqlDbType.Int);
                cmd.Parameters.Add("@categorytype", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Int);
                cmd.Parameters.Add("@AvailableColors", SqlDbType.VarChar, 20);
                cmd.Parameters.Add("@UnitWeight", SqlDbType.Int);
                cmd.Parameters.Add("@picture", SqlDbType.VarChar, 200);
                cmd.Parameters.Add("@AvailableUnit", SqlDbType.Int);

                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;

                int Price = Convert.ToInt32(UnitPrice);
                int weight = Convert.ToInt32(UnitWeight);
                int aunits = Convert.ToInt32(AvailableUnit);
                // set parameter values
                cmd.Parameters["@ProductName"].Value = ProductName;
                cmd.Parameters["@ProductDescription"].Value = ProductDescription;
                cmd.Parameters["@ProdutID"].Value = Convert.ToInt32(ProductID);
                cmd.Parameters["@categorytype"].Value = categorytype;
                cmd.Parameters["@UnitPrice"].Value = Price;
                cmd.Parameters["@AvailableColors"].Value = AvailableColor;
                cmd.Parameters["@UnitWeight"].Value = weight;
                if (picture == "")
                {
                    picture = "images\\Default.png";
                }
                cmd.Parameters["@picture"].Value = picture;
                cmd.Parameters["@AvailableUnit"].Value = aunits;

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
        public int Delete_product( String ProductID)
        {
            int Found = 0;
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand("Delete_products", con); //name of your procedure
                cmd.CommandType = CommandType.StoredProcedure;

              
                cmd.Parameters.Add("@ProdutID", SqlDbType.Int);
         
                cmd.Parameters.Add("@found", SqlDbType.Int).Direction = ParameterDirection.Output;

               
                
                cmd.Parameters["@ProdutID"].Value = Convert.ToInt32(ProductID);
              
               
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