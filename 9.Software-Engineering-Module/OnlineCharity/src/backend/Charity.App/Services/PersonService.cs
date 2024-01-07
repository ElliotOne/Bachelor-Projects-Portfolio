using Charity.App.Entities;
using System.Collections.Generic;

namespace Charity.App.Services
{
    public class PersonService
    {
        public static List<Person> DataBase = new List<Person>();

        public Person Get(string username)
        {
            return DataBase.Find(x => x.UserName == username);
        }

        public void Insert(Person person)
        {
            DataBase.Add(person);
        }

        public bool SignIn(string userName, string password)
        {
            if (DataBase.Find(x => x.UserName == userName &&
                                   x.Password == password) != null)
            {
                return true;
            }

            return false;
        }

        public bool LogIn(string userName, string password, string role)
        {
            if (DataBase.Find(x => x.UserName == userName &&
                                   x.Password == password && x.Role == role) != null)
            {
                return true;
            }

            return false;
        }
    }
}
