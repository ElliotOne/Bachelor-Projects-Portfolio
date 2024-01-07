using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace WindowsFormsApp1.DB
{
    public class ReserveTable
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;

        public ReserveTable()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            ;
        }

        private void OpenConnection()
        {
            _sqlConnection = new SqlConnection {ConnectionString = _connectionString};
            _sqlConnection.Open();
        }

        private void CloseConnection()
        {
            if (_sqlConnection?.State != ConnectionState.Closed)
            {
                _sqlConnection?.Close();
            }
        }

        public List<Reserve> ReadAll()
        {
            List<Reserve> reserves = new List<Reserve>();

            OpenConnection();
            string sql = $"select S.sid,S.sname,B.bid,B.bname,R.rid,R.rdate from R " +
                         $"join B on R.bid = B.bid " +
                         $"join S on R.sid = S.sid";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    Reserve reserve = new Reserve
                    {
                        rid = (int) dataReader["rid"],
                        sname = (string) dataReader["sname"],
                        bname = (string) dataReader["bname"],
                        sid = (int) dataReader["sid"],
                        bid = (int) dataReader["bid"],
                        rdate= DateTime.Parse(dataReader["rdate"].ToString())
                    };

                    reserves.Add(reserve);
                }

                dataReader.Close();
            }

            CloseConnection();
            return reserves;
        }


        public void Create(int sid, int bid,DateTime date)
        {
            OpenConnection();
            string sql = $"Insert Into R(sid,bid,rdate) Values({sid},{bid},'{date}')";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public void Delete(int id)
        {
            OpenConnection();
            string sql = $"DELETE FROM R WHERE rid = {id}";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public List<Reserve> ReadLike(DateTime date)
        {
            List<Reserve> reserves = new List<Reserve>();
            OpenConnection();

            string sql = $"select S.sid,S.sname,B.bid,B.bname,R.rid,R.rdate from R " +
                         $"join B on R.bid = B.bid " +
                         $"join S on R.sid = S.sid " +
                         $"Where R.rdate >= '{date}'";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    Reserve reserve = new Reserve
                    {
                        rid = (int)dataReader["rid"],
                        bid = (int)dataReader["bid"],
                        sid = (int)dataReader["sid"],
                        bname = (string)dataReader["bname"],
                        sname = (string)dataReader["sname"],
                        rdate = DateTime.Parse(dataReader["rdate"].ToString())
                    };

                    reserves.Add(reserve);
                }

                dataReader.Close();
            }

            return reserves;
        }

        public void Update(int rid, int sid, int bid,DateTime date)
        {
            OpenConnection();
            string sql = $"Update R Set sid ={sid},bid ={bid},rdate='{date}' Where rid ={rid}";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

       
    }
}