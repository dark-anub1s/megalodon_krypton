using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace megalodon.PL
{
    class User
    {
        private DataAccessLayer DAL = new DataAccessLayer();

        public DataTable Get_Users()
        {
            DAL.Open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("Get_User", null);
            DAL.Close();

            return dt;
        }

        public void Add_User(string name, string public_key, string vault_location, string otp_key)
        {
            DAL.Open();
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("name", SqlDbType.NVarChar, 50)
            {
                Value = name
            };

            para[1] = new SqlParameter("public_key", SqlDbType.Text)
            {
                Value = public_key
            };

            para[2] = new SqlParameter("vault_location", SqlDbType.NVarChar, 100)
            {
                Value = vault_location
            };

            para[3] = new SqlParameter("otp_key", SqlDbType.NVarChar, 25)
            {
                Value = otp_key
            };
            DAL.ExecuteCommand("Add_User", para);
            DAL.Close();
        }
    }
}
