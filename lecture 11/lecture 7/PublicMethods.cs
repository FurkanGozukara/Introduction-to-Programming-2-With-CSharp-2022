using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.IO;

namespace lecture_7
{
    internal class PublicMethods
    {
        public static string loggedUserName = "";
        public static string loggedUserRank = "0";


        public class checkResult
        {
            public bool blResult = false;
            public string srMsg = "";
        }

        private static string allowedCharacters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZzĞğÜüİı";

        //check username have invalid character and if has return message
        //check if that username exists in database

        public static checkResult checkUserName(string srUserName)
        {
            checkResult myResult = new checkResult();

            if (srUserName.Length < 3)
            {
                myResult.srMsg = "Username can't be shorther than 3 characters";
                return myResult;
            }

            if (srUserName.Length > 50)
            {
                myResult.srMsg = "Username can't be longer than 50 characters";
                return myResult;
            }

            foreach (var vrChar in srUserName.ToCharArray())
            {
                if (!allowedCharacters.Contains(vrChar))
                {
                    myResult.srMsg = $"Username can't contain '{vrChar}' character";
                    return myResult;
                }
            }

            //this way allows SQL injection to be done by the user
            //DataRow drw = DbOperations.db_Select_DataRow($"select 1 from tblUsers where UserName=N'{srUserName}'");

            //if(drw!=null)
            //{
            //    myResult.srMsg = $"This username already exists";
            //    return myResult;
            //}


            //this is parameterized query and it is safe against sql injection
            string srCommand = "select 1 from tblUsers where UserName=@user_name_parameter";

            DataTable dtUsers = DbOperations.cmd_SelectQuery(srCommand, new List<string> { "@user_name_parameter" }, new List<object> { srUserName });

            if (dtUsers.Rows.Count > 0)
            {
                myResult.srMsg = $"This username already exists";
                return myResult;
            }

            myResult.blResult = true;
            return myResult;
        }

        public static checkResult checkEmail(string srEmail)
        {
            checkResult myResult = new checkResult();

            var email = new EmailAddressAttribute();
            if (email.IsValid(srEmail) == false)
            {
                myResult.srMsg = $"Your email is not a valid email address. Make sure that you have typed your email correctly!";
                return myResult;
            }

            string srCommand = "select 1 from tblUsers where Email=@Email";

            DataTable dtUsers = DbOperations.cmd_SelectQuery(srCommand, new List<string> { "@Email" }, new List<object> { srEmail });

            if (dtUsers.Rows.Count > 0)
            {
                myResult.srMsg = $"This email is already being used";
                return myResult;
            }

            myResult.blResult = true;
            return myResult;
        }

        public static string returnUserHashedPw(string srPwRaw, string srUserSalt)
        {
            return ComputeSha256Hash(srPwRaw + srUserSalt);
        }

        private static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static void initBooks()
        {
            int ircounter = 0;
            foreach (var vrLine in File.ReadLines("books.txt"))
            {
                if (vrLine.Length < 10)
                    continue;

                List<string> lstEachBookSeperated = vrLine.Split("$$$$$").ToList();
                if (lstEachBookSeperated.Count < 3)
                    continue;
                string srWriter = lstEachBookSeperated[1].Trim();

                string srBookName = lstEachBookSeperated[2].Trim();

               DbOperations.cmd_UpdateDeleteQuery("if not exists ( select 1 from tblBooks where BookName=@BookName and Writer=@Writer ) insert into tblBooks (BookCategory,BookName,Writer) values (1,@BookName,@Writer)",
                     new List<string> { "@BookName", "Writer" },
                     new List<object> { srBookName, srWriter });

                System.Threading.Thread.Sleep(1);
                ircounter++;
                MainWindow.runningWindow.Dispatcher.BeginInvoke(new Action(() =>
                {
                    MainWindow.runningWindow.lblBookAddstatus.Content = $"so far added book count is: {ircounter.ToString()}";
                }));
            }
        }
    }
}
