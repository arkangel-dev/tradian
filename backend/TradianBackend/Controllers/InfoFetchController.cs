using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradianBackend.Database;

namespace TradianBackend.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class InfoFetchController : ControllerBase {


        private DatabaseContext context;
        public InfoFetchController(DatabaseContext context) {
            this.context = context; 
        }

        [HttpGet("DeclarationStatus")]
        public IActionResult DeclarationStatusFetch(
            [FromQuery]
            string CNumber,

            [FromQuery]
            string RNumber
        ) {
            var result = context.Declarations
                .SingleOrDefault(x => 
                    x.CNumber == CNumber &&
                    x.RNumber == RNumber
                );
            if ( result is null) {
                return NotFound("No such code found");
            } else {
                return Ok(result.Status);
            }
        }

        [HttpGet("ContainerStatus")]
        public IActionResult ContainerStatusFetch(
            [FromQuery]
            string ContainerId     
        ) {
            var result = context.Containers
                .SingleOrDefault(x => x.ContainerName == ContainerId);

            return result is not null ?
                Ok(result.Status) :
                NotFound("No such container found");
        }
    }
}
