﻿namespace MySpot.Application.DTO;

public class ReservationDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ParkingSpotId { get; set; }
    public string EmployeeName { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }
}
