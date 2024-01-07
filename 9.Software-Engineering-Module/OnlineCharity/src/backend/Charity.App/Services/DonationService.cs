using Charity.App.Entities;
using System;
using System.Collections.Generic;

namespace Charity.App.Services
{
    public class DonationService
    {
        public static List<Donation> DataBase = new List<Donation>();
        public bool Donate(Present present, User user)
        {
            DataBase.Add(new Donation()
            {
                Date = DateTime.Now,
                Present = present,
                User = user
            });

            return true;
        }
    }
}
