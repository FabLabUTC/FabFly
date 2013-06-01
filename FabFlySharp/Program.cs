using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FabFlySharp
{
    class Program
    {
        static void Main(string[] args)
        {
            VirtualIMU I = new VirtualIMU(new FourMotor()
            {
                _X_Y = new VirtualMotor(0),
                _YX = new VirtualMotor(0),
                XY = new VirtualMotor(0),
                Y_X = new VirtualMotor(0)
            });
            I._Rotation = new Vector3(false) { };
            MotorPack P = new MotorPack(I._Pack, I);
            P.Speed = new Vector3(false) { X = 1 };
            TimeSpan Duration = TimeSpan.FromSeconds(0);
            //P.Acceleration = new Vector3(false) { X = 0};

            DateTime LastEnter;
            TimeSpan CalcTime;
            while (true)
            {
                LastEnter = DateTime.Now;
                P.Update(TimeSpan.FromMilliseconds(50));
                I.Update(TimeSpan.FromMilliseconds(50));
                Duration += TimeSpan.FromMilliseconds(50);
                CalcTime = DateTime.Now - LastEnter;
            }
        }
    }
}
