using Application.Interfaces.Services;
using Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SMPC.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController(ITestService testService) : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetOrganigram()
        {
            var org = await testService.GetOrganigram();

            if (org == null)
                return NotFound();
            return Ok(org);
        }
    }
}
