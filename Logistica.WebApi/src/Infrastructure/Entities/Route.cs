using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.WebApi.Infrastructure.Entities
{
    public class Route
    {
        public int Id{ get; set; } 
        public string Name { get; set; }

        public int SourceNodeId { get; set; }
        public int DestinationNodeId { get; set; }

        [ForeignKey("SourceNodeId")]
        public RouteNode SourceNodeNavigation { get; set; }

        [ForeignKey("DestinationNodeId")]
        public RouteNode DestinationNodeNavigation { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public List<Vehicule> Vehicules { get; set;}

    }
}
