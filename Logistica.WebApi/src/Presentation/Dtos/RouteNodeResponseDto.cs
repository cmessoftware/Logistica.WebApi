using Logistica.WebApi.Api.Extensions;
using NetTopologySuite.Geometries;
using System.Text.Json.Serialization;

namespace Logistica.WebApi.Api.Dtos
{
    public class RouteNodeResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonNumberHandling(JsonNumberHandling.AllowNamedFloatingPointLiterals)]
        public double Distance { get; set; }

    
        [JsonIgnore]
        public Point Location { get; set; }

        public double? Latitude => Location.IsEmpty() ? (double?)null : Location.Y;

        public double? Longitude => Location.IsEmpty() ? (double?)null : Location.X;

    }
}
