using Logistica.WebApi.Infrastructure.Entities;
using System.Text.Json.Serialization;

namespace Logistica.WebApi.Api.Dtos
{
    public class RouteNodeShorterResponseDto
    {
        public  int MinDistance { get; set; }

        [JsonPropertyName("shorterRoute")]
        public  List<RouteNodeResponseDto> RouteNodes { get; set; }
    }
}
