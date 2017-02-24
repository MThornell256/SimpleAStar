using System;

namespace AStar.Test
{
    // A Very Simple Vec3 Class For Testing
    public class Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // Euler Distance Equation
        public static float Distence(Vector3 from, Vector3 to)
        {
            float x = Math.Abs(from.X - to.X);
            float y = Math.Abs(from.Y - to.Y);
            float z = Math.Abs(from.Z - to.Z);

            x = x * x;
            y = y * y;
            z = z * z;

            return (float)Math.Sqrt(x+y+z);
        }
    }
}
