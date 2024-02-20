using Microsoft.EntityFrameworkCore;
using MySpot.Application.Abstractions;
using MySpot.Application.DTO;
using MySpot.Application.Queries;
using MySpot.Application.Queries.Handlers;
using MySpot.Core.ValueObjects;
using MySpot.Infrastructure.DAL;

namespace MySpot.Infrastructure.Handlers;

internal sealed class GetWeeklyParkingSpotsHandler : IQueryHandler<GetWeeklyParkingSpots, IEnumerable<WeeklyParkingSpotDto>>
{
    private readonly MySpotDbContext _dbContext;

    public GetWeeklyParkingSpotsHandler(MySpotDbContext dbContext)
        =>_dbContext = dbContext;


    public async Task<IEnumerable<WeeklyParkingSpotDto>> HandleAsync(GetWeeklyParkingSpots query)
    {
        var week = query.Date.HasValue ? new Week(query.Date.Value) : null;
        var weeklyParkingSpots = await _dbContext.WeeklyParkingSpots
            .Where(x => week == null || x.Week == week)
            .Include(x => x.Reservations)
            .AsNoTracking()
            .ToListAsync();

        return weeklyParkingSpots.Select(x => x.AsDto());
    }
}