using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Commands
{
    public interface ICommandDispather
    {
        Task DispathAsync<T>(T command) where T : ICommand;
    }
}
