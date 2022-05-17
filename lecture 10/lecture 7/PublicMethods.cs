using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace lecture_7
{
    internal class PublicMethods
    {
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
    }
}
