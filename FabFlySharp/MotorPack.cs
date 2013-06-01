using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FabFlySharp
{
    public class MotorPack
    {
        //private const int Reactivity = 50;

        protected FourMotor Motors { get; set; }
        protected IMU Inertial { get; set; }

        private readonly PID[] SpeedPID = new PID[]
        {
            new PID() {
            P = 6,
            I = 4,
            D = 2,
            windupGuard = 30
            },
            new PID() {
            P = 6,
            I = 4,
            D = 2,
            windupGuard = 30
            },
            new PID() {
            P = 6,
            I = 4,
            D = 2,
            windupGuard = 30
            },
        };
        private readonly PID[] AccPID = new PID[]
        {
            new PID() {
            P = 6,
            I = 4,
            D = 2,
            windupGuard = 10
            },
            new PID() {
            P = 6,
            I = 4,
            D = 2,
            windupGuard = 10
            },
            new PID() {
            P = 6,
            I = 4,
            D = 2,
            windupGuard = 10
            },
        };
        private Vector3 CurrentSpeed = new Vector3(false);
        private Vector3 DesiredSpeed = new Vector3(false);
        public Vector3 Speed
        {
            get
            {
                return CurrentSpeed;
            }
            set
            {
                DesiredSpeed = value;
                UseAcc = false;
            }
        }
        //private Vector3 DesiredAcceleration;
        private bool UseAcc = false;
        private Vector3 DesiredAcceleration = new Vector3();
        public Vector3 Acceleration { get { return Inertial.Acceleration; } /*set { DesiredAcceleration = value; UseAcc = true; }*/ }

        public MotorPack(FourMotor P, IMU I)
        {
            this.Inertial = I;
            this.Motors = P;
        }

        public void Update(TimeSpan Interval)
        {
            this.CurrentSpeed += (decimal)Interval.TotalSeconds * this.Acceleration;
            int j = 0; 
            if (!UseAcc) this.DesiredAcceleration = this.Speed.BinaryTransform(
                this.DesiredSpeed,
                (x, y) => SpeedPID[j++].UpdatePID(x, y, Interval, true));
            int i = 0; 
            var PID = this.Acceleration.BinaryTransform(
                this.DesiredAcceleration,
                (x, y) => AccPID[i++].UpdatePID(x, y, Interval, true)).RotateXY((decimal)-Math.PI / 4);
            Motors.XY.RPM = PID.X + PID.Z;
            Motors.Y_X.RPM = PID.Y + PID.Z;
            Motors._X_Y.RPM = -PID.X + PID.Z;
            Motors._YX.RPM = -PID.Y + PID.Z;
            foreach (var M in Motors) M.Update(Interval);
        }
    }
    public struct FourMotor : IEnumerable<Motor>
    {
        public Motor @XY;
        public Motor @Y_X;
        public Motor @_X_Y;
        public Motor @_YX;

        

        /*     Y_X      Y       XY
         *              |
         *              |
         *     _X ______|_______ X
         *              |
         *              |
         *              |
         *     _X_Y    _Y      _YX
         */

        public IEnumerator<Motor> GetEnumerator()
        {
            yield return this.XY;
            yield return this.Y_X;
            yield return this._X_Y;
            yield return this._YX;
            yield break;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
