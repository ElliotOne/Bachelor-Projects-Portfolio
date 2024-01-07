using System;

namespace Charity.App.Entities
{
    public class Donation
    {
        public DateTime Date { get; set; }
        public Present Present { get; set; }
        public User User { get; set; }
    }
}
