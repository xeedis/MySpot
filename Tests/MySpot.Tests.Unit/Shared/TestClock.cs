using MySpot.Application.Services;
using MySpot.Core.Abstractions;

namespace MySpot.Tests.Unit.Shared;
internal class TestClock : IClock
{
    public DateTime Current() => new(2024, 01, 23);
}
