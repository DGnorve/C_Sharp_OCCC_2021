//David Norvell
//OCCC C# Spring 2021 Online
//CustomerDB.cs

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FinalExam2
{
    public static class CustomerDB
    {
        public static Customer getCustomer(int CustomerID)
        {
            SqlConnection Conn = MMABooksDB.GetConnection();
            String id = CustomerID.ToString();
            String query = "SELECT CustomerID,Address, City, Name, State, ZipCode FROM Customers WHERE CustomerID =" + id;
            SqlCommand getCustomer = new SqlCommand(query, Conn);
            try {
                Conn.Open();
                SqlDataReader getSingleCustomer = getCustomer.ExecuteReader(CommandBehavior.SingleResult);
                if (getSingleCustomer.Read())
                {
                    Customer Target = new Customer();
                    Target.CustomerID = (int)getSingleCustomer["CustomerID"];
                    Target.Name = (string)getSingleCustomer["Name"];
                    Target.Address = (string)getSingleCustomer["Address"];
                    Target.City = (string)getSingleCustomer["City"];
                    Target.State = (string)getSingleCustomer["State"];
                    Target.ZipCode = (string)getSingleCustomer["ZipCode"];
                    return Target;
                }

            } catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
            return null;
        }
        public static void UpdateCustomer(Customer newCustomer, Customer old)
        {
            if (newCustomer.CustomerID != old.CustomerID)
            {
                return;
            }
            else
            {
                SqlConnection Conn = MMABooksDB.GetConnection();
                String Query = "UPDATE Customers SET Address ='" + newCustomer.Address.Trim() + "',City ='" + newCustomer.City.Trim() + "', Name =' " + newCustomer.Name.Trim() + "', State ='" + newCustomer.State.Trim() + "', ZipCode = " + '\'' + newCustomer.ZipCode.Trim() +'\'' 
                    + " WHERE CustomerID =" + old.CustomerID;
                    
                System.Console.WriteLine(Query);
                
                SqlCommand runUpdate = new SqlCommand(Query, Conn);
                try {
                    Conn.Open();
                    runUpdate.ExecuteNonQuery();
                } catch (SqlException e) {
                    System.Windows.Forms.MessageBox.Show(e.ToString());
                } finally {
                    Conn.Close();
                    Conn.Dispose();
                    
                }
                

            }
        }

        public static List<Customer> getData()
        {
            List<Customer> data = new List<Customer>(0);
            SqlConnection Conn = MMABooksDB.GetConnection();
            string query = "SELECT * FROM Customers";
            SqlCommand getDataFromTable = new SqlCommand(query, Conn);
            try
            {
                Conn.Open();
                SqlDataReader ingestTable = getDataFromTable.ExecuteReader();
                while (ingestTable.Read())
                {
                    Customer Target = new Customer();
                    Target.Address = (string)ingestTable["Address"];
                    Target.City = (string)ingestTable["City"];
                    Target.CustomerID = (int)ingestTable["CustomerID"];
                    Target.Name = (string)ingestTable["Name"];
                    Target.State = (string)ingestTable["State"];
                    Target.ZipCode = (string)ingestTable["ZipCode"];
                    data.Add(Target);
                }
                return data;
            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally {
                Conn.Close();
                Conn.Dispose();
            }
            return data;

        }

        public static void fillTableWithCustomers()
        {
            string query = "SELECT * FROM Customers";
            SqlConnection conn = MMABooksDB.GetConnection();
            SqlCommand getData = new SqlCommand(query, conn);
            try{
                conn.Open();
                JustSQLThings.adaptRS = new SqlDataAdapter(getData);
                JustSQLThings.justSQLData = new DataSet();
                JustSQLThings.adaptRS.Fill(JustSQLThings.justSQLData);


            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally {
                conn.Close();
                conn.Dispose();
            }
        
        }

    

       public static void DeleteCustomer(Customer target)
       {
            SqlConnection Conn = MMABooksDB.GetConnection();
        String query = "DELETE FROM Customers WHERE CustomerID = " + target.CustomerID;
        SqlCommand delete = new SqlCommand(query, Conn);
        try {
            Conn.Open();
            delete.ExecuteNonQuery();
        } catch (SqlException e)
        {
                System.Windows.Forms.MessageBox.Show(e.ToString());
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }

        }

    }

}


