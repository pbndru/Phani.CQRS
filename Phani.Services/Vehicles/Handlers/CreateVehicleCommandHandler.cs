using Phani.Services.Models;
using Phani.Services.Vehicles.Commands;
using Phani.Services.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace Phani.Services.Vehicles.Handlers
{
    public class CreateVehicleCommandHandler : IHandleWrapper<CreateVehicleCommand, Vehicle>
    {
        public Task<Response<Vehicle>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(BaseResponse.Success(new Vehicle { Name = "Express Train" }, "Created Succesfully"));
        }
    }
}
