using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace WindowsFormsApp1.DB
{
    public class BoatTable
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;

        public BoatTable()
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


        public void Create(string name, string color)
        {
            OpenConnection();
            string sql = $"Insert Into B(bname,bcolor) Values('{name}','{color}')";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public void Update(int id, string name, string color)
        {
            OpenConnection();
            string sql = $"Update B Set bname ='{name}',bcolor ='{color}' Where bid ={id}";

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
            string sql = $"DELETE FROM B WHERE bid = {id}";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }


        public Boat Read(int id)
        {
            Boat boat = null;
            OpenConnection();
            string sql = $"Select * From B Where bid = '{id}'";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    boat = new Boat
                    {
                        bid = (int)dataReader["bid"],
                        bname = (string)dataReader["bname"],
                        bcolor = (string)dataReader["bcolor"],
                    };

                }
                dataReader.Close();
            }

            CloseConnection();

            return boat;
        }
        public List<Boat> ReadAll()
        {
            List<Boat> boats = new List<Boat>();

            OpenConnection();
            string sql = $"Select * From B";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    Boat boat = new Boat
                    {
                        bid = (int)dataReader["bid"],
                        bname = (string)dataReader["bname"],
                        bcolor = (string)dataReader["bcolor"],
                    };

                    boats.Add(boat);
                }
                dataReader.Close();
            }

            CloseConnection();
            return boats;
        }

        public List<Boat> ReadLike(string name, string color)
        {
            List<Boat> boats = new List<Boat>();
            OpenConnection();
            string sql = $"Select * From B Where bname like " + $"'%{name}%'" + " and bcolor like " + $"'%{color}%'";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    Boat boat = new Boat
                    {
                        bid = (int)dataReader["bid"],
                        bname = (string)dataReader["bname"],
                        bcolor = (string)dataReader["bcolor"],
                    };

                    boats.Add(boat);
                }
                dataReader.Close();
            }

            CloseConnection();
            return boats;
        }
    }
}
