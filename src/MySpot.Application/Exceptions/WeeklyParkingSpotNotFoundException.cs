using MySpot.Core.Exceptions;

namespace MySpot.Application.Exceptions;

public sealed class WeeklyParkingSpotNotFoundException : CustomException
{
    public Guid Id { get; set; }
    public WeeklyParkingSpotNotFoundException(Guid id) 
        : base($"Weekly parking spot with ID: {id} was not found")
    {
        Id = id;
    }

    public WeeklyParkingSpotNotFoundException() : base($"Weekly parking spot was not found")
    {
        
    }
}