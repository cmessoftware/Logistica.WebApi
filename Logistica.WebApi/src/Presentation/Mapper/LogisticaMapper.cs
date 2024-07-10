using AutoMapper;
using Logistica.WebApi.Api.Dtos;
using Logistica.WebApi.Infrastructure.Entities;

namespace Logistica.WebApi.Application.Mapper
{
    public class LogisticaMapper : Profile
    {
        public LogisticaMapper()
        {
            CreateMap<RouteNode,NodeDto>().ReverseMap()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => new NetTopologySuite.Geometries.Point(src.Location.X, src.Location.Y) { SRID = src.Location.SRID }));

            CreateMap<RouteNode, RouteNodeResponseDto>().ReverseMap();

            CreateMap<VehiculeResponseDto, Vehicule>().ReverseMap()
                .ForMember(dest => dest.Route, opt => opt.MapFrom((src, dst) =>
                {
                    if (src.RouteNavigation == null)
                        return null;

                    return new RouteResponseDto
                    {
                        Id = src.RouteNavigation.Id,
                        Name = src.RouteNavigation.Name,
                        ToDate = src.RouteNavigation.ToDate,
                        FromDate = src.RouteNavigation.FromDate,
                        DestinationNode = new RouteNodeResponseDto
                        {
                            Id = src.RouteNavigation.DestinationNodeNavigation.Id,
                            Name = src.RouteNavigation.DestinationNodeNavigation.Name,
                            Distance = src.RouteNavigation.DestinationNodeNavigation.Distance,
                            Location = src.RouteNavigation.DestinationNodeNavigation.Location
                        },
                        SourceNode = new RouteNodeResponseDto
                        {
                            Id = src.RouteNavigation.SourceNodeNavigation.Id,
                            Name = src.RouteNavigation.SourceNodeNavigation.Name,
                            Distance = src.RouteNavigation.SourceNodeNavigation.Distance,
                            Location = src.RouteNavigation.SourceNodeNavigation.Location
                        }
                    };
                }) );
                
        }
    }
}
