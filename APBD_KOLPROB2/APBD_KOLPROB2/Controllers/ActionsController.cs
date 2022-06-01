using APBD_KOLPROB2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APBD_KOLPROB2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsController : ControllerBase
    {

        private readonly IDBService _dbService;
        public ActionsController(IDBService dBService)
        {
            _dbService = dBService;
        }

        [HttpGet("{idAction:int}")]
        public async Task<IActionResult>Get(int idAction)
        {
            var task = await _dbService.GetActionByIdAsync(idAction);
            return Ok(task);
        }

    }
}
