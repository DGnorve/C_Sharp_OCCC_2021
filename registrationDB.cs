//David Norvell
//OCCC C# Spring 2021 Online
//registrationDB.cs

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_CS2563_DavidNorvell
{
    public class registrationDB
    {
        public static int doesExist(string firstName) //We bootstrap the login process using the relationship between the PK and first name to determine if this user exists. If not, we return -1 and make them complete registration in it's entirety.
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder checkUser = new StringBuilder("SELECT PATIENT_ID FROM PATIENT_TBL WHERE FIRST_NAME =" + '\'' + firstName + '\'');
            try{
                SqlCommand getUser = new SqlCommand(checkUser.ToString(), conn);
                conn.Open();

                SqlDataReader ingest = getUser.ExecuteReader(CommandBehavior.SingleResult);
                if (ingest.Read())
                {
                    return int.Parse((string)ingest["PATIENT_ID"]);
                }
                else
                    return -1;

            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }

            return -1;
        
        }

        public static bool hasHash(int idNum) //Then if we do get a valid ID, is there a password assoiated with it already? If the user exists, but no password hash is found then we ONLY want them to create a new password!
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder checkUser = new StringBuilder("SELECT PatientUsername, PatientPassword  FROM PATIENT_SECKEYS WHERE PatientID= " + idNum);
            StringBuilder[] patientSECInfo = new StringBuilder[2];
            try {
                SqlCommand getMemes = new SqlCommand(checkUser.ToString(), conn);
                conn.Open();

                SqlDataReader ingest = getMemes.ExecuteReader(CommandBehavior.SingleRow);
                if (ingest.Read())
                {

                    patientSECInfo[0] = new StringBuilder((string)ingest["PatientUsername"]);
                    patientSECInfo[1] = new StringBuilder((string)ingest["PatientPassword"]);

                    if (patientSECInfo[1].Length == 0 || patientSECInfo[1] == null) //Is it 0 length or null? If yes, get out.
                        return false;
                    if (patientSECInfo[1].ToString() == null) //If we call ToString, does it return null? If yes, get out.
                        return false;
                    if (patientSECInfo[1].ToString().Trim().Length == 0)  //Is it literally just whitespace? if yes get out.
                        return false;
                    else
                        return true; //Is it not garbage? FANTASTIC! return true
                }

            }catch (SqlException e) {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally {
                conn.Close();
                conn.Dispose();
            }
            return false; // return false if all of the above failed.

            
        }

        public static StringBuilder getUserSecInfo(string username)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder getSecInfo = new StringBuilder("SELECT PatientPassword FROM PATIENT_SECKEYS WHERE PatientUsername=" + '\'' + username + '\''); //This isn't a table that shipped stock, iv'e made several modifications to this DB
            StringBuilder data; 
            try{
                SqlCommand get = new SqlCommand(getSecInfo.ToString(), conn);
                conn.Open();

                SqlDataReader ingest = get.ExecuteReader(CommandBehavior.SingleRow);
                if (ingest.Read())
                {
                    data= new StringBuilder((string)ingest["PatientPassword"]); //This looks scary, but remember we're handling hashes here. Fire up your favorite DBMS, all you'll get is garbage :D
                    
                    return data;
                }

            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally{
                conn.Close();
                conn.Dispose();
            }
            return null;
        }

        public static void createLogin(String UN, String Pass, int id) //This is for creating NEW login information
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder passHash = new StringBuilder(0);
            passHash.Append(passwordHasher.createPassHash(Pass)); 

            StringBuilder insertPass = new StringBuilder("INSERT INTO PATIENT_SECKEYS(PatientID,PatientUsername,PatientPassword)" +  "VALUES(" +'\'' + id.ToString() + '\'' + ","  + '\'' + UN + '\'' + "," + '\'' + passHash.ToString() + '\'' + ")");  //This would FAIL if ran on an extent user!
            
            try{
                SqlCommand updatePass = new SqlCommand(insertPass.ToString(), conn);
                conn.Open();

                updatePass.ExecuteNonQuery();
            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally {
                conn.Close();
                conn.Dispose();
            }

        }

        public static void updateLogin(String Geneva, String Pass, int id) //This is for updating extent users
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder passHash = new StringBuilder(0);

            passHash.Append(passwordHasher.createPassHash(Pass));
            StringBuilder updatePass = new StringBuilder("UPDATE PATIENT_SECKEYS SET PatientUsername = " + '\'' + Geneva + '\'' + ", PatientPassword = " + '\'' + passHash.ToString() + '\'' + " WHERE PatientID = " + id); //This wouldn't though.

            try{
                SqlCommand updatePassword = new SqlCommand(updatePass.ToString(), conn);
                conn.Open();
                updatePassword.ExecuteNonQuery();

            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally {
                conn.Close();
                conn.Dispose();
            }

        }
    }
}
