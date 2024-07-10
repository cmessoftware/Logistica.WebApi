using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logistica.WebApi.Api.Dtos
{
    public class RouteNodeShorterRequestDto
    {
        public  NodeDto SourceNode { get; set; }
        public  List<NodeDto> DestinationNodes { get; set; }
    }
}
