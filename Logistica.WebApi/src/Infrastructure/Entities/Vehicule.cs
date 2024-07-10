using System.ComponentModel.DataAnnotations.Schema;

namespace Logistica.WebApi.Infrastructure.Entities
{
    public class Vehicule
    {
        public int Id { get; set; }
        public string Patent { get; set; }
        public int RouteId { get; set; }

        [ForeignKey("RouteId")]
        public Route RouteNavigation { get; set; }

        public bool Available { get; set; }
    }
}
