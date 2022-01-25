using System.Collections.Generic;
using MediatR;
using Phani.Services.Models;

namespace Phani.Services.Vehicles.Queries
{
    //This is a command query
    public class GetAllVehiclesQuery : BaseRequest, IRequest<IEnumerable<Vehicle>>
    {
    }
}
