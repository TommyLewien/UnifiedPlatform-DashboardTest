using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Discom.UP.Backend.UpDash.Interfaces.Infrastructure;
using Discom.UP.Backend.UpDash.Interfaces.FromWebPal;

namespace Discom.UP.Backend.UpDash.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {
        private readonly ILogger<StorageController> _logger;
        private readonly UpConnectionUrl _connectionUrl;


        public StorageController(ILogger<StorageController> logger, IOptions<UpConnectionUrl> connectionUrlOption)
        {
            _logger = logger;
            _connectionUrl = connectionUrlOption.Value;

        }
        

        [HttpPost("Load")]
        public IActionResult Load([FromBody] SerObject svalue)
        {
            return Ok(svalue);

        }


        [HttpPost("Store")]
        public IActionResult Store([FromBody] SerObject svalue)
        {
              
            return NoContent();
         
        }


    }
}
