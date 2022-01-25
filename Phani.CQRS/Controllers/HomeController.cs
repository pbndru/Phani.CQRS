using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phani.Services;
using Phani.Services.Models;
using Phani.Services.Vehicles.Commands;
using Phani.Services.Vehicles.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phani.CQRS.Controllers
{
    [ApiController]
    [Route("vehicles")]
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //here where handler is returning
        [HttpGet]
        public Task<IEnumerable<Vehicle>> Index([FromQuery] GetAllVehiclesQuery query)
        {
            
            return mediator.Send(query);

            // if you are not populating the query form body route, you can use the type as below
            // return mediator.Send(new GetAllVehiclesQuery());
        }

        [HttpPost]
        public Task<Response<Vehicle>> Index([FromQuery] CreateVehicleCommand command)
        {
            return mediator.Send(command);
        }
    }
}
