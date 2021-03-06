﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Commands
{
    public class CommandDispather : ICommandDispather
    {
        private readonly IComponentContext _context;

        public CommandDispather(IComponentContext context)
        {
            _context = context;
        }

        public async Task DispathAsync<T>(T command) where T : ICommand
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command), $"Command: '{typeof(T).Name}' can not be null.");
            }
            var handler = _context.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command);
        }
    }
}
