using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FabFlySharp
{
    public interface IMU
    {
        Vector3 Acceleration { get; }
        Vector3 Rotation { get; }
        void Update(TimeSpan Interval);
    }
}
