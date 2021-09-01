//David Norvell
//OCCC C# Spring 2021 Online
//PatientDB.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Final_Project_CS2563_DavidNorvell
{
    public class PatientDB
    {

        //Main functions of this class, these below all grab a row of data and return an array of stringbuilders for our further mainpulation

        public static StringBuilder[] getPatientDetails(int id)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder queryPatient = new StringBuilder("SELECT LAST_NAME, FIRST_NAME,SEX,TITLE_NAME,INITIALS_NAME, DATE_OF_BIRTH, ADDRESS_STREET, ADDRESS_CITY, ADDRESS_STATE, ADDRESS_ZIP, PHONE_HOME, PHONE_MOBILE,PHONE_FAX, PRIMARY_ID,EMAIL_PRIMARY FROM PATIENT_TBL WHERE PATIENT_ID = " + id);
            StringBuilder[] returnVars = null;
            try{
                SqlCommand runPatientQuery = new SqlCommand(queryPatient.ToString(), conn);

                conn.Open();
                returnVars = new StringBuilder[15];

                SqlDataReader ingestQuery = runPatientQuery.ExecuteReader(CommandBehavior.SingleRow);

                if (ingestQuery.Read())
                {
                    returnVars[0] = new StringBuilder((string)ingestQuery["LAST_NAME"]);
                    returnVars[1] = new StringBuilder((string)ingestQuery["FIRST_NAME"]);
                    returnVars[2] = new StringBuilder((string)ingestQuery["SEX"]);
                    returnVars[3] = new StringBuilder((string)ingestQuery["TITLE_NAME"]);
                    returnVars[4] = new StringBuilder((string)ingestQuery["INITIALS_NAME"]);
                    DateTime temp =(DateTime)ingestQuery["DATE_OF_Birth"];
                    returnVars[5] = new StringBuilder(temp.ToString());
                    returnVars[6] = new StringBuilder((string)ingestQuery["ADDRESS_STREET"]);
                    returnVars[7] = new StringBuilder((string)ingestQuery["ADDRESS_CITY"]);
                    returnVars[8] = new StringBuilder((string)ingestQuery["ADDRESS_STATE"]);
                    returnVars[9] = new StringBuilder((string)ingestQuery["ADDRESS_ZIP"]);
                    returnVars[10] = new StringBuilder((string)ingestQuery["PHONE_HOME"]);
                    returnVars[11] = new StringBuilder((string)ingestQuery["PHONE_MOBILE"]);
                    returnVars[12] = new StringBuilder((string)ingestQuery["PHONE_FAX"]);
                    returnVars[13] = new StringBuilder((string)ingestQuery["PRIMARY_ID"]);
                    returnVars[14] = new StringBuilder((string)ingestQuery["EMAIL_PRIMARY"]);
                    return returnVars;

                }
                

            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally {
                conn.Close();
                conn.Dispose();
            }

            return null;
        }


        public static StringBuilder[] getPatientPCPDetails(string primary_id, string patient_id)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder queryPatient = new StringBuilder("SELECT NAME_FULL, SPECIALTY, PHONE_OFFICE, PHONE_MOBILE,PHONE_FAX,EMAIL FROM PRIMARY_CARE_TBL WHERE PRIMARY_ID =" + primary_id + " AND " + " PATIENT_ID=" + patient_id);
            StringBuilder[] returnVars = null;

            try
            {
                SqlCommand runPatientQuery = new SqlCommand(queryPatient.ToString(), conn);

                conn.Open();
                returnVars = new StringBuilder[6];

                SqlDataReader ingestQuery = runPatientQuery.ExecuteReader(CommandBehavior.SingleRow);

                if (ingestQuery.Read())
                {
                    returnVars[0] = new StringBuilder((string)ingestQuery["NAME_FULL"]);
                    returnVars[1] = new StringBuilder((string)ingestQuery["SPECIALTY"]);
                    returnVars[2] = new StringBuilder((string)ingestQuery["PHONE_OFFICE"]);
                    returnVars[3] = new StringBuilder((string)ingestQuery["PHONE_MOBILE"]);
                    returnVars[4] = new StringBuilder((string)ingestQuery["PHONE_FAX"]);
                    returnVars[5] = new StringBuilder((string)ingestQuery["EMAIL"]);
                    return returnVars;
                }
                else
                    return null;


            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return null;
        }

        public static StringBuilder[] getPatientEmergencyDetails(int primary_id)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder queryEmergencyDetails = new StringBuilder("SELECT NEXT_OF_KIN, RELATIONSHIP, ADDRESS_STREET, ADDRESS_CITY, ADDRESS_ZIP, SUBURB, PHONE_HOME, PHONE_MOBILE, PHONE_WORK, PHONE_FAX, EMAIL FROM PATIENT_EMERGENCY_DETAILS " +
                "WHERE PATIENT_ID=" + primary_id);
            StringBuilder[] returnVars = null;
            try
            {
                SqlCommand runEmergencyQuery = new SqlCommand(queryEmergencyDetails.ToString(), conn);
                conn.Open();
                returnVars = new StringBuilder[11];
                SqlDataReader ingest = runEmergencyQuery.ExecuteReader(CommandBehavior.SingleRow);
                if (ingest.Read())
                {
                    returnVars[0] = new StringBuilder((string)ingest["NEXT_OF_KIN"]);
                    returnVars[1] = new StringBuilder((string)ingest["RELATIONSHIP"]);
                    returnVars[2] = new StringBuilder((string)ingest["ADDRESS_STREET"]);
                    returnVars[3] = new StringBuilder((string)ingest["ADDRESS_CITY"]);
                    returnVars[4] = new StringBuilder((string)ingest["ADDRESS_ZIP"]);
                    returnVars[5] = new StringBuilder((string)ingest["SUBURB"]); //Not used
                    returnVars[6] = new StringBuilder((string)ingest["PHONE_HOME"]);
                    returnVars[7] = new StringBuilder((string)ingest["PHONE_MOBILE"]);
                    returnVars[8] = new StringBuilder((string)ingest["PHONE_WORK"]);
                    returnVars[9] = new StringBuilder((string)ingest["PHONE_FAX"]);
                    returnVars[10] = new StringBuilder((string)ingest["EMAIL"]);
                    return returnVars;
                }
                else
                {
                    return null;
                }

            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return null;

        }

        public static StringBuilder[] getPatientInsDetails(int patient_id)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder gitInsDetails = new StringBuilder("SELECT INSURER, INSURANCE_NUMBER, INSURANCE_PLAN FROM PATIENT_INS_TBL WHERE PATIENT_ID=" + patient_id);
            StringBuilder[] returnVars = null;
            try
            {
                SqlCommand gitInsData = new SqlCommand(gitInsDetails.ToString(), conn);
                conn.Open();

                returnVars = new StringBuilder[3];
                SqlDataReader ingest = gitInsData.ExecuteReader(CommandBehavior.SingleRow);
                if (ingest.Read())
                {
                    returnVars[0] = new StringBuilder((string)ingest["INSURER"]);
                    returnVars[1] = new StringBuilder((string)ingest["INSURANCE_NUMBER"]);
                    returnVars[2] = new StringBuilder((string)ingest["INSURANCE_PLAN"]);
                    return returnVars;
                }
                else
                    return null;


            }
            catch (SqlException e) {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return null;
        }

        //"doesExist" boolean functions, for when we need to decide between UPDATE and INSERT so we don't demolish the DB

        public static bool doesEmergencyRecordExist(int primary_id)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder git = new StringBuilder("SELECT NEXT_OF_KIN FROM PATIENT_EMERGENCY_DETAILS WHERE PATIENT_ID=" + primary_id);
            try
            {
                SqlCommand gitAns = new SqlCommand(git.ToString(), conn);
                conn.Open();
                int Aelita = gitAns.ExecuteNonQuery(); // the logic here is incredibly simple, we just shoot a single table a single result query. If it returns less than 1 row (we're only ever getting one row here) we return false, if it returns a row we return true.
                if (Aelita > 0)
                    return true;
                else
                    return false;

            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
            return false;
        }

        public static bool doesPCPRecordExist(string primary_id, string patient_id)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder git = new StringBuilder("SELECT NAME_FULL FROM PRIMARY_CARE_TBL WHERE PRIMARY_ID = " + primary_id + " AND " + " PATIENT_ID= " + patient_id);
            try
            {
                SqlCommand gitAns = new SqlCommand(git.ToString(), conn);
                conn.Open();
                int Aelita = gitAns.ExecuteNonQuery();
                if (Aelita > 0)
                    return true;
                else
                    return false;

            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally {
                conn.Close();
                conn.Dispose();
            }

            return false;
        }

        public static bool doesPatientInsRecordExist(string patient_id)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder git = new StringBuilder("SELECT INSURER FROM PATIENT_INS_TBL WHERE PATIENT_ID = " + patient_id );
            try
            {
                SqlCommand gitAns = new SqlCommand(git.ToString(), conn);
                conn.Open();
                int Aelita = gitAns.ExecuteNonQuery();
                if (Aelita > 0)
                    return true;
                else
                    return false;

            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return false;
        }



        //Getters for Primary and Foreign keys

        public static int getPID(string username)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("SELECT PatientID FROM PATIENT_SECKEYS WHERE PatientUsername =" + '\'' + username + '\'');
            try
            {
                SqlCommand get = new SqlCommand(query.ToString(), conn);
                conn.Open();
                SqlDataReader getMoar = get.ExecuteReader(CommandBehavior.SingleResult);
                if (getMoar.Read())
                {
                    int PID = int.Parse((string)getMoar["PatientID"]);
                    return PID;
                }
            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally {
                conn.Close();
                conn.Dispose();
            }

            return -1; //Why -1? Because 0 could probably be a valid FK or PK entry, -1 never would be. Makes it very easy to determine what's happening
        }

        public static int getPrimaryID(int patientID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder moarCowbell = new StringBuilder("SELECT PRIMARY_ID FROM PATIENT_TBL WHERE PATIENT_ID=" + patientID);  //Primary_ID is used as the Primary Key in Primary_Care_Tbl, Patient_ID becoming the Foreign Key and relating back to Patient_Tbl
            try
            {
                SqlCommand get = new SqlCommand(moarCowbell.ToString(), conn);
                conn.Open();
                SqlDataReader getMoar = get.ExecuteReader(CommandBehavior.SingleResult);
                if (getMoar.Read())
                {
                    int primaryID = int.Parse((string)getMoar["PRIMARY_ID"]);
                    return primaryID;
                }
            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
            return -1;
        
        }

        //Statements to actually create new table entries

        public static void createNewPatient(string lastName, string firstName, string title, string initial, string sex, string DOB, string primaryID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder fireUpdate = new StringBuilder("INSERT INTO PATIENT_TBL(LAST_NAME, FIRST_NAME,SEX,TITLE_NAME,INITIALS_NAME, DATE_OF_BIRTH, PRIMARY_ID) " 
            + "VALUES(" + '\'' + lastName + '\'' + "," + '\'' + firstName + '\'' + ","  + '\'' + sex + '\'' + "," +  '\'' + title + '\'' + "," + '\'' + initial + '\'' + ","+ '\'' + DOB + '\'' + "," + '\'' + primaryID + '\'' + ")");
            try{
                SqlCommand create = new SqlCommand(fireUpdate.ToString(), conn);
                conn.Open();
                create.ExecuteNonQuery();

            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally {
                conn.Close();
                conn.Dispose();
            }
        }

        public static void createNewPCPDetails(string patientID, string primaryID, string fullName, string specialty, string phoneOffice, string phoneMobile, string phoneFax, string Email)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder lasAlamos = new StringBuilder("INSERT INTO PRIMARY_CARE_TBL(PRIMARY_ID, PATIENT_ID, NAME_FULL, SPECIALTY, PHONE_OFFICE, PHONE_MOBILE,PHONE_FAX,EMAIL) "
                + "VALUES(" + '\'' + primaryID + '\'' + "," + '\'' + patientID + '\'' + "," + '\'' + fullName + '\'' + "," + '\'' + specialty + '\'' + "," + '\'' + phoneOffice + '\'' + "," + '\'' + phoneMobile + '\''
                + "," + '\'' + phoneFax + '\'' + "," + '\'' + Email + '\'' + ")");
            try
            {
                SqlCommand create = new SqlCommand(lasAlamos.ToString(), conn);
                conn.Open();
                create.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
        
        }
        public static void createNewEmergencyDetails(int patientID,string nextOfKin, string relationship, string address, string city, string zip, string suburb, string homePhone, string mobilePhone, string workPhone, string faxPhone, string email)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder gadget = new StringBuilder("INSERT INTO PATIENT_EMERGENCY_DETAILS(PATIENT_ID, NEXT_OF_KIN,RELATIONSHIP,ADDRESS_STREET,ADDRESS_CITY,ADDRESS_ZIP,SUBURB,PHONE_HOME,PHONE_MOBILE,PHONE_WORK,PHONE_FAX,EMAIL) "
                + "VALUES(" + '\'' + patientID + '\'' + "," + '\'' + nextOfKin + '\'' + "," + '\'' + relationship + '\'' + "," + '\'' + address + '\'' + "," + '\'' + city + '\'' + "," + '\'' + zip + '\'' + "," + '\'' + suburb + '\''
                + "," + '\'' + homePhone + '\'' + "," + '\'' + mobilePhone + '\'' + "," + '\'' + workPhone + '\'' + "," + '\'' + faxPhone + '\'' + "," + '\'' + email + '\'' + ")");
            try
            {
                SqlCommand create = new SqlCommand(gadget.ToString(), conn);
                conn.Open();
                create.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public static void createNewInsuranceDetails(int patientID, string insurer, string insuranceNum, string plan)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder trinity = new StringBuilder("INSERT INTO PATIENT_INS_TBL(PATIENT_ID,INSURER, INSURANCE_NUMBER, INSURANCE_PLAN)" +
                "VALUES(" + '\'' + patientID + '\'' + " ," + '\'' + insurer + '\'' + " ," + '\'' + insuranceNum + '\'' + " ," + '\'' + plan + '\'' + ")");
            try
            {
                SqlCommand create = new SqlCommand(trinity.ToString(), conn);
                conn.Open();
                create.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }


        }

     

        //Statements to update tables whenever we feel like it

        /*
         * Everything but FIRST_NAME and LAST_NAME can be NULL, so pass NULL if you don't have a paticular value for that patient
         */
        public static void updatePatientInformation(string lastName, string firstName,string sex, string title, string initials, string DOB, string address, string city, string state, string zip, string homePhone, string mobilePhone, string faxPhone, string primaryID, string Email, int PID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder IvyMike = new StringBuilder("UPDATE PATIENT_TBL"
                + " SET LAST_NAME =" + '\'' + lastName + '\'' + ", FIRST_NAME =" + '\'' + firstName + '\''  + ", SEX=" + '\'' + sex  + '\'' + ",TITLE_NAME=" + '\'' + title + '\'' + ", INITIALS_NAME=" + '\'' + initials + '\'' + ",DATE_OF_BIRTH=" + '\'' + DOB + '\'' + ",ADDRESS_STREET =" + '\'' +address+ '\''
                + ",ADDRESS_CITY=" + '\'' + city + '\'' + ",ADDRESS_STATE=" + '\'' + state + '\'' + ",ADDRESS_ZIP=" + '\'' + zip + '\'' + ",PHONE_HOME=" + '\'' + homePhone + '\'' + ",PHONE_MOBILE=" + '\'' + mobilePhone + '\'' + ",PHONE_FAX=" + '\'' + faxPhone + '\'' + ",PRIMARY_ID=" + '\'' + primaryID + '\''
                + ",EMAIL_PRIMARY=" + '\'' + Email + '\'' + "WHERE PATIENT_ID=" + PID );
            try{
                SqlCommand mikeShot = new SqlCommand(IvyMike.ToString(), conn);
                conn.Open();
                mikeShot.ExecuteNonQuery();

            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally {
                conn.Close();
                conn.Dispose();
            }
        
        }

        public static void updatePatientPrivateInformation(string bloodType, bool isDonor, bool isHIV, int heightInches, int weightLBS, int patientID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder CastleBravo = new StringBuilder("UPDATE PER_DETAILS_TBL SET BLOOD_TYPE =" + '\'' + bloodType + '\'' + ",ORGAN_DONOR=" + '\'' + isDonor + '\'' + ", HIV_STATUS=" + '\'' + isHIV + '\'' + ", HEIGHT_INCHES=" + '\'' + heightInches + '\'' + ", WEIGHT_LBS=" + '\'' + weightLBS + '\''
                + "WHERE PATIENT_ID=" + patientID + ")");
            try
            {
                SqlCommand shrimp = new SqlCommand(CastleBravo.ToString(), conn);
                conn.Open();
                shrimp.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
        
        }
        public static void updatePatientPCPInformation(string nameFull, string specialty, string phoneOffice, string phoneMobile, string phoneFax, string email, string patientID, string PrimaryID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("UPDATE PRIMARY_CARE_TBL SET NAME_FULL =" + '\'' + nameFull + '\'' + ", SPECIALTY=" + '\'' + specialty + '\'' + ", PHONE_OFFICE=" + '\'' + phoneOffice + '\'' + ",PHONE_MOBILE=" + '\'' + phoneMobile + '\'' + ",PHONE_FAX=" + '\'' + phoneFax + '\'' + ",EMAIL="
                + '\'' + email + '\'' + "WHERE PATIENT_ID=" + patientID + " AND " + " PRIMARY_ID= " + PrimaryID + ")"); //Another one of my edits to this table, created composite primary using PatientID and PrimaryID. Otherwise there's no way to have unique entries assoiated with each Patient and PCP
            try
            {
                SqlCommand firePCPUpdate = new SqlCommand(query.ToString(), conn);
                conn.Open();
                firePCPUpdate.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally {
                conn.Close();
                conn.Dispose();
            }
        }

        public static void updatePatientEmergencyDetails(int patientID, string nextOfKin, string relationship, string address, string city, string zip, string suburb, string homePhone, string mobilePhone, string workPhone, string faxPhone, string email)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("UPDATE PATIENT_EMERGENCY_DETAILS SET NEXT_OF_KIN=" + '\'' + nextOfKin + '\'' + ",RELATIONSHIP=" + '\'' + relationship + '\'' + ",ADDRESS_STREET=" + '\'' + address + '\'' + ",ADDRESS_CITY=" + '\'' + city + '\'' + ", ADDRESS_ZIP=" + '\'' + zip + '\''
                + ",SUBURB=" + '\'' + suburb + '\'' + ",PHONE_HOME=" + '\'' + homePhone + '\'' + ",PHONE_MOBILE=" + '\'' + mobilePhone + '\'' + ",PHONE_WORK=" + '\'' + workPhone + '\'' + ",PHONE_FAX=" + '\'' + faxPhone + '\'' + ",EMAIL=" + '\'' + email + '\''
                + "WHERE PATIENT_ID =" + patientID + ")");
            try
            {
                SqlCommand fireEmergencyDetailUpdate = new SqlCommand(query.ToString(), conn);
                conn.Open();
                fireEmergencyDetailUpdate.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally {
                conn.Close();
                conn.Dispose();
            }

        }
        public static void updatePatientInsuranceDetails(int patientID, string insurer,string insuranceNum, string plan)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("UPDATE PATIENT_INS_TBL SET INSURER=" + '\'' + insurer + '\'' +  ",INSURANCE_NUMBER=" + '\'' + insuranceNum + '\'' + ",INSURANCE_PLAN=" + '\'' + plan + '\''
                + "WHERE PATIENT_ID=" + patientID + ")");
            try
            {
                SqlCommand fireInsUpdate = new SqlCommand(query.ToString(), conn);
                conn.Open();
                fireInsUpdate.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
            finally {
                conn.Close();
                conn.Dispose();
                
            }
        }

       



    }
}
