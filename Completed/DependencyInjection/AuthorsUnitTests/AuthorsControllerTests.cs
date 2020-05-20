using NUnit.Framework;
using DependencyInjection.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Services;
using Moq;
using DependencyInjection;
using System.Collections.Generic;

namespace AuthorsUnitTests
{
    public class Tests
    {

        private Mock<IAuthorsService> _authorsService;
        private AuthorsController _authorsController;

        [SetUp]
        public void Setup()
        {
            _authorsService = new Mock<IAuthorsService>();
            _authorsController = new AuthorsController(_authorsService.Object);
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
            _authorsService.Setup(x => x.SearchAuthors("Wallace"))
                .Returns(new List<Author>());

            var result = _authorsController.Get("Wallace") as OkObjectResult;

            var resultValue = (List<Author>)result.Value;

            resultValue.Should().BeEmpty();
        }
    }
}