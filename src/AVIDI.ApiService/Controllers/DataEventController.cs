using AVIDI.ApiService.Constants;
using AVIDI.ApiService.Data.Repository.Interfaces;
using AVIDI.ApiService.Models;
using Microsoft.AspNetCore.Mvc;

namespace AVIDI.ApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataEventController : ControllerBase
    {
        private readonly IDataEventRepository<DateEvent> Client;
        public DataEventController(IDataEventRepository<DateEvent> client)
        {
            Client = client;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int year, string month)
        {
            var dataEvent = await Client.GetEventsAsync(year, month);

            return Ok(dataEvent);
        }

        [HttpPost(RepoDataEvent.Add)]
        public async Task<IActionResult> Add([FromBody] DateEvent entity)
        {
             await Client.AddAsync(entity);

            return Created("", "");
        }
    }
}
