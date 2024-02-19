namespace MySpot.Core.Exceptions;

public sealed class InvalidCapacityException : CustomException
{
    private readonly int _capacity;
    public InvalidCapacityException(int capacity) : base($"Capacity {capacity} is invalid")
    {
        _capacity = capacity;
    }
}