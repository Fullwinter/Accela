using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccelaTest
{
    static class Validator
    {
        //Validate the conection paramaters
        public static bool Validate(Conection con, out string errormessage)
        {
            //Mandatory fields in Conection (configConnectionStringName is provided by the code [can't fail]but just in case we will change this I will add to the validation)
            if (string.IsNullOrEmpty(con.configConnectionStringName) ||
                string.IsNullOrEmpty(con.dataSource) ||
                string.IsNullOrEmpty(con.initialCatalog))
            {
                errormessage = "One of this fields are not filled: Sql Server IP or Database Name";
                return false;
            }

            if (!con.integratedSecurity && (string.IsNullOrEmpty(con.userId) || string.IsNullOrEmpty(con.password)))
            {
                errormessage = "One of this fields are not filled: UserName or Password";
                return false;
            }

            errormessage = "";
            return true;
        }

        public static bool ValidatePersonData(string id,string firstname,string lastname,out string errormessage)
        {
            /*int iid;
            if(!int.TryParse(id,out iid))
            {
                errormessage = "Not numeric Id";
                return false;
            }*/
            if(string.IsNullOrEmpty(firstname)||string.IsNullOrEmpty(lastname))
            {
                errormessage = "Need to fill first and last name";
                return false;
            }

            errormessage = "";
            return true;
        }

    }
}
