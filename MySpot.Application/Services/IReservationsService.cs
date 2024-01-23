﻿using MySpot.Application.Commands;
using MySpot.Application.DTO;

namespace MySpot.Application.Services;
public interface IReservationsService
{
    Guid? Create(CreateReservation command);
    bool Delete(DeleteReservation command);
    ReservationDto Get(Guid id);
    IEnumerable<ReservationDto> GetAllWeekly();
    bool Update(ChangeReservationLicensePlate command);
}