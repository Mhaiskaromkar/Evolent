using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Evolent.Entities;
using Evolent.Services.Interfaces;
using Evolent.WebAPI.Controllers;
using Moq;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace Evolent.WebAPI.Tests
{
    [TestClass]
    public class ContactControllerTest
    {
        [TestMethod]
        public void GetContacts_ShouldReturnAllContacts()
        {
            //Arrange
           var mockRepository = new Mock<IContactServices>();
           var ContactEntities = new List<ContactEntity>();

            ContactEntities.Add(new ContactEntity { FirstName = "test5", LastName = "test5", EmailAddress = "test5@in.com", PhoneNumber = "222-111-3333", IsActive = true });
            ContactEntities.Add(new ContactEntity { FirstName = "ajay", LastName = "ajay", EmailAddress = "ajay@in.com", PhoneNumber = "444-444-4444", IsActive = true });
           
            mockRepository
                .Setup(x => x.GetContacts())
                .Returns(ContactEntities);

            ContactController controller = new ContactController(mockRepository.Object);

            //Act            
            var result = controller.Get();
            //Assert
            Assert.IsNotNull(result);           

        }

        [TestMethod]
        public void GetContacts_ShouldReturnContactsWithSameID()
        {
            //Arrange
            var mockRepository = new Mock<IContactServices>();

            var ContactEntity = new ContactEntity();
            ContactEntity = new ContactEntity { ContactID = 3, FirstName = "test5", LastName = "test5", EmailAddress = "test5@in.com", PhoneNumber = "222-111-3333", IsActive = true };


            mockRepository
                .Setup(x => x.GetContactById(3))
                .Returns(ContactEntity);

            var controller = new ContactController(mockRepository.Object);
            var result = controller.GetContact(3) as OkNegotiatedContentResult<ContactEntity>;

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Content.ContactID);
        }
    }
}
