using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FabFlySharp
{
    public class VirtualMotor : Motor
    {
        const decimal VMTPR = 80;
        decimal _RPM;
        decimal Desired;
        public decimal RPM
        {
            get
            {
                return _RPM;
            }
            set
            {
                Desired = value;
            }
        }

        public VirtualMotor(decimal InitRPM) { _RPM = InitRPM; }


        public void Update(TimeSpan T)
        {
            var S = Math.Sign(Desired - _RPM);
            _RPM = (_RPM + S * (decimal)T.TotalSeconds * VMTPR).Clamp(0, Desired);
        }
    }
}
