using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logistica.WebApi.Api.Dtos
{
    public class RouteNodeRequestDto
    {
        public  NodeDto SourceNode { get; set; }
        public  NodeDto DestinationNode { get; set; }
    }
}
