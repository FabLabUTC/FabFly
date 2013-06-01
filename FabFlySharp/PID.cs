using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FabFlySharp
{
    struct PID
    {
        public decimal P, I, D;
        public static PID Zero = new PID()
        {
            P = 0,
            I = 0,
            D = 0
        };
        decimal lastError;
        // AKA experiments with PID
        DateTime previousPIDTime;
        decimal integratedError;
        public decimal windupGuard; // Thinking about having individual wind up guards for each PID

        public decimal UpdatePID(decimal from, decimal to, TimeSpan Interval, bool Flying)
        {
            decimal deltaPIDTime = (decimal)Interval.TotalSeconds;
            if (deltaPIDTime == 0) return 0;
            //this.previousPIDTime = DateTime.Now;  // AKA PID experiments
            decimal error = to - from;

            if (Flying)
            {
                this.integratedError += error * deltaPIDTime;
            }
            else
            {
                this.integratedError = 0.0M;
            }
            this.integratedError = this.integratedError.Clamp(-this.windupGuard, +this.windupGuard);
            decimal dTerm = this.D * (from - this.lastError) / (deltaPIDTime * 100); // dT fix from Honk
            this.lastError = from;

            return (this.P * error) + (this.I * this.integratedError) + dTerm;
        }
    }
}
