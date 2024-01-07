using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DB
{
    public class SearchTable
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;

        public SearchTable()
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
        public List<SearchResult> Search1(string personId)
        {
            List<SearchResult> searchResults = new List<SearchResult>();

            OpenConnection();
            string sql =
                $"Select Offense.CarCode,Sum(Price)  AS PriceSum, Person.Id From " +
                $"Offense Join Person On Person.Id = Offense.PersonId " +
                $"Join Car on Car.CarCode = Offense.CarCode " +
                $"Where Person.Id = '{personId}'" +
                $"Group By Person.Id,Offense.CarCode";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    SearchResult result = new SearchResult
                    {
                        PriceSum = double.Parse(dataReader["PriceSum"].ToString()),
                        CarCode = (string)dataReader["CarCode"],
                        PersonId = (string)dataReader["Id"]
                    };

                    searchResults.Add(result);
                }
                dataReader.Close();
            }

            CloseConnection();
            return searchResults;
        }

        public List<SearchResult> Search2(string personId, DateTime date)
        {
            List<SearchResult> searchResults = new List<SearchResult>();

            OpenConnection();
            string sql = $"Select * From Offense Join Person On Person.Id = Offense.PersonId" +
                         $" Join Car on Car.CarCode = Offense.CarCode" +
                         $" Where Person.Id = '{personId}' And Offense.CreateDate <= '{date}'";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    SearchResult result = new SearchResult
                    {
                        PersonId = (string)dataReader["PersonId"],
                        CarCode = (string)dataReader["CarCode"],
                        CreateDate = (DateTime)dataReader["CreateDate"],
                    };

                    searchResults.Add(result);
                }
                dataReader.Close();
            }

            CloseConnection();
            return searchResults;
        }

        public List<SearchResult> Search3(string carCode)
        {
            List<SearchResult> searchResults = new List<SearchResult>();

            OpenConnection();
            string sql = $"Select Offense.CarCode,Sum(Price) AS PriceSum " +
                         $",Person.Id,Person.Firstname,Person.Lastname From Offense" +
                         $" Join Person On Person.Id = Offense.PersonId" +
                         $" Join Car on Car.CarCode = Offense.CarCode Where Car.CarCode = '{carCode}'" +
                         $" Group By Offense.CarCode, Person.Id,Person.Firstname,Person.Lastname";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    SearchResult result = new SearchResult
                    {
                        CarCode = (string)dataReader["CarCode"],
                        PriceSum = double.Parse(dataReader["PriceSum"].ToString()),
                        PersonId = (string)dataReader["Id"],
                        Firstname = (string)dataReader["Firstname"],
                        Lastname = (string)dataReader["Lastname"]
                    };

                    searchResults.Add(result);
                }
                dataReader.Close();
            }

            CloseConnection();
            return searchResults;
        }

    }
}
