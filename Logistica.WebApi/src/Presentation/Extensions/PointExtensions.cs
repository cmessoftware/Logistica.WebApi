using NetTopologySuite.Geometries;


namespace Logistica.WebApi.Api.Extensions
{
 
    public static class PointExtensions
    {
        public static bool IsEmpty(this Point point)
        {
            return point == null || point.IsEmpty;
        }
    }
}
