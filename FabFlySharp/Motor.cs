using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RaspberryPiDotNet;

namespace FabFlySharp
{
    public interface Motor
    {
        decimal RPM { get; set; }
        void Update(TimeSpan T);
    }
}
