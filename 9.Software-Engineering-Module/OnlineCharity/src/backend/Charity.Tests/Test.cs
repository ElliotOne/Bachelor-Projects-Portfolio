using Charity.App.Entities;
using Charity.App.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace Charity.Tests
{
    [TestFixture]
    public class Tests
    {
        public DonationService DonationService;
        public PersonService PersonService;
        public PresentService PresentService;
        public UserService UserService;

        [SetUp]
        public void Setup()
        {
            DonationService = new DonationService();
            PersonService = new PersonService();
            PresentService = new PresentService();
            UserService = new UserService();

            DonationService.DataBase = new List<Donation>();
            PersonService.DataBase = new List<Person>();
            PresentService.DataBase = new List<Present>();
            UserService.DataBase = new List<User>();
        }


        #region Dontation Service Tests


        [Test]
        public void DonationServiceDonate_NoBugs_ShouldReturnTrue()
        {
            //Arrange
            var user = new User()
            {
                Id = 1,
                FirstName = "Yasin",
                LastName = "Fakhar",
                Address = "Shahreza"
            };
            var present = new Present()
            {
                Category = "Cloth",
                Description = "A beautiful T-shirt.",
                PicturePath = "/uploads/yasin/tshirt.jpeg"
            };

            //Act
            var result = DonationService.Donate(present, user);

            //Assert
            Assert.IsTrue(result);
        }


        #endregion



        #region Person Service Tests


        [Test]
        public void PersonServiceInsert_NoBugs_ShouldReturnTrue()
        {
            //Arrange
            var person = new Person()
            {
                UserName = "Ali234",
                Password = "@liPass",
                Role = "Role1"
            };

            //Act
            PersonService.Insert(person);

            //Assert
            var personFromDb = PersonService.Get(person.UserName);
            Assert.IsNotNull(personFromDb);
        }

        [Test]
        public void PersonServiceSignIn_PersonNotFound_ShouldReturnFalse()
        {
            //Arrange
            var person = new Person()
            {
                UserName = "Ali234",
                Password = "@liPass",
                Role = "Role1"
            };

            //Act
            var result = PersonService.SignIn(person.UserName, person.Password);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void PersonServiceSignIn_PersonIsFound_ShouldReturnTrue()
        {
            //Arrange
            var person = new Person()
            {
                UserName = "Ali234",
                Password = "@liPass",
                Role = "Role1"
            };

            //Act
            PersonService.Insert(person);
            var result = PersonService.SignIn(person.UserName, person.Password);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void PersonServiceLogIn_PersonNotFound_ShouldReturnFalse()
        {
            //Arrange
            var person = new Person()
            {
                UserName = "Ali234",
                Password = "@liPass",
                Role = "Role1"
            };

            //Act
            var result = PersonService.LogIn(person.UserName, person.Password, person.Role);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void PersonServiceLogIn_PersonIsFound_ShouldReturnTrue()
        {
            //Arrange
            var person = new Person()
            {
                UserName = "Ali234",
                Password = "@liPass",
                Role = "Role1"
            };

            //Act
            PersonService.Insert(person);
            var result = PersonService.LogIn(person.UserName, person.Password, person.Role);

            //Assert
            Assert.IsTrue(result);
        }


        #endregion



        #region Present Service Tests


        [Test]
        public void PresentServiceAddToCharity_NoBugs_ShouldRerunTrue()
        {
            //Arrange
            var present = new Present()
            {
                Id = 1,
                Category = "Cloth",
                Description = "A beautiful T-shirt",
                PicturePath = "/uploads/presents/cloth/1/t-shirt.jpeg"
            };

            //Act
            var result = PresentService.AddToCharity(present);

            //Assert
            var presentFromDb = PresentService.Get(present.Id);
            Assert.IsNotNull(presentFromDb);
            Assert.IsTrue(result);
        }

        [Test]
        public void PresentServiceRemoveFromCharity_PresentNotFound_ShouldReturnFalse()
        {
            //Arrange
            var present = new Present();

            //Act
            var result = PresentService.RemoveFromCharity(present);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void PresentServiceRemoveFromCharity_PresentIsFound_ShouldReturnTrue()
        {
            //Arrange
            var present = new Present()
            {
                Id = 1,
                Category = "Cloth",
                Description = "A beautiful T-shirt",
                PicturePath = "/uploads/presents/cloth/1/t-shirt.jpeg"
            };

            //Act
            PresentService.AddToCharity(present);
            var result = PresentService.RemoveFromCharity(present);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void PresentServiceDeliverToUser_NoBugs_ShouldReturnTrue()
        {
            //Arrange
            var present = new Present();
            var user = new User();

            //Act
            var result = PresentService.DeliverToUser(present, user);

            //Assert
            Assert.IsTrue(result);
        }


        #endregion




        #region User Service Tests


        [Test]
        public void UserServiceInsert_NoBugs_ShouldReturnTrue()
        {
            //Arrange
            var user = new User()
            {
                Id = 1,
                FirstName = "Ali",
                LastName = "Momenzadeh",
                PhoneNumber = "09130000000",
                Address = "Isfahan"
            };

            //Act
            UserService.Insert(user);

            //Assert
            var userFromDb = UserService.Get(1);
            Assert.IsNotNull(userFromDb);
        }

        [Test]
        public void UserServiceUpdate_UserNotFound_ShouldReturnFalse()
        {
            //Arrange
            var user = new User();

            //Act
            var result = UserService.Update(user);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void UserServiceUpdate_UserIsFound_ShouldReturnTrue()
        {
            //Arrange
            var user = new User()
            {
                Id = 1,
                FirstName = "Ali",
                LastName = "Momenzadeh",
                PhoneNumber = "09130000000",
                Address = "Isfahan"
            };

            //Act
            UserService.Insert(user);
            var result = UserService.Update(user);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void UserServiceRemove_UserNotFound_ShouldReturnFalse()
        {
            //Arrange
            var user = new User();

            //Act
            var result = UserService.Remove(user);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void UserServiceRemove_UserIsFound_ShouldReturnTrue()
        {
            //Arrange
            var user = new User()
            {
                Id = 1,
                FirstName = "Ali",
                LastName = "Momenzadeh",
                PhoneNumber = "09130000000",
                Address = "Isfahan"
            };

            //Act
            UserService.Insert(user);
            var result = UserService.Remove(user);

            //Assert
            Assert.IsTrue(result);
        }

        #endregion


    }
}