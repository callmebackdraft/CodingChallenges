using Microsoft.AspNetCore.Mvc;
using InnoTractor.Assignment2Logic;

namespace InnoTractor.Assignment.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static string?[] Values()
        {
            return new string?[] {
                "42",
                "1e3",
                "1.222",
                null,
                "-12"
            };
        }

        private ValuesService _valuesService;

        public ValuesController()
        {
            _valuesService = new ValuesService(Values());
        }

        [HttpGet]
        [Route("/values")]
        public ContentResult Get()
        {
            return Content(_valuesService.GetSumOfValues().ToString());
        }
    }
}
