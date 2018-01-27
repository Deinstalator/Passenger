using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class Vehicle
    {
        public string Name { get; protected set; }

        public string Brand { get; set; }

        public int Seats { get; protected set; }
    }
}
