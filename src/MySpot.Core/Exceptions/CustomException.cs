﻿namespace MySpot.Core.Exceptions;

public abstract class CustomException : Exception
{
    public CustomException(string message) : base(message)
    {

    }
}
