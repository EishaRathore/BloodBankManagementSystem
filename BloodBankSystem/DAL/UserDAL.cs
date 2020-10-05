using BloodBankSystem.userBLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace BloodBankSystem.DAL
{
    class UserDAL
    {
        //create a static string method to connect database
        static string myconstn = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        
        //declare a object to pass the data to other form
        public static string welcomeUser = "";
        public static string welcomeUPass = "";
        public static string WelcomeUEmail = "";
        public static string welcomeUImg = "no-user.png";
        #region select data from database

        public DataTable Query(string str)
        {
            ///create an object to connect database
            SqlConnection conn = new SqlConnection(myconstn);

            //create a data table to hold the data from database

            DataTable dt = new DataTable();

            try
            {
                //write sql quey to get data from database
                string SQl = str;

                //create sql command to run query
                SqlCommand cmd = new SqlCommand(SQl,conn);

                //create sql date adapter to hold the date from database temporarily
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                //open database connection
                conn.Open();

                //transfer data from sql data adapter to datat table
                sda.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    MessageBox.Show(dt.Rows.ToString());
                }
            }
            catch(Exception Ex)
            {
                //dispose error message if there is any exceptional error
               MessageBox.Show(Ex.Message);
            }
            finally
            {
                //close database connection
                conn.Close();
            }
            return dt;
        }
        #endregion

        #region Insert Data into DataBase for User Module
        
        public bool Insert(UserbLL u)
        {
            //create a boolean variable and set its default value to false
            bool isSuccess = false;

            //create an object of sql connection to connect database
            SqlConnection conn = new SqlConnection(myconstn);

            
            try
            {
                //create a string variable to store the insert Query
                string SQL = "INSERT INTO userTbl(urole,userName,email,upassword,ucpassword,contact,uaddress,addDate,Gender,imSource) VALUES(@urole,@userName,@email,@upassword,@ucpassword,@contact,@uaddress,@addDate,@Gender,@imSource)";

                //create a sql command to pass the value in query
                SqlCommand cmd = new SqlCommand(SQL,conn);

                //create the parameters to pass get the value from UI and pass it on sql query above
                cmd.Parameters.AddWithValue("@urole", u.UserRole);
                cmd.Parameters.AddWithValue("@userName",u.UserName);
                cmd.Parameters.AddWithValue("@email", u.UserEmail);
                cmd.Parameters.AddWithValue("@upassword", u.UserPassword);
                cmd.Parameters.AddWithValue("@ucpassword", u.UserCfrmPassword);
                cmd.Parameters.AddWithValue("@contact", u.UserConatct);
                cmd.Parameters.AddWithValue("@uaddress", u.UserAddress);
                cmd.Parameters.AddWithValue("@addDate", u.AddDate);
                cmd.Parameters.AddWithValue("@Gender", u.Gender);
                cmd.Parameters.AddWithValue("@imSource", u.ImageSource);

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

        public bool Update(UserbLL u)
        {
            //create a boolean variable and set its default value to false
            bool isSuccess = false;

            //create an object of sql connection to connect database
            SqlConnection conn = new SqlConnection(myconstn);

            try
            {
                //create the string variable to hold the sql query
                string SQL = "UPDATE userTbl SET userName=@userName,email=@email,upassword=@upassword,ucpassword=@ucpassword,contact=@contact,uaddress=@uaddress,addDate=@addDate,Gender=@Gender,imSource=@imSource WHERE userId=@userId ";

                //create a sql command to pass the value in query
                SqlCommand cmd = new SqlCommand(SQL, conn);

                //now pass the vale to sql query
                cmd.Parameters.AddWithValue("@userName", u.UserName);
                cmd.Parameters.AddWithValue("@email", u.UserEmail);
                cmd.Parameters.AddWithValue("@upassword", u.UserPassword);
                cmd.Parameters.AddWithValue("@ucpassword", u.UserCfrmPassword);
                cmd.Parameters.AddWithValue("@contact", u.UserConatct);
                cmd.Parameters.AddWithValue("@uaddress", u.UserAddress);
                cmd.Parameters.AddWithValue("@addDate", u.AddDate);
                cmd.Parameters.AddWithValue("@Gender", u.Gender);
                cmd.Parameters.AddWithValue("@imSource", u.ImageSource);
                cmd.Parameters.AddWithValue("@userId", u.UserId);


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

        public bool Delete(UserbLL u)
        {
            //create a boolean variable and set its default value to false
            bool isSuccess = false;

            //create an object of sql connection to connect database
            SqlConnection conn = new SqlConnection(myconstn);

            try
            {
                //create the string variable to hold the sql query to delete data
                string SQL = "DELETE userTbl WHERE userId=@userId ";

                //create a sql command to pass the value in query
                SqlCommand cmd = new SqlCommand(SQL, conn);

                //now pass the vale to sql query
                cmd.Parameters.AddWithValue("@userId", u.UserId);

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

        #region POPUP after clicking sign up
        public bool POPUP(UserbLL u)
        {
            //create a boolean variable and set its default value to false
            bool isSuccess = false;

            //create an object of sql connection to connect database
            SqlConnection conn = new SqlConnection(myconstn);

            try
            {
                //create the string variable to hold the sql query to get data
                string SQL = "SELECT * FROM [dbo].[UserTbl] WHERE email=@email and upassword=@upassword";
                
                //create a sql command to pass the value in query
                SqlCommand cmd = new SqlCommand(SQL, conn);

                //open connection
                conn.Open();

                MessageBox.Show(u.UserEmail);
                MessageBox.Show(u.ImageSource);
                //now pass the vale to sql query
                cmd.Parameters.AddWithValue("@email", u.UserEmail);
                cmd.Parameters.AddWithValue("@upassword", u.UserPassword);

                //create sql date adapter to hold the date from database temporarily
                SqlDataAdapter sda = new SqlDataAdapter();

                DataTable dt = new DataTable();

                //transfer data from sql data adapter to datat table
                sda.Fill(dt);

                //create a variable to hold the value after query executed
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    //query executed successfully
                    isSuccess = true;

                    //store user name to retrieve further data in login page
                    welcomeUser = u.UserName;

                    //store user email to retrieve further data in login page
                   WelcomeUEmail = u.UserEmail;

                    //store user email to retrieve further data in login page
                    welcomeUImg = u.ImageSource;
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

        #region checking if the given user name or password is correct
        public bool Valid(UserbLL u)
        {
            
            //create a boolean variable and set its default value to false
            bool isSuccess = false;

            //create an object of sql connection to connect database
            SqlConnection conn = new SqlConnection(myconstn);

            try
            {
                //create the string variable to hold the sql query to get data
                string SQL = "SELECT * FROM [dbo].[UserTbl] WHERE (urole=@urole) and (userName=@userName or email=@email) and (upassword=@upassword) ";


                //create a sql command to pass the value in query
                SqlCommand cmd = new SqlCommand(SQL, conn);

                //open connection
                conn.Open();

                //now pass the vale to sql query
                cmd.Parameters.AddWithValue("@urole", u.UserRole);
                cmd.Parameters.AddWithValue("@email", u.UserEmail);
                cmd.Parameters.AddWithValue("@upassword", u.UserPassword);
                cmd.Parameters.AddWithValue("@userName", u.UserName);

                //create sql date adapter to hold the date from database temporarily
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                //transfer data from sql data adapter to datat table
                sda.Fill(dt);

                //create a variable to hold the value after query executed
               cmd.ExecuteNonQuery();

                if (dt.Rows.Count > 0)
                {
                    //store data in global variable to later use
                    welcomeUPass = u.UserPassword;
                    WelcomeUEmail = u.UserEmail;
                    welcomeUser = u.UserName;

                    

                    //query executed successfully
                    isSuccess = true;
                }
                else
                {
                    //failed to execute query
                    MessageBox.Show("Please Enter Correct (Role) or (User Name or Email) or (Passward) !!!");
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

        #region Contact US
        public bool InsertC(UserbLL u)
        {
            //create a boolean variable and set its default value to false
            bool isSuccess = false;

            //create an object of sql connection to connect database
            SqlConnection conn = new SqlConnection(myconstn);


            try
            {
                //create a string variable to store the insert Query
                string SQL = "INSERT INTO ContactTbl(FullName,email,Cmessage) VALUES(@full,@email,@msg)";

                //create a sql command to pass the value in query
                SqlCommand cmd = new SqlCommand(SQL, conn);

                //create the parameters to pass get the value from UI and pass it on sql query above
                cmd.Parameters.AddWithValue("@full", u.UserName);
                cmd.Parameters.AddWithValue("@email", u.UserEmail);
                cmd.Parameters.AddWithValue("@msg", u.msg);


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

       
    }
}
