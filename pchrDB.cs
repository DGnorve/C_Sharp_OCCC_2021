//David Norvell
//OCCC C# Spring 2021 Online
//pchrDB.cs

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Final_Project_CS2563_DavidNorvell
{
    public class pchrDB
    {
        public static SqlConnection getConnection()
        {
            try{

                //StringBuilder is so much faster than String at stuff like this, and doesn't throw as much immutable garbage on the stack (Still a bit, it has to become a String Eventually....)
                StringBuilder finalDir = new StringBuilder(0);
                StringBuilder workingDir = new StringBuilder(Environment.CurrentDirectory);
                StringBuilder trueDir = new StringBuilder(Directory.GetParent(workingDir.ToString()).Parent.Parent.FullName);
                finalDir = finalDir.Append(trueDir + "\\pchr42563.mdf;");

                StringBuilder connectionString = new StringBuilder("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFileName =" + finalDir + "Integrated Security=True");
                SqlConnection conn = new SqlConnection(connectionString.ToString());

                return conn;
            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }

            return null;


        
        }

        

    }
}
