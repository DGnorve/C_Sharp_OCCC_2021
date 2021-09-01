//David Norvell
//OCCC C# Spring 2021 Online
//MMABooksDB.cs

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FinalExam2
{
    public class MMABooksDB
    {
        

        public static SqlConnection GetConnection()
        {
            string workingDir = Environment.CurrentDirectory;
            string projectTrueDir = Directory.GetParent(workingDir).Parent.Parent.FullName;
            string absolutePathToDB = projectTrueDir + "\\MMABooks.mdf;";
            

           string connectionString =
                "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + absolutePathToDB +
                "Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
          
        }

        

    }
}
