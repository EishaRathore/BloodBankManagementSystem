using BloodBankSystem.BLL;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BloodBankSystem.DAL
{
    class DonorDAL
    {
        //create a static string method to connect database
        static string myconstn = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        #region Insert Data into DataBase for User Module

        public bool Insert(DonorBLL d)
        {
            //create a boolean variable and set its default value to false
            bool isSuccess = false;

            //create an object of sql connection to connect database
            SqlConnection conn = new SqlConnection(myconstn);


            try
            {
                //create a string variable to store the insert Query
                string SQL = "INSERT INTO DonorTbl(dFullName,demail,dpassword,dcpassword,dcontact,daddress,addDate,dGender,dimSource,dBloodG,dEllig,UserId) VALUES(@dFullName,@demail,@dpassword,@dcpassword,@dcontact,@daddress,@addDate,@dGender,@dimSource,@dBloodG,@dEllig,@UserId)";

                //create a sql command to pass the value in query
                SqlCommand cmd = new SqlCommand(SQL, conn);

                //create the parameters to pass get the value from UI and pass it on sql query above
                cmd.Parameters.AddWithValue("@dFullName", d.DFullName);
                cmd.Parameters.AddWithValue("@demail", d.dEmail);
                cmd.Parameters.AddWithValue("@dpassword", d.DPassword);
                cmd.Parameters.AddWithValue("@dcpassword", d.DCfrmPassword);
                cmd.Parameters.AddWithValue("@dcontact", d.DConatct);
                cmd.Parameters.AddWithValue("@daddress", d.DAddress);
                cmd.Parameters.AddWithValue("@addDate", d.AddDate);
                cmd.Parameters.AddWithValue("@dGender", d.DGender);
                cmd.Parameters.AddWithValue("@dimSource", d.DImageSource);
                cmd.Parameters.AddWithValue("@dBloodG", d.DBloodG);
                cmd.Parameters.AddWithValue("@dEllig", d.DEllig);
                cmd.Parameters.AddWithValue("@UserId", d.UserId);
               

                //open database connection
                conn.Open();

                //create a variable to hold the value after query executed
                int rows = cmd.ExecuteNonQuery();

                //the value of rows will be greater then 0 if query executed successfully
                //else it will be 0

                if (rows > 0)
                {
                    //query executed successfully
                    isSuccess = true;
                }
                else
                {
                    //failed to execute query
                    isSuccess = false;
                }
            }
            catch (Exception Ex)
            {
                //dispose error message if there is any exceptional error
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                //close database connection
                conn.Close();
            }

            return isSuccess;
        }
        #endregion

        #region Update data in database UserModule(User Module)

        public bool Update(DonorBLL d)
        {
            //create a boolean variable and set its default value to false
            bool isSuccess = false;

            //create an object of sql connection to connect database
            SqlConnection conn = new SqlConnection(myconstn);

            try
            {
                //create the string variable to hold the sql query
                string SQL = "UPDATE DonorTbl SET dFullName=@dFullName,demail=@demail,dpassword=@dpassword,dcpassword=@dcpassword,dcontact=@dcontact,daddress=@daddress,dGender=@dGender,dimSource=@dimSource,dBloodG=@dBloodG,dEllig=@dEllig,UserId=@UserId WHERE donorId=@donorId ";

                //create a sql command to pass the value in query
                SqlCommand cmd = new SqlCommand(SQL, conn);

                //now pass the vale to sql query
                cmd.Parameters.AddWithValue("@dFullName", d.DFullName);
                cmd.Parameters.AddWithValue("@demail", d.dEmail);
                cmd.Parameters.AddWithValue("@dpassword", d.DPassword);
                cmd.Parameters.AddWithValue("@dcpassword", d.DCfrmPassword);
                cmd.Parameters.AddWithValue("@dcontact", d.DConatct);
                cmd.Parameters.AddWithValue("@daddress", d.DAddress);
                cmd.Parameters.AddWithValue("@dGender", d.DGender);
                cmd.Parameters.AddWithValue("@dimSource", d.DImageSource);
                cmd.Parameters.AddWithValue("@dBloodG", d.DBloodG);
                cmd.Parameters.AddWithValue("@dEllig", d.DEllig);
                cmd.Parameters.AddWithValue("@UserId", d.UserId);
                cmd.Parameters.AddWithValue("@donorId", d.donorId);

               //open database connection
                conn.Open();

                //create a variable to hold the value after query executed
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    //query executed successfully
                    isSuccess = true;
                }
                else
                {
                    //failed to execute query
                    isSuccess = false;
                }
            }
            catch (Exception Ex)
            {
                //dispose error message if there is any exceptional error
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                //close database connection
                conn.Close();
            }
            return isSuccess;
        }
        #endregion

        #region delete data in database UserModule(User Module)

        public bool Delete(DonorBLL d)
        {
            //create a boolean variable and set its default value to false
            bool isSuccess = false;

            //create an object of sql connection to connect database
            SqlConnection conn = new SqlConnection(myconstn);

            try
            {
                //create the string variable to hold the sql query to delete data
                string SQL = "DELETE DonorTbl WHERE donorId=@donorId ";

                //create a sql command to pass the value in query
                SqlCommand cmd = new SqlCommand(SQL, conn);

                //now pass the vale to sql query
                cmd.Parameters.AddWithValue("@donorId", d.donorId);

                //create a variable to hold the value after query executed
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    //query executed successfully
                    isSuccess = true;
                }
                else
                {
                    //failed to execute query
                    isSuccess = false;
                }
            }
            catch (Exception Ex)
            {
                //dispose error message if there is any exceptional error
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                //close database connection
                conn.Close();
            }
            return isSuccess;
        }
        #endregion
    }
}
