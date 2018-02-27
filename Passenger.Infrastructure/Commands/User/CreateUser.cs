using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Passenger.Infrastructure.Commands.User
{
    public class CreateUser : ICommand
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
