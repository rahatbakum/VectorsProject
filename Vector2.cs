using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorsProject
{
    public struct Vector2
    {
        private readonly float _x;
        private readonly float _y;

        public float X { get => _x; }
        public float Y { get => _y; }

        public float this[int index]
        {
            get
            {
                if (index == 0)
                    return _x;
                if (index == 1)
                    return _y;
                throw new IndexOutOfRangeException();
            }
        }

        public float Magnitude { get => MathF.Sqrt(_x * _x + _y * _y); }

        public static Vector2 Zero { get => new Vector2(); }
        public static Vector2 Right { get => new Vector2(1f, 0f); }
        public static Vector2 Left { get => new Vector2(-1f, 0f); }
        public static Vector2 Up { get => new Vector2(0f, 1f); }
        public static Vector2 Down { get => new Vector2(0f, -1f); }

        public static Vector2 operator +(Vector2 v1, Vector2 v2) => new Vector2(v1._x + v2._x, v1._y + v2._y);
        public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1._x - v2._x, v1._y - v2._y);
        public static Vector2 operator *(Vector2 v, float f) => new Vector2(v._x * f, v._y * f);
        public static Vector2 operator *(float f, Vector2 v) => new Vector2(v._x * f, v._y * f);
        public static float operator *(Vector2 v1, Vector2 v2) => v1._x * v2._x + v1._y * v2._y;
        public static Vector2 operator /(Vector2 v, float f) => new Vector2(v._x / f, v._y / f);
        public static bool operator >(Vector2 v1, Vector2 v2) => v1.Magnitude > v2.Magnitude;
        public static bool operator <(Vector2 v1, Vector2 v2) => v1.Magnitude < v2.Magnitude;
        public static bool operator >=(Vector2 v1, Vector2 v2) => v1.Magnitude >= v2.Magnitude;
        public static bool operator <=(Vector2 v1, Vector2 v2) => v1.Magnitude <= v2.Magnitude;
        public static bool operator ==(Vector2 v1, Vector2 v2) => v1._x == v2._x && v1._y == v2._y;
        public static bool operator !=(Vector2 v1, Vector2 v2) => !(v1._x == v2._x && v1._y == v2._y);

        public static implicit operator Vector2(float f)
        {
            return new Vector2(f);
        }

        public static implicit operator Vector2(Vector3 v)
        {
            return new Vector2(v.X, v.Y);
        }

        public static implicit operator Vector2((float, float) t)
        {
            return new Vector2(t.Item1, t.Item2);
        }

        public Vector2(float x = 0, float y = 0)
        {
            _x = x;
            _y = y;
        }

        public Vector2 Normalized()
        {
            if (Magnitude == 0f)
                return Right;
            float bufferMagnitude = Magnitude;
            return new Vector2(_x / bufferMagnitude, _y / bufferMagnitude);

        }

        public static float Dot(Vector2 v1, Vector2 v2)
        {
            return v1._x * v2._x + v1._y * v2._y;
        }

        public static float Angle(Vector2 v1, Vector2 v2)
        {
            return MathF.Acos(Dot(v1, v2) / v1.Magnitude / v2.Magnitude);
        }

        public static Vector2 Lerp(Vector2 v1, Vector2 v2, float value)
        {
            return v1 + (v2 - v1) * value;
        }


        public override string ToString()
        {
            return $"Vector2: {_x}, {_y}";
        }

        public override int GetHashCode()
        {
            return _x.GetHashCode() ^ _y.GetHashCode();
        }

        public override bool Equals(object? v)
        {
            if (v == null)
                return false;
            if (v is Vector2 bufferVector)
                return bufferVector._x.Equals(_x) && bufferVector._y.Equals(_y);
            return false;
        }

        public static new bool Equals(object? v1, object? v2)
        {
            if (v1 == null ^ v2 == null)
                return false;
            if (v1 == null && v2 == null)
                return true;
            if (v1 is Vector2 bufferVector1 && v2 is Vector2 bufferVector2)
                return bufferVector1._x.Equals(bufferVector2._x) && bufferVector1._y.Equals(bufferVector2._y);
            return false;
        }
    }
}
