using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace WindowsFormsApp1.DB
{
    public class OffenseTable
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;

        public OffenseTable()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            ;
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

        public List<OffenseWithDetails> ReadAll()
        {
            List<OffenseWithDetails> offenseWithDetails = new List<OffenseWithDetails>();

            OpenConnection();
            string sql =
                $"Select * From Offense Join Car On Car.CarCode = Offense.CarCode Join Person On Person.Id = Offense.PersonId";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    OffenseWithDetails offense = new OffenseWithDetails
                    {
                        CarCode = (string)dataReader["CarCode"],
                        Type = (string)dataReader["Type"],
                        Firstname = (string)dataReader["Firstname"],
                        Lastname = (string)dataReader["Lastname"],
                        Price = double.Parse(dataReader["Price"].ToString()),
                        PersonId = (string)dataReader["PersonId"],
                        CreateDate = DateTime.Parse(dataReader["CreateDate"].ToString())
                    };

                    offenseWithDetails.Add(offense);
                }

                dataReader.Close();
            }

            CloseConnection();
            return offenseWithDetails;
        }


        public void Create(string PersonId, string CarCode, DateTime CreateDate, string Type, double Price)
        {
            OpenConnection();
            string sql = $"Insert Into Offense(PersonId,CarCode,CreateDate,Type,Price)" +
                         $" Values('{PersonId}','{CarCode}','{CreateDate}','{Type}',{Price})";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }
    }
}