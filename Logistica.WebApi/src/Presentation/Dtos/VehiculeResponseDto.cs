using Logistica.WebApi.Api.Dtos;

namespace Logistica.WebApi.Infrastructure.Entities
{
    public class VehiculeResponseDto
    {
        public string Patent { get; set; }
        public RouteResponseDto Route { get; set; }

        public bool Available { get; set; }
    }
}
