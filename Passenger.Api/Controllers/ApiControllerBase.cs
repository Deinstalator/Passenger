using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Passenger.Api.Controllers
{
    [Route("[controller]")]

    public abstract class ApiControllerBase : Controller
    {
        protected readonly ICommandDispather CommandDispather;

        protected ApiControllerBase(ICommandDispather commandDispahter)
        {
            CommandDispather = commandDispahter;
        }
    }
}
