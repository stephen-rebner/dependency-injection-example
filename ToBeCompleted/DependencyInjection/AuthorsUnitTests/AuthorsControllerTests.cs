using NUnit.Framework;
using DependencyInjection.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace AuthorsUnitTests
{
    public class Tests
    {

        private AuthorsController _authorsController;

        [SetUp]
        public void Setup()
        {
            // todo: inject a mock service into the controller
            //_authorsController = new AuthorsController();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Get_ShouldReturnBadRequest_WhenSearchTermIsNullOrEmpty(string searchTerm)
        {
            var result = _authorsController.Get(searchTerm);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Test]
        public void Get_ShouldReturnOkResult_WhenSearchTermIsSupplied()
        {
            // todo: add unit test, mocking out the service call
            Assert.IsTrue(false);
        }
    }
}