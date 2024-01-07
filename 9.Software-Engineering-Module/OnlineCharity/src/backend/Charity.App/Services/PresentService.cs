using Charity.App.Entities;
using System.Collections.Generic;

namespace Charity.App.Services
{
    public class PresentService
    {
        public static List<Present> DataBase = new List<Present>();

        public Present Get(int id)
        {
            return DataBase.Find(x => x.Id == id);
        }

        public bool AddToCharity(Present present)
        {
            DataBase.Add(present);
            return true;
        }

        public bool RemoveFromCharity(Present present)
        {
            return DataBase.Remove(present);
        }

        public bool DeliverToUser(Present present, User user)
        {
            //login to deliver present to the user

            return true;
        }
    }
}
