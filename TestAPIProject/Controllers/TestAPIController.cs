using Microsoft.AspNetCore.Mvc;
using TestAPIProject.Data;
using TestAPI.Entity.Modeller;
using TestAPI.Entity.Modeller.Dto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using TestAPI.Buisness.Services;

namespace TestAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAPIController : ControllerBase
    {

        private readonly ITestService _testService;

        private readonly ILogger<TestAPIController> _logger;
        public TestAPIController(ILogger<TestAPIController> logger, ITestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TestDTO>> GetTests()
        {

            var tests = _testService.GetAllTests();
            return Ok(tests);
        }


        [HttpGet("{id}")]
        public IActionResult GetTest(int id)
        {

            var test = _testService.GetTestById(id);
            if (test == null)
            {
                return NotFound();
            }
            return Ok(test);
        }

        [HttpGet("/api/{name}")]
        public IActionResult GetTestByName(string name)
        {
            var test= _testService.GetTestByName(name);
            if(test == null)
            {
                return NotFound();
            }
            return Ok(test); 
        }

        [HttpPost]
        public IActionResult CreateTest([FromBody] TestDTO test)
        {
            _testService.CreateTest(test);
            return CreatedAtAction(nameof(GetTest), new { id = test.Id }, test);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTest(int id, [FromBody] TestDTO test)
        {
            if (id != test.Id)
            {
                return BadRequest();
            }

            _testService.UpdateTest(test);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchTestName(int id, string name, string url)
        {
            _testService.UpdateName(id, name, url);
            return Ok();
        }

        [HttpPatch("/API/{id}")]
        public IActionResult PatchTestWork(int id, int weekly, int daily)
        {
            _testService.UpdateWorkDetail(id, weekly, daily);
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteTest(int id)
        {
            _testService.DeleteTest(id);
            return NoContent();
        }

        [HttpDelete("/API/{name}")]
        public IActionResult DeleteTestByName(string name) {
            _testService.DeleteTestByName(name);
            return NoContent();
        }
    }
}

