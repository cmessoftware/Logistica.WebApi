using NetTopologySuite.Geometries;

namespace Logistica.WebApi.Api.Dtos
{
    public class NodeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Distance { get; set; }
        public Point Location { get; set; }

    }
}
