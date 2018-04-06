using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using ProgrammingChallenge_Data;
using ProgrammingChallenge_Service; 

namespace ProgrammingChallenge_Test
{
    [TestFixture]
    public class PersonServiceTest
    {
        private Mock<IPersonRepository> MockPersonRepository { get; set; }
        private PersonService PersonService { get; set; }

        [SetUp]
        public void Setup()
        {
            MockPersonRepository = new Mock<IPersonRepository>(); 
        }

        [Test]
        public void CheckWhetherNullPetsAreNotIncludedInList()
        {
            //Arrange
            var data = "[{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\r\n\"pets\":\r\nnull\r\n}]";
            MockPersonRepository.Setup(x => x.GetPetsListData()).ReturnsAsync(data);
            PersonService = new PersonService(MockPersonRepository.Object);
            //Act
            var output = PersonService.GetPersonsList();
            //Assert
            MockPersonRepository.Verify(x => x.GetPetsListData(), Times.Once);
            Assert.AreEqual(output.Count, 0);
        }

        [Test]
        public void CheckWhetherGetPersonsListMethodProduceCorrectList()
        {
            //Arrange
            var data = "[{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\r\n\"pets\":\r\n[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]\r\n},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\r\n\"pets\":\r\n[{\"name\":\"Garfield\",\"type\":\"Cat\"}]\r\n}]";
            MockPersonRepository.Setup(x => x.GetPetsListData()).ReturnsAsync(data);
            PersonService = new PersonService(MockPersonRepository.Object);
            //Act
            var output = PersonService.GetPersonsList();
            //Assert
            MockPersonRepository.Verify(x => x.GetPetsListData(), Times.Once);
            //Female count 1
            Assert.AreEqual(1, output.Count); 
            Assert.AreEqual("Female",output.Keys.ToList()[0]);
            Assert.AreEqual(2, output["Female"].Count);
            Assert.AreEqual("Garfield", output["Female"][0].Name);
            Assert.AreEqual("Simba", output["Female"][1].Name);
        }

        [Test]
        public void ShouldThrowExceptionIfDataReturnedFromRepositoryIsNull()
        {
            //Arrange
            PersonService = new PersonService(MockPersonRepository.Object);
            //Act
            var ex = Assert.Throws<ArgumentNullException>(() => PersonService.GetPersonsList());
            //Assert
            Assert.AreNotEqual(ex, null);
        }
    }
}
