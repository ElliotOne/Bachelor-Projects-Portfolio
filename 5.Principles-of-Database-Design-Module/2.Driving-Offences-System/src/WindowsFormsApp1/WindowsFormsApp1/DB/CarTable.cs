using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace WindowsFormsApp1.DB
{
    public class CarTable
    {
        private readonly string _connectionString;
        private SqlConnection _sqlConnection;

        public CarTable()
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


        public void Create(string carCode, string type, DateTime createDate, string personId)
        {
            OpenConnection();
            string sql1 = $"Insert Into Car(CarCode,Type,CreateDate)" +
                         $"Values('{carCode}','{type}','{createDate}')";

            using (SqlCommand command = new SqlCommand(sql1, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }


            string sql2 = $"Insert Into PersonCar(CarCode,PersonId) " +
                          $"Values('{carCode}','{personId}')";
            using (SqlCommand command = new SqlCommand(sql2, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public void Delete(string carCode)
        {
            OpenConnection();
            string sql1 = $"DELETE FROM Car WHERE CarCode = '{carCode}'";

            using (SqlCommand command = new SqlCommand(sql1, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }

            CloseConnection();
        }
        public List<PersonWithCars> ReadAll()
        {
            List<PersonWithCars> personWithCars = new List<PersonWithCars>();

            OpenConnection();
            string sql = $"Select * From PersonCar Join Person On Person.Id = PersonCar.PersonId Join Car On Car.CarCode = PersonCar.CarCode";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    PersonWithCars pcars = new PersonWithCars
                    {
                        PersonId = (string)dataReader["PersonId"],
                        Firstname = (string)dataReader["Firstname"],
                        Lastname = (string)dataReader["Lastname"],
                        CarCode = (string)dataReader["CarCode"],
                        CreateDate = (DateTime)dataReader["CreateDate"],
                        Type = (string)dataReader["Type"],
                    };

                    personWithCars.Add(pcars);
                }
                dataReader.Close();
            }

            CloseConnection();
            return personWithCars;
        }


        public List<Car> ReadAllCars()
        {
            List<Car> cars = new List<Car>();

            OpenConnection();
            string sql = $"Select * From Car";

            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    Car car = new Car
                    {
                        CarCode = (string)dataReader["CarCode"],
                        CreateDate = (DateTime)dataReader["CreateDate"],
                        Type = (string)dataReader["Type"],
                    };

                    cars.Add(car);
                }
                dataReader.Close();
            }

            CloseConnection();
            return cars;
        }
    }
}
