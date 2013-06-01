using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FabFlySharp
{
    public struct Vector3
    {
        public decimal X, Y, Z;
        public Vector3(bool b)
        {
            X = Y = Z = 0;
        }
        public static Vector3 operator +(Vector3 a, Vector3 b) { a.X += b.X; a.Y += b.Y; a.Z += b.Z; return a; }
        public static Vector3 operator -(Vector3 a, Vector3 b) { a.X -= b.X; a.Y -= b.Y; a.Z -= b.Z; return a; }
        public static Vector3 operator *(Vector3 a, Vector3 b) { a.X *= b.X; a.Y *= b.Y; a.Z *= b.Z; return a; }
        public static Vector3 operator /(Vector3 a, Vector3 b) { a.X /= b.X; a.Y /= b.Y; a.Z /= b.Z; return a; }
        public static Vector3 operator *(Vector3 a, decimal b) { a.X *= b; a.Y *= b; a.Z *= b; return a; }
        public static Vector3 operator *(decimal b, Vector3 a) { a.X *= b; a.Y *= b; a.Z *= b; return a; }
        public static Vector3 operator /(Vector3 a, decimal b) { a.X /= b; a.Y /= b; a.Z /= b; return a; }

        public static Vector3 operator ^(Vector3 a, Vector3 b)
        {
            a.X = a.Y * b.Z - a.Z * b.Y;
            a.Y = a.Z * b.X - a.X * b.Z;
            a.Z = a.X * b.Y - a.Y * b.X;
            return a;
        }

        public static bool operator ==(Vector3 a, Vector3 b) { return a.X == b.X && a.Y == b.Y && a.Z == b.Z; }
        public static bool operator !=(Vector3 a, Vector3 b) { return a.X != b.X || a.Y != b.Y || a.Z != b.Z; }

        public decimal _(Vector3 other)
        {
            return this.X * other.X + this.Y * other.Y + this.Z * other.Z;
        }
        public decimal Length
        {
            get
            {
                return MathHelper.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
            }
            set
            {
                var s = this.Normalize() * value;
                this.X = s.X;
                this.Y = s.Y;
                this.Z = s.Z;
            }
        }
        public Vector3 Normalize()
        {
            return this / this.Length;
        }
        public Vector3 RotateXY(decimal Angle)
        {
            var s = MathHelper.Sin(Angle);
            var c = MathHelper.Cos(Angle);
            return new Vector3()
            {
                X = Math.Round(c * this.X - s * this.Y, 10, MidpointRounding.AwayFromZero),
                Y = Math.Round(s * this.X + c * this.Y, 10, MidpointRounding.AwayFromZero),
                Z = this.Z
            };


            var N = MathHelper.Sqrt(this.X * this.X + this.Y * this.Y);
            var A = MathHelper.Atan2(this.Y, this.X) + Angle;
            return new Vector3() { X = MathHelper.Cos(A) * N, Y = MathHelper.Sin(A) * N, Z = this.Z };
            /*
            var cs = MathHelper.Cos(Angle);
            var sn = MathHelper.Sin(Angle);
            R.X = this.X * cs - this.Y * sn;
            R.Y = this.X * cs + this.Y * sn;
            R.Z = this.Z;
            return R;*/
        }
        public Vector3 Transform(Func<decimal, decimal> F)
        {
            Vector3 Ret = new Vector3();
            Ret.X = F(this.X);
            Ret.Y = F(this.Y);
            Ret.Z = F(this.Z);
            return Ret;
        }
        public Vector3 BinaryTransform(Vector3 Other, Func<decimal, decimal, decimal> F)
        {
            Vector3 Ret = new Vector3();
            Ret.X = F(this.X, Other.X);
            Ret.Y = F(this.Y, Other.Y);
            Ret.Z = F(this.Z, Other.Z);
            return Ret;
        }
    }
}
