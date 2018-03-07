using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        public AccountController(ICommandDispather commandDispather) : base(commandDispather)
        {
        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await CommandDispather.DispathAsync(command);

            return NoContent();
        }
    }
}
