using System;

namespace Water_and_Solid
{
    class Vector
    {
        public double x, y, z;
        public Vector()
        {
            x = y = z = 0;
        }
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public string ToString()
        {
            return (this.x.ToString() + this.y.ToString() + this.z.ToString());
        }
        public Vector ToVector(string s)
        {
            return new Vector((s[1] - '0'), (s[3] - '0'), (s[5] - '0'));
        }

        public static Vector operator *(Vector th, double other)
        {
            return new Vector(th.x * other, th.y * other, th.z * other);
        }
        public static Vector operator *(Vector th, double[][] other)
        {
            Vector Result = new Vector();
            Result.x = other[0][0] * th.x + other[0][1] * th.y + other[0][2] * th.z;
            Result.y = other[1][0] * th.x + other[1][1] * th.y + other[1][2] * th.z;
            Result.z = other[2][0] * th.x + other[2][1] * th.y + other[2][2] * th.z;
            return Result;
        }
        public static Vector operator -(Vector th, double other)
        {
            return new Vector(th.x - other, th.y - other, th.z - other);
        }
        public static Vector operator +(Vector th, double other)
        {
            return new Vector(th.x + other, th.y + other, th.z + other);
        }
        public static Vector operator /(Vector th, double other)
        {
            return new Vector(th.x / other, th.y / other, th.z / other);
        }
        public static Vector operator +(Vector th, Vector other)
        {
            return new Vector(th.x + other.x, th.y + other.y, th.z + other.z);
        }
        public static Vector operator -(Vector th, Vector other)
        {
            return new Vector(th.x - other.x, th.y - other.y, th.z - other.z);
        }

        public static Vector operator *(Vector th, Vector other)
        {
            return new Vector(((th.y * other.z) - (th.z * other.y)), ((th.z * other.x) - (th.x * other.z)), ((th.x * other.y) - (th.y * other.x)));
        }
        public double AbsSquare()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
        }
        public double dot(Vector other)
        {
            return (this.x * other.x + this.y * other.y + this.z * other.z);
        }

        public double Distance(Vector v)
        {
            return Math.Sqrt(Math.Pow((this.x - v.x), 2) + Math.Pow((this.y - v.y), 2) + Math.Pow((this.z - v.z), 2));
        }
        public Vector Add(Vector v)
        {
            return new Vector(this.x + v.x, this.y + v.y, this.z + v.z);
        }


    }
}
