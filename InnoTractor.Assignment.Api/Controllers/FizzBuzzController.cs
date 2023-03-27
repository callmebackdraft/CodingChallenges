using Microsoft.AspNetCore.Mvc;
using InnoTractor.Assignment1Logic;

namespace InnoTractor.Assignment.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class FizzBuzzController : Controller
    {
        [HttpGet]
        [Route("/fizzbuzz")]
        public JsonResult FizzBuzz(int depth = 30)
        {
            return new JsonResult(FizzBuzzService.Get(depth));
        }
    }
}
