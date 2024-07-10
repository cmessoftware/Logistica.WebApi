using Microsoft.AspNetCore.Mvc;
using Ardalis.Result;
using Logistica.WebApi.Api.Dtos;
using NetTopologySuite.Geometries;
using Logistica.WebApi.Infrastructure.Data;
using Logistica.WebApi.Infrastructure.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Logistica.WebApi.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class LogisticController : ControllerBase
{
    private readonly ILogger<LogisticController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public LogisticController(ApplicationDbContext context,
                           IMapper mapper, 
                           ILogger<LogisticController> logger)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    [HttpPost("shorter")]
    public async Task<ActionResult<Result<List<RouteResponseDto>>>> GetShorter(
        [FromBody] RouteNodeShorterRequestDto nodes)
    {
       


        return Ok();
       
    }
    /// <summary>
    /// 2) Retornar los últimos 10 recorridos realizados por un camión con patente X,
    /// ordenados por fecha desde el más actual hacia los primeros. (10)
    /// </summary>
    /// <returns></returns>
    [HttpGet("routes")]
    public async Task<ActionResult<Result<List<VehiculeRouteResponseDto>>>> GetRoutes(
        [FromQuery] string patent,
        [FromQuery] int cant
        )
    {
      
        var response = await _context.Vehicules
                               .Where(x => x.Patent == patent)     
                               .Include(x => x.RouteNavigation)
                               .OrderByDescending(x => x.RouteNavigation.FromDate)
                               .Take(cant)
                               .ToListAsync();


        return Ok(response);

    }

    /// <summary>
    /// 4) Retornar los camiones que están en viaje y en qué tramo o ciudad se encuentran
    /// </summary>
    /// <returns></returns>
    [HttpGet("vehicules/travel")]
    public async Task<ActionResult<Result<List<RouteResponseDto>>>> GetVehiculesInTravel()
    {
        var result = await _context.Vehicules
                               .Where(x => !x.Available)
                               .Include(x => x.RouteNavigation)
                               .Include(x => x.RouteNavigation.SourceNodeNavigation)
                               .Include(x => x.RouteNavigation.DestinationNodeNavigation)
                               .ToListAsync();

        var response = _mapper.Map<List<VehiculeResponseDto>>(result);

        return Ok(response);

    }

    /// <summary>
    /// 3) Retornar los camiones disponibles para hacer un viaje.
    /// </summary>
    /// <returns></returns>

    [HttpGet("vehicules/available")]
    public async Task<ActionResult<Result<List<VehiculeResponseDto>>>> GetVehiculesAvailable()
    {
        var vehicules = await _context.Vehicules.Where(x => x.Available)
                               .Include(x => x.RouteNavigation)
                               .Include(x => x.RouteNavigation.SourceNodeNavigation)
                               .Include(x => x.RouteNavigation.DestinationNodeNavigation)
                               .ToListAsync();

        var response = _mapper.Map<List<VehiculeResponseDto>>(vehicules);

        return Ok(response);

    }



    [HttpPost]
    public async Task<ActionResult<Result<List<RouteResponseDto>>>> CreateNode()
    {

        _context.Database.EnsureCreated();

        var node = new RouteNode
        {
            Name = "Otawa",
            Location = new Point(45.4215, -75.6972) // Example coordinates for Ottawa, Canada
            {
                SRID = 4326
            },
            Distance = 0

        };

        _context.RouteNodes.Add(node);
        await _context.SaveChangesAsync();

        var nodeDto = _mapper.Map<RouteNodeResponseDto>(node);


        var response = new RouteResponseDto
        {
           DestinationNode = nodeDto,
           SourceNode = nodeDto
        };

        return Ok(response);
    }

}