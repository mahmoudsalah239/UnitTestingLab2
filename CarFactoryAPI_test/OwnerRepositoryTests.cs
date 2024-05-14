using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryAPI_test
{
    public class OwnerRepositoryTests
    {
        private Mock<FactoryContext> factoryContextMock;
        private OwnerRepository ownerRepository;
        public OwnerRepositoryTests()
        {
            factoryContextMock = new Mock<FactoryContext>();

            ownerRepository = new OwnerRepository(factoryContextMock.Object);
        }

        [Fact]
        [Trait("Author", "Anas")]
        public void GetOwnerById_AskForOwner10_ReturnOwner()
        {
            
            List<Owner> owners = new List<Owner>() { new Owner() { Id = 10 } };

            factoryContextMock.Setup(fcm => fcm.Owners).ReturnsDbSet(owners);

     
            Owner owner = ownerRepository.GetOwnerById(10);


            Assert.NotNull(owner);
        }

        [Fact]
        [Trait("Author", "Anas")]
        public void GetAllOwner_ReturnListOfOwner()
        {

            List<Owner> owners = new List<Owner>() { new Owner() { Id = 10 } };

            factoryContextMock.Setup(fcm => fcm.Owners).ReturnsDbSet(owners);


            List<Owner> owners1 = ownerRepository.GetAllOwners();


            Assert.NotNull(owners1);
        }
    }
}
