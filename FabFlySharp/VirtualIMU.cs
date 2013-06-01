using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FabFlySharp
{
    public class VirtualIMU : IMU
    {
        internal FourMotor _Pack;
        internal Vector3 _Rotation = new Vector3(false);
        private bool Tick = false;

        public VirtualIMU(FourMotor Pack)
        {
            this._Pack = Pack;
        }

        private const decimal Length = 0.5M;
        public void Update(TimeSpan Interval)
        {
            var Yrot = 
                (GetMotorForce(_Pack.XY) + GetMotorForce(_Pack._YX) 
                - (GetMotorForce(_Pack._X_Y) + GetMotorForce(_Pack.Y_X)));
            var Xrot = 
                (GetMotorForce(_Pack.XY) + GetMotorForce(_Pack.Y_X) 
                - (GetMotorForce(_Pack._YX) + GetMotorForce(_Pack._X_Y)));

            Xrot = 3 * Xrot / Length / Mass * (decimal)Interval.TotalSeconds;
            Yrot = 3 * Yrot / Length / Mass * (decimal)Interval.TotalSeconds;

            this._Rotation +=
                new Vector3(false)
                {
                    X = Xrot % (decimal)(Math.PI * 2),
                    Y = Yrot % (decimal)(Math.PI * 2),
                    Z = 0
                };
            //this._Rotation = this._Rotation.Normalize();
        }

        private const decimal MotorForcePerRPM = 0.00001M; //Suppose a linear law
        private decimal GetGlobalMotorForce()
        {
            return GetMotorForce(_Pack._X_Y) + GetMotorForce(_Pack._YX) + GetMotorForce(_Pack.XY) + GetMotorForce(_Pack.Y_X);
        }
        private decimal GetMotorForce(Motor M) { return M.RPM * M.RPM * MotorForcePerRPM; }

        private const decimal Gravity = 9.81M * Mass; //Two kilogram in the Earth's gravity field
        private const decimal Mass = 2.0M;
        public Vector3 Acceleration
        {
            get //sum(Fext) = m a
            {
                var VDir = new Vector3()
                {
                    X = MathHelper.Sin(Rotation.Y),
                    Z = MathHelper.Cos(Rotation.X) * MathHelper.Cos(Rotation.Y),
                    Y = MathHelper.Sin(Rotation.X) * MathHelper.Cos(Rotation.Y)
                };

                return (new Vector3(false)
                {
                    Z = - Gravity
                } + VDir * GetGlobalMotorForce()) / Mass;
            }
        }
        public Vector3 Rotation
        {
            get
            {
                return _Rotation;
            }
        }
    }
}
