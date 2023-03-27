using Microsoft.AspNetCore.Mvc;
using InnoTractor.Assignment3Logic;

namespace InnoTractor.Assignment.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class RunningTotalController : ControllerBase
    {
        private readonly IRunningTotal service;
        public RunningTotalController(IRunningTotal rtService)
        {
            service = rtService;
        }

        [HttpPut]
        [Route("/runningtotal")]
        [Consumes("text/plain")]
        public ContentResult Put([FromBody] int number)
        {
            return Content(service.CheckRunningTotal(number).ToString());
        }
    }
}
