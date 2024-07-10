namespace Logistica.WebApi.Api.Dtos
{
    public class RouteNodeShorterRequestDto
    {
        public  string SourceNode { get; set; }
        public  List<string> DestinationNodes { get; set; }
    }
}
