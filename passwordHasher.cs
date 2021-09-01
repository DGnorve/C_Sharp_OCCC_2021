//David Norvell
//OCCC C# Spring 2021 Online
//passwordHasher.cs


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_CS2563_DavidNorvell
{
   public class passwordHasher
    {

        /*
         * We CANNOT store passwords in plain text
         * so we ingest them, hash them and then store the hashes in the DB
         * when a user logs on, we hash that input after validation
         * if and only if those hashes match do we allow them to continue
         * 
         */
       

        private static byte[] shaker;
        private static RNGCryptoServiceProvider a = null;
        private static Rfc2898DeriveBytes b = null;
        public static int numIter = 10000; //You wouldn't ever do this in a production enviroment, but we're short on time and this isn't going to hold anything confidential in reality.

        public static string createPassHash(string x)
        {
            try{
                a = new RNGCryptoServiceProvider();
                a.GetBytes(shaker = new byte[16]);

                b = new Rfc2898DeriveBytes(x, shaker, numIter);
                byte[] hash = b.GetBytes(20);

                byte[] finalHash = new byte[16 + 20];
                Array.Copy(shaker, 0, finalHash, 0, 16);
                Array.Copy(hash, 0, finalHash, 16,20);
                return Convert.ToBase64String(finalHash);
            }catch (Exception e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally {
                a.Dispose();
                b.Dispose();
                System.GC.Collect();
            }

            return null;


        }

        public static bool isValidPassword(string userPassword, string DBpassword)
        {
            try{
                byte[] hashBytes = Convert.FromBase64String(DBpassword);
               
               
                shaker = new byte[16];
                Array.Copy(hashBytes, 0, shaker, 0, 16);

                b = new Rfc2898DeriveBytes(userPassword, shaker, numIter);
                byte[] finalHash = b.GetBytes(20);

                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != finalHash[i])
                    {
                        return false;
                    }
                }
            }
            catch (Exception e){
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }finally {
                b.Dispose();
                System.GC.Collect();
            }

            return true;
        
        }
      


    }
}
