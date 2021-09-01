//David Norvell
//OCCC C# Spring 2021 Online
//medicalDetailsDB.cs

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_CS2563_DavidNorvell
{
    public class medicalDetailsDB
    {

        // The Second form i can't cheese, i have to allow the user to select from multiple items
        // So i have to use ListView
        //So i have to make custom objects for all of it...
        //And use loops.....

        public static List<Allergy> getPatientAllergies(int PID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder queryPatient = new StringBuilder("SELECT PATIENT_ID, ALLERGY_ID, ALLERGEN, ONSET_DATE, NOTE FROM ALLERGIES WHERE PATIENT_ID =" + PID);
            List<Allergy> results = new List<Allergy>(0);
            Allergy temp = null;

            try {
                SqlCommand getAllergies = new SqlCommand(queryPatient.ToString(), conn);
                conn.Open();

                SqlDataReader ingestResults = getAllergies.ExecuteReader();
                while (ingestResults.Read())
                {
                    temp = new Allergy();
                    temp.PID = (int)ingestResults["PATIENT_ID"];
                    temp.AID = (int)ingestResults["ALLERGY_ID"];
                    temp.trigger.Append((string)ingestResults["ALLERGEN"]);
                    temp.DateOfOnset.Append((string)ingestResults["ONSET_DATE"]);
                    temp.Note.Append((string)ingestResults["NOTE"]);
                    results.Add(temp);
                }
            } catch (SqlException e) {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            } finally {
                conn.Close();
                conn.Dispose();
            }

            return results;

        }

        public static List<Immunisation> getPatientImmunusations(int PID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder queryPatient = new StringBuilder("SELECT PATIENT_ID, IMMUNIZATION_ID, IMMUNIZATION, DATE, NOTE FROM IMMUNIZATIONS WHERE PATIENT_ID =" + PID);
            List<Immunisation> results = new List<Immunisation>(0);
            Immunisation temp = null;

            try
            {
                SqlCommand getAllergies = new SqlCommand(queryPatient.ToString(), conn);
                conn.Open();

                SqlDataReader ingestResults = getAllergies.ExecuteReader();
                while (ingestResults.Read())
                {
                    temp = new Immunisation();
                    temp.PID = (int)ingestResults["PATIENT_ID"];
                    temp.IID = (int)ingestResults["IMMUNIZATION_ID"];
                    temp.typeOfImmunisation.Append((string)ingestResults["IMMUNIZATION"]);
                    temp.Date.Append((string)ingestResults["DATE"]);
                    temp.Note.Append((string)ingestResults["NOTE"]);
                    results.Add(temp);
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

            return results;
        }

        public static List<Medication> getPatientMedications(int PID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder queryPatient = new StringBuilder("SELECT PATIENT_ID, MED_ID, MEDICATION, DATE,CHRONIC, NOTE FROM MEDICATIONS WHERE PATIENT_ID =" + PID);
            List<Medication> results = new List<Medication>(0);
            Medication temp = null;

            try
            {
                SqlCommand getAllergies = new SqlCommand(queryPatient.ToString(), conn);
                conn.Open();

                SqlDataReader ingestResults = getAllergies.ExecuteReader();
                while (ingestResults.Read())
                {
                    temp = new Medication();
                    temp.PID = (int)ingestResults["PATIENT_ID"];
                    temp.MID = (int)ingestResults["MED_ID"];
                    temp.typeOfMedication.Append((string)ingestResults["MEDICATION"]);
                    temp.date.Append((string)ingestResults["DATE"]);
                    temp.isChronic = (bool)ingestResults["CHRONIC"];
                    temp.note.Append((string)ingestResults["NOTE"]);
                    results.Add(temp);
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

            return results;
        }

        public static List<testResult> getPatientResults(int PID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder queryPatient = new StringBuilder("SELECT PATIENT_ID, TEST_ID, TEST, RESULT,DATE,NOTE FROM TEST_RESULTS WHERE PATIENT_ID =" + PID);
            List<testResult> results = new List<testResult>(0);
            testResult temp = null;

            try
            {
                SqlCommand getAllergies = new SqlCommand(queryPatient.ToString(), conn);
                conn.Open();

                SqlDataReader ingestResults = getAllergies.ExecuteReader();
                while (ingestResults.Read())
                {
                    temp = new testResult();
                    temp.PID = (int)ingestResults["PATIENT_ID"];
                    temp.TID = (int)ingestResults["TEST_ID"];
                    temp.test.Append((string)ingestResults["TEST"]);
                    temp.result.Append((string)ingestResults["RESULT"]);
                    temp.date.Append((string)ingestResults["DATE"]);
                    temp.note.Append((string)ingestResults["NOTE"]);
                    results.Add(temp);
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

            return results;
        }

        public static List<medicalCondition> getPatientMedicalConditions(int PID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder queryPatient = new StringBuilder("SELECT PATIENT_ID, CONDITION_ID, CONDITION, ONSET_DATE,ACUTE,CHRONIC,NOTE FROM CONDITION WHERE PATIENT_ID =" + PID);
            List<medicalCondition> results = new List<medicalCondition>(0);
            medicalCondition temp = null;

            try
            {
                SqlCommand getAllergies = new SqlCommand(queryPatient.ToString(), conn);
                conn.Open();

                SqlDataReader ingestResults = getAllergies.ExecuteReader();
                while (ingestResults.Read())
                {
                    temp = new medicalCondition();
                    temp.PID = (int)ingestResults["PATIENT_ID"];
                    temp.CID = (int)ingestResults["ALLERGY_ID"];
                    temp.condition.Append((string)ingestResults["CONDITION"]);
                    temp.dateOfOnset.Append((string)ingestResults["ONSET_DATE"]);
                    temp.acute = (bool)ingestResults["ACUTE"];
                    temp.chronic = (bool)ingestResults["CHRONIC"];
                    temp.note.Append((string)ingestResults["NOTE"]);
                    results.Add(temp);
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

            return results;
        }

        public static List<medicalProcedure> getPatientMedicalProcedures(int PID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder queryPatient = new StringBuilder("SELECT MED_PROCEDURE.PATIENT_ID, MED_PROCEDURE.PROCEDURE_ID, MED_PROCEDURE.MED_PROCEDURE,NED_PROCEDURE.DATE,MED_PROCEDURE.DOCTOR,MED_PROCEDURE.NOTE FROM MED_PROCEDURE WHERE PATIENT_ID =" + PID);
            List<medicalProcedure> results = new List<medicalProcedure>(0);
            medicalProcedure temp = null;

            try
            {
                SqlCommand getAllergies = new SqlCommand(queryPatient.ToString(), conn);
                conn.Open();

                SqlDataReader ingestResults = getAllergies.ExecuteReader();
                while (ingestResults.Read())
                {
                    temp = new medicalProcedure();
                    temp.PID = (int)ingestResults["PATIENT_ID"];
                    temp.ProcID = (int)ingestResults["PROCEDURE_ID"];
                    temp.typeOfProcedure.Append((string)ingestResults["MED_PROCEDURE"]);
                    temp.date.Append((string)ingestResults["DATE"]);
                    temp.doctor.Append((string)ingestResults["DOCTOR"]);
                    temp.note.Append((string)ingestResults["NOTE"]);
                    results.Add(temp);
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

            return results;
        }
        //The only one of it's kind here

        public static StringBuilder[] getPatientPersonalDetails(int id)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder queryPatient = new StringBuilder("SELECT BLOOD_TYPE, ORGAN_DONOR, HIV_STATUS, HEIGHT_INCHES, WEIGHT_LBS FROM PER_DETAILS_TBL WHERE PATIENT_ID =" + id);
            StringBuilder[] returnVars = null;

            try
            {

                SqlCommand runPatientQuery = new SqlCommand(queryPatient.ToString(), conn);

                conn.Open();
                returnVars = new StringBuilder[5];

                SqlDataReader ingestQuery = runPatientQuery.ExecuteReader(CommandBehavior.SingleRow);

                if (ingestQuery.Read())
                {
                    returnVars[0] = new StringBuilder((string)ingestQuery["BLOOD_TYPE"]);
                    bool temp = (bool)ingestQuery["ORGAN_DONOR"];
                    returnVars[1] = new StringBuilder(temp.ToString());
                    bool temp2 = (bool)ingestQuery["HIV_STATUS"];
                    returnVars[2] = new StringBuilder(temp2.ToString());
                    System.Int16 height = (System.Int16)ingestQuery["HEIGHT_INCHES"];
                    returnVars[3] = new StringBuilder(height.ToString());
                    System.Int16 weight = (System.Int16)ingestQuery["WEIGHT_LBS"];
                    returnVars[4] = new StringBuilder(weight.ToString());
                }
                return returnVars;

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

        //Same as PatientDB "isExist" section

        public static bool doesPersonalEntryExist(string PID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder gitAns = new StringBuilder("SELECT BLOOD_TYPE FROM PER_DETAILS_TBL WHERE PATIENT_ID= " + '\'' +PID + '\'' );
            try
            {
                SqlCommand findAns = new SqlCommand(gitAns.ToString(), conn);
                conn.Open();
                int Aelita = findAns.ExecuteNonQuery();
                if (Aelita <= 0)
                    return false;
                else
                    return true;

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

        public static bool doesAllergyExist(string PID, string AID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder gitAns = new StringBuilder("SELECT ALLERGEN FROM ALLERGY_TBL WHERE PATIENT_ID=" + PID + " AND " + "ALLERGY_ID=" + AID);
            try
            {
                SqlCommand findAns = new SqlCommand(gitAns.ToString(), conn);
                conn.Open();
                int Aelita = findAns.ExecuteNonQuery();
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
        public static bool doesImmunizationExist(string PID, string IID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder gitAns = new StringBuilder("SELECT IMMUNIZATION FROM IMMUNIZATION_TBL WHERE PATIENT_ID=" + PID + " AND " + "IMMUNIZATION_ID=" + IID);
            try
            {
                SqlCommand findAns = new SqlCommand(gitAns.ToString(), conn);
                conn.Open();
                int Aelita = findAns.ExecuteNonQuery();
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
        public static bool doesMedicationExist(string PID,string MID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder gitAns = new StringBuilder("SELECT MEDICATION FROM MEDICATION_TBL WHERE PATIENT_ID=" + PID + " AND " + "MED_ID=" + MID);
            try
            {
                SqlCommand findAns = new SqlCommand(gitAns.ToString(), conn);
                conn.Open();
                int Aelita = findAns.ExecuteNonQuery();
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
        public static bool doesResultExist(string PID, string TTD)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder gitAns = new StringBuilder("SELECT TEST FROM TEST_TBL WHERE PATIENT_ID=" + PID + " AND " + "TEST_ID=" + TTD);
            try
            {
                SqlCommand findAns = new SqlCommand(gitAns.ToString(), conn);
                conn.Open();
                int Aelita = findAns.ExecuteNonQuery();
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
        public static bool doesMedConditionExist(string PID, string CID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder gitAns = new StringBuilder("SELECT CONDITION FROM MED_CON_TBL WHERE PATIENT_ID=" + PID + " AND " + "CONDITION.CONDITION_ID=" + CID); //This is the....3rd table i renamed to avoid ambiguous table names...
            try
            {
                SqlCommand findAns = new SqlCommand(gitAns.ToString(), conn);
                conn.Open();
                int Aelita = findAns.ExecuteNonQuery();
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
        public static bool doesMedProcExist(string PID, string OID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder gitAns = new StringBuilder("SELECT MED_PROCEDURE FROM MED_PROC_TBL WHERE PATIENT_ID=" + PID + " AND " + "PROCEDURE_ID=" + OID);
            try
            {
                SqlCommand findAns = new SqlCommand(gitAns.ToString(), conn);
                conn.Open();
                int Aelita = findAns.ExecuteNonQuery();
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



        public static void createNewTestDetails(int patientID, int testID, string test, string result, string date, string note)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("INSERT INTO TEST_RESULTS(PATIENT_ID,TEST_ID, TEST,RESULT,DATE,NOTE)"
                + "VALUES(" + '\'' + patientID + '\'' + ", " + '\'' + testID + '\'' + ", " + '\'' + test + '\'' + ", " + '\'' + result + '\'' + ", " + '\'' + date + '\'' + ", " + '\'' + note + '\'' + ")");
            try{
                SqlCommand create = new SqlCommand(query.ToString(), conn);
                conn.Open();
                create.ExecuteNonQuery();

            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally{
                conn.Close();
                conn.Dispose();
            }

        }
        public static void createNewMedicationDetails(int patientID, int medicationID, string medication, string date, bool chronic, string note)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("INSERT INTO MEDICATIONS(PATIENT_ID,MED_ID,MEDICATION,DATE,CHRONIC,NOTE)"
                + "VALUES(" + '\'' + patientID + '\'' + ", " + '\'' + medicationID + '\'' + ", " + '\'' + medication + '\'' + ", " + '\'' + date + '\'' + "," + '\'' + chronic + '\'' + ", " + '\'' + note + '\'' + ")");
            try{
                SqlCommand create = new SqlCommand(query.ToString(), conn);
                conn.Open();
                create.ExecuteNonQuery();
            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally{
                conn.Close();
                conn.Dispose();
            }

        }

        public static void createNewProcedureDetails(int patientID, int procedureID, string typeOfProcedure, string date, string doctor, string note)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("INSERT INTO MED_PROC_TBL(PATIENT_ID, PROCEDURE_ID, MED_PROCEDURE,DATE,DOCTOR,NOTE)"
                + "VALUES(" + '\'' + patientID + '\'' + ", " + '\'' + procedureID + '\'' + ", " + '\'' + typeOfProcedure + '\'' + ", " + '\'' + date + '\'' + ", " + '\'' + doctor + '\'' + ", " + '\'' + note + '\'' + ")");
            try{
                SqlCommand create = new SqlCommand(query.ToString(), conn);
                conn.Open();
                create.ExecuteNonQuery();
            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally{
                conn.Close();
                conn.Dispose();
            }
        }
        public static void createNewImmunizationDetails(int patientID, int immunizationID, string typeOfImmunization, string date, string note)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("INSERT INTO IMMUNIZATIONS(PATIENT_ID, IMMUNIZATION_ID, IMMUNIZATION, DATE,NOTE)"
                + "VALUES(" + '\'' + patientID + '\'' + ", " + '\'' + immunizationID + '\'' + ", " + '\'' + typeOfImmunization + '\'' + ", " + '\'' + date + '\'' + ", " + '\'' + note + '\'' + ")");
            try{
                SqlCommand create = new SqlCommand(query.ToString(), conn);
                conn.Open();
                create.ExecuteNonQuery();
            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally{
                conn.Close();
                conn.Dispose();
            }


        }

        public static void createNewConditionDetails(int patientID, int conditionID, string conditionName, string date, bool acute, bool chronic, string note)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("INSERT INTO MED_CON_TBL(PATIENT_ID, CONDITION_ID,CONDITION,ONSET_DATE,ACUTE,CHRONIC,NOTE)"
                + "VALUES(" + '\'' + patientID + '\'' + ", " + '\'' + conditionID + '\'' + ", " + '\'' + conditionName + '\'' + ", " + '\'' + date + '\'' + ", " + '\'' + acute + '\'' + ", " + '\'' + chronic + '\'' + ", " + '\'' + note + '\'' + ")");
            try{
                SqlCommand create = new SqlCommand(query.ToString(), conn);
                conn.Open();
                create.ExecuteNonQuery();
            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally{
                conn.Close();
                conn.Dispose();
            }
        }

        public static void createNewAllergyDetails(int patientID, int allergyID, string trigger, string date, string note)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("INSERT INTO ALLERGIES(PATIENT_ID, ALLERGY_ID, ALLERGEN, ONSET_DATE, NOTE)"
                + "VALUES(" + '\'' + patientID + '\'' + ", " + '\'' + allergyID + '\'' + ", " + '\'' + trigger + '\'' + ", " + '\'' + date + '\'' + ", " + '\'' + note + '\'' + ")");
            try{
                SqlCommand create = new SqlCommand(query.ToString(), conn);
                conn.Open();
                create.ExecuteNonQuery();
            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally{
                conn.Close();
                conn.Dispose();
            }
        }


        public static void createNewPerDetails(int patientID, string bloodType, bool isDonor, bool isHIV, int heightInches, int weightLbs)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("INSERT INTO PER_DETAILS_TBL(PATIENT_ID,BLOOD_TYPE,ORGAN_DONOR,HIV_STATUS,HEIGHT_INCHES,WEIGHT_LBS)"
                + "VALUES(" + '\'' + patientID + '\'' + " ," + '\'' + bloodType + '\'' + " ," + '\'' + isDonor + '\'' + " ," + '\'' + isHIV + '\'' +" ,"+ '\'' + heightInches + '\'' + " ," + '\'' + weightLbs + '\'' + ")");
            try
            {
                SqlCommand create = new SqlCommand(query.ToString(), conn);
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

        public static void updatePatientTestDetails(string test, string result, string date, string note, int patientID, int testID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("UPDATE TEST_RESULTS SET TEST =" + '\'' + test + '\'' + ", RESULT=" + '\'' + result + '\'' + ", DATE=" + '\'' + date + '\'' + ",NOTE=" + '\'' + note + '\''
                + "WHERE PATIENT_ID =" + patientID + " AND " + "TEST_ID=" + testID);
            try{
                SqlCommand update = new SqlCommand(query.ToString(), conn);
                conn.Open();
                update.ExecuteNonQuery();
            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally{
                conn.Close();
                conn.Dispose();
            }
        }
        public static void updatePatientMedicationDetails(string medication, string date, bool chronic, string note, int patientID, int medicationID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("UPDATE MEDICATIONS SET MEDICATION =" + '\'' + medication + '\'' + ",DATE=" + '\'' + date + '\'' + ",CHRONIC=" + '\'' + chronic + '\'' + ",NOTE=" + '\'' + note + '\''
                + "WHERE PATIENT_ID =" + patientID + " AND " + "MED_ID=" + medicationID);
            try{
                SqlCommand update = new SqlCommand(query.ToString(), conn);
                conn.Open();
                update.ExecuteNonQuery();
            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally{
                conn.Close();
                conn.Dispose();
            }
        }

        public static void updatePatientProcedureDetails(string typeOfProcedure, string date, string doctor, string note, int patientID, int procedureID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("UPDATE MED_PROC_TBL SET MED_PROCEDURE=" + '\'' + typeOfProcedure + '\'' + ",DATE=" + '\'' + date + '\'' + ",DOCTOR=" + '\'' + doctor + '\'' + ",NOTE=" + '\'' + note + '\''
                + "WHERE PATIENT_ID=" + patientID + " AND " + "PROCEDURE_ID=" + procedureID);
            try{
                SqlCommand update = new SqlCommand(query.ToString(), conn);
                conn.Open();
                update.ExecuteNonQuery();
            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally{
                conn.Close();
                conn.Dispose();
            }
        }
        public static void updatePatientImmunizationDetails(string typeOfImmunization, string date, string note, int patientID, int imunizationID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("UPDATE IMMUNIZATIONS SET IMMUNIZATION=" + '\'' + typeOfImmunization + '\'' + ", DATE=" + '\'' + date + '\'' + ", NOTE=" + '\'' + note + '\''
                + "WHERE PATIENT_ID=" + patientID + " AND " + "IMMUNIZATION_ID=" + imunizationID);
            try{
                SqlCommand update = new SqlCommand(query.ToString(), conn);
                conn.Open();
                update.ExecuteNonQuery();
            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally{
                conn.Close();
                conn.Dispose();
            }

        }

        public static void updatePatientConditionDetails(string conditionName, string date, bool acute, bool chronic, string note, int patientID, int conditionID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("UPDATE MED_CON_TBL SET CONDITION=" + '\'' + conditionName + '\'' + ",ONSET_DATE=" + '\'' + date + '\'' + ",ACUTE=" + '\'' + acute + '\'' + ",CHRONIC=" + '\'' + chronic + '\'' + ",NOTE=" + '\'' + note + '\''
                + "WHERE PATIENT_ID=" + patientID + " AND " + "CONDITION_ID=" + conditionID);
            try{
                SqlCommand update = new SqlCommand(query.ToString(), conn);
                conn.Open();
                update.ExecuteNonQuery();
            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally{
                conn.Close();
                conn.Dispose();
            }
        }


        public static void updatePatientAllergyDetails(string trigger, string date, string note, int patientID, int allergyID)
        {
        SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("UPDATE ALLERGIES SET ALLERGEN = " + '\'' + trigger + '\'' + ", DATE=" + '\'' + date + '\'' + ",NOTE=" + '\'' + note + '\''
                + "WHERE PATIENT_ID=" + patientID + " AND " + "ALLERGY_ID=" + allergyID);
            try{
                SqlCommand update = new SqlCommand(query.ToString(), conn);
                conn.Open();
                update.ExecuteNonQuery();
            }catch (SqlException e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally{
                conn.Close();
                conn.Dispose();
            }


        }

        public static void updatePatientPerDetails(string bloodType, bool isDonor, bool isHIV, int heightInches, int weightLbs,int PID)
        {
            SqlConnection conn = pchrDB.getConnection();
            StringBuilder query = new StringBuilder("UPDATE PER_DETAILS_TBL SET BLOOD_TYPE=" + '\'' + bloodType + '\'' + ",ORGAN_DONOR=" + '\'' + isDonor + '\'' + ",HIV_STATUS=" + '\'' + isHIV + '\'' + ",HEIGHT_INCHES=" + '\'' + heightInches + '\''
                + ",WEIGHT_LBS=" + '\'' + weightLbs + '\'' + " WHERE PATIENT_ID=" + PID);
            try
            {
                SqlCommand update = new SqlCommand(query.ToString(), conn);
                conn.Open();
                update.ExecuteNonQuery();
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
