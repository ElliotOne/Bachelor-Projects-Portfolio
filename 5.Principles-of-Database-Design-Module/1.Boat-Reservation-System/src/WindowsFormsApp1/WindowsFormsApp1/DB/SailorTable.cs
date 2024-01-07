using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1.DB
{
    public class SailorTable
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;

        public SailorTable()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString; ;
        }
        private void OpenConnection()
        {
            _sqlConnection = new SqlConnection { ConnectionString = _connectionString };
            _sqlConnection.Open();
        }

        private void CloseConnection()
        {
            if (_sqlConnection?.State != ConnectionState.Closed)
            {
                _sqlConnection?.Close();
            }
        }


        public void Create(string name, int rate, int age)
        {
            OpenConnection();
            string sql = $"Insert Into S(sname,srate,sage) Values('{name}',{rate},{age})";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public List<Sailor> ReadAll()
        {
            List<Sailor> sailors = new List<Sailor>();

            OpenConnection();
            string sql = $"Select * From S";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    Sailor sailor = new Sailor
                    {
                        sid = (int)dataReader["sid"],
                        sname = (string)dataReader["sname"],
                        srate = (int)dataReader["srate"],
                        sage = (int)dataReader["sage"]
                    };

                    sailors.Add(sailor);
                }
                dataReader.Close();
            }

            CloseConnection();
            return sailors;
        }


        public List<Sailor> ReadLike(string name)
        {
            List<Sailor> sailors = new List<Sailor>();
            OpenConnection();
            string sql = "Select * From S Where sname like " + $"'%{name}%'";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    Sailor sailor = new Sailor()
                    {
                        sid = (int)dataReader["sid"],
                        sname = (string)dataReader["sname"],
                        srate = (int)dataReader["srate"],
                        sage = (int)dataReader["sage"]
                    };

                    sailors.Add(sailor);
                }
                dataReader.Close();
            }

            CloseConnection();
            return sailors;
        }

        public void Delete(int id)
        {
            OpenConnection();
            string sql = $"DELETE FROM S WHERE sid = {id}";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public void Update(int id, string name, int rate, int age)
        {
            OpenConnection();
            string sql = $"Update S Set sname ='{name}',srate ={rate},sage={age} Where sid ={id}";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }
    }
}
