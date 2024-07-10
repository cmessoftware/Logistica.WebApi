using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.WebApi.Infrastructure.Entities
{
    public class RouteNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Distance { get; set; }
        public Point Location { get; set; }
    }
}
