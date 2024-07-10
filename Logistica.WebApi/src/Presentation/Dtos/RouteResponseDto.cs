using Logistica.WebApi.Api.Extensions;
using NetTopologySuite.Geometries;
using System.Text.Json.Serialization;

namespace Logistica.WebApi.Api.Dtos
{


    public class RouteResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RouteNodeResponseDto SourceNode { get; set; }
        public RouteNodeResponseDto DestinationNode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
      
    }

}
