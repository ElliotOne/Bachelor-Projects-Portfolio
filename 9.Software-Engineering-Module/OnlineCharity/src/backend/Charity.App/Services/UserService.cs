using Charity.App.Entities;
using System.Collections.Generic;

namespace Charity.App.Services
{
    public class UserService
    {
        public static List<User> DataBase = new List<User>();

        public User Get(int id)
        {
            return DataBase.Find(x => x.Id == id);
        }

        public void Insert(User user)
        {
            DataBase.Add(user);
        }

        public bool Update(User user)
        {
            var userFromDb = DataBase.Find(x => x.Id == user.Id);
            if (userFromDb != null)
            {
                userFromDb.FirstName = user.FirstName;
                userFromDb.LastName = user.LastName;
                userFromDb.PhoneNumber = user.PhoneNumber;
                userFromDb.Address = user.Address;

                DataBase.Remove(userFromDb);
                DataBase.Add(userFromDb);

                return true;
            }

            return false;
        }

        public bool Remove(User user)
        {
            return DataBase.Remove(user);
        }
    }
}
