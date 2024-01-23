namespace MySpot.Core.Exceptions;

public sealed class EmptyLicensePLateException : CustomException
{
    public EmptyLicensePLateException() : base("License plate is empty")
    {

    }
}

public sealed class InvalidLicensePlateException : CustomException
{
    public string LicensePlate { get; }

    public InvalidLicensePlateException(string licensePlate)
        : base($"License plate: {licensePlate} is invalid")
    {
        LicensePlate = licensePlate;
    }
}
