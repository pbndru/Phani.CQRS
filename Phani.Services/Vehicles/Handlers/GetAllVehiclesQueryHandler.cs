using MediatR;
using Phani.Services.Models;
using Phani.Services.Vehicles.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Phani.Services.Vehicles.Handlers
{


    //This handler will handle information coming in and going out
    // GetAllVehiclesQuery is coming in
    // IEnumerable<Vehicle> is going out. param is a unit, so its not mandatory to return anything
    public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, IEnumerable<Vehicle>>
    {
        //can do dependency injection here like database things
        public GetAllVehiclesQueryHandler()
        {

        }

        public async Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
        {
            return new[]
            {
                new Vehicle { Name = $"Train {request.AuthorizedId}" },
                new Vehicle { Name = "Bus" },
            };
        }
    }
}
