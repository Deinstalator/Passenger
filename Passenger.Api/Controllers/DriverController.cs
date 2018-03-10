using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using System.Threading.Tasks;

namespace Passenger.Api.Controllers
{
    public class DriverController : ApiControllerBase
    {
        public DriverController(ICommandDispather commandDispather) : base(commandDispather)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Put([FromBody]CreateDriver command)
        {
            await CommandDispather.DispathAsync(command);

            return NoContent();
        }
    }
}
