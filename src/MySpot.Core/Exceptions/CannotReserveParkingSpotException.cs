using MySpot.Core.ValueObjects;

namespace MySpot.Core.Exceptions;

public sealed class CannotReserveParkingSpotException : CustomException
{
    public ParkingSpotId ParkingsSpotId { get; }

    public CannotReserveParkingSpotException(ParkingSpotId parkingSpotId) 
        : base($"Cannot reserve parking spot with ID: {parkingSpotId}")
    {
        ParkingsSpotId = parkingSpotId;
    }
}