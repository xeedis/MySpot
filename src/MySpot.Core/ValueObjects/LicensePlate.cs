﻿using MySpot.Core.Exceptions;

namespace MySpot.Core.ValueObjects;

public sealed record LicensePlate
{
    public string Value { get; }

    public LicensePlate(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new EmptyLicensePLateException();
        }

        if (value.Length is < 5 or > 8)
        {
            throw new InvalidLicensePlateException(value);
        }

        Value = value;
    }

    public static implicit operator string(LicensePlate licensePlate) => licensePlate?.Value;

    public static implicit operator LicensePlate(string licensePlate) => new(licensePlate);
}
