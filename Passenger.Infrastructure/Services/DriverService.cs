using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;
using System;

namespace Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {

        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public DriverDto Get(Guid userid)
        {
            var driver = _driverRepository.Get(userid);

            return new DriverDto
            {
                //id 
            };
        }
    }
}