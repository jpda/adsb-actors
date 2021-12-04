using Dapr.Actors.Runtime;
using Adsb.Actors.Interfaces;
using Microsoft.Extensions.Logging;

namespace Adsb.Actors
{
    public class PlaneVehicleActor : Actor, IVehicleActor
    {
        public PlaneVehicleActor(ActorHost host) : base(host)
        {

        }

        protected override Task OnActivateAsync()
        {
            Console.WriteLine($"Activating actor id: {this.Id}");
            return Task.CompletedTask;
        }

        protected override Task OnDeactivateAsync()
        {
            Console.WriteLine($"Deactivating actor id: {this.Id}");
            return Task.CompletedTask;
        }

        public async Task<Position> GetPositionAsync()
        {
            this.Logger.LogInformation("Getting position state at {CurrentTime}", DateTime.UtcNow);
            return await this.StateManager.GetStateAsync<Position>("position");
        }

        public async Task SetPositionAsync(Position positionData)
        {
            this.Logger.LogInformation("Setting position at {CurrentTime}", DateTime.UtcNow);
            await this.StateManager.SetStateAsync<Position>("position", positionData);
        }
    }
}