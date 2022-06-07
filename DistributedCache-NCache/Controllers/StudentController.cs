using DistributedCache_NCache.Extensions;
using DistributedCache_NCache.Models;
using DistributedCache_NCache.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace DistributedCache_NCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent<Student> _studentService;
        private readonly IDistributedCache _cache;

        public StudentController(IStudent<Student> studentService, IDistributedCache cache)
        {
            _studentService = studentService;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string cacheKey = "StudentList_" + DateTime.Now.ToString("yyyyMMdd_hhmm");

            var student = await _cache.GetRecordAsync<List<Student>>(cacheKey);

            if (student is null)
            {
                student = (List<Student>)await _studentService.ListAllAsync();

                await _cache.SetRecordAsync(cacheKey, student);
            }

            return Ok(student);
        }
    }
}
