using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1.DB
{
    public class PersonTable
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;

        public PersonTable()
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


        public void Create(string id, string firstName, string lastName)
        {
            OpenConnection();
            string sql = $"Insert Into Person(Id,Firstname,Lastname) Values('{id}','{firstName}','{lastName}')";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public List<Person> ReadAll()
        {
            List<Person> persons = new List<Person>();

            OpenConnection();
            string sql = $"Select * From Person";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    Person person = new Person
                    {
                        Id = (string)dataReader["Id"],
                        Firstname = (string)dataReader["Firstname"],
                        Lastname = (string)dataReader["Lastname"],
                    };

                    persons.Add(person);
                }
                dataReader.Close();
            }

            CloseConnection();
            return persons;
        }

        public void Delete(string id)
        {
            OpenConnection();
            string sql = $"DELETE FROM Person WHERE Id = '{id}'";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public void Update(string id, string firstName, string lastName)
        {
            OpenConnection();
            string sql = $"Update Person Set Firstname ='{firstName}',LastName='{lastName}' Where Id ='{id}'";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }
    }
}
