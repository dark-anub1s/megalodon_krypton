using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace megalodon
{
    class DataAccessLayer
    {
        private SqlConnection _sqlconnection = new SqlConnection();

        public DataAccessLayer()
        {
            _sqlconnection.ConnectionString =
                "Data Source=.; Initial Catalog=megalodon_users; Integrated Security=True; Connect Timeout=100";

        }

        //Open the Database Connection
        public void Open()
        {
            if (_sqlconnection.State != ConnectionState.Open)
            {
                _sqlconnection.Open();
            }
        }

        //Close the Database Connection
        public void Close()
        {
            if (_sqlconnection.State != ConnectionState.Closed)
            {
                _sqlconnection.Close();
            }
        }

        public DataTable SelectData(string procedureName, SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            cmd.Connection = _sqlconnection;

            if (para != null)
            {
                for (int i = 0; i < para.Length; i++)
                {
                    cmd.Parameters.Add(para[i]);
                }
                
            }

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);

            return dt;
        }

        public void ExecuteCommand(string procedureName, SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            cmd.Connection = _sqlconnection;

            if (para != null)
            {
                cmd.Parameters.AddRange(para);

            }

            cmd.ExecuteNonQuery();
        }
    }
}
