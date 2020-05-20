using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {

        private readonly AuthorsService _authorsService;

        public AuthorsController()
        {
            // todo: decouple the concrete implementation of the Authors service 
            // from the Controller
            _authorsService = new AuthorsService();
        }

        [HttpGet]
        public IActionResult Get(string searchTerm)
        {

            if(string.IsNullOrWhiteSpace(searchTerm))
            {
                return new BadRequestObjectResult("Please provide a search term");
            }

            var authors = _authorsService.SearchAuthors(searchTerm);

            return new OkObjectResult(authors);
        }
    }
}
