﻿using MySpot.Core.ValueObjects;

namespace MySpot.Core.Entities;

public class Reservation
{
    public ReservationId Id { get; private set; }
    public ParkingSpotId ParkingSpotId { get; private set; }
    public Capacity Capacity { get; set; }
    public Date Date { get; private set; }
    
    protected Reservation()
    {
    }
    public Reservation(ReservationId id, ParkingSpotId parkingSpotId,Capacity capacity, Date date)
    {
        Id = id;
        ParkingSpotId = parkingSpotId;
        Capacity = capacity;
        Date = date;
    }

    
}

