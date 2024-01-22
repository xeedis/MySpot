using MySpot.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpot.Tests.Unit.Shared;
internal class TestClock : IClock
{
    public DateTime Current() => new(2024, 01, 23);
}
