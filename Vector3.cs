using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorsProject
{

    public struct Vector3
    {
        private readonly float _x;
        private readonly float _y;
        private readonly float _z;

        public float X { get => _x; }
        public float Y { get => _y; }
        public float Z { get => _z; }

        public float this[int index]
        {
            get
            {
                if (index == 0)
                    return _x;
                if (index == 1)
                    return _y;
                if (index == 2)
                    return _z;
                throw new IndexOutOfRangeException();
            }
        }

        public float Magnitude { get => MathF.Sqrt(_x * _x + _y * _y + _z * _z); }

        public static Vector3 Zero { get => new Vector3(); }
        public static Vector3 Right { get => new Vector3(1f, 0f, 0f); }
        public static Vector3 Left { get => new Vector3(-1f, 0f, 0f); }
        public static Vector3 Up { get => new Vector3(0f, 1f, 0f); }
        public static Vector3 Down { get => new Vector3(0f, -1f, 0f); }
        public static Vector3 Forward { get => new Vector3(0f, 0f, 1f); }
        public static Vector3 Backward { get => new Vector3(0f, 0f, -1f); }
        public static Vector3 operator +(Vector3 v1, Vector3 v2) => new Vector3(v1._x + v2._x, v1._y + v2._y, v1._z + v2._z);
        public static Vector3 operator -(Vector3 v1, Vector3 v2) => new Vector3(v1._x - v2._x, v1._y - v2._y, v1._z - v2._z);
        public static Vector3 operator *(Vector3 v, float f) => new Vector3(v._x * f, v._y * f, v._z * f);
        public static Vector3 operator *(float f, Vector3 v) => new Vector3(v._x * f, v._y * f, v._z * f);
        public static float operator *(Vector3 v1, Vector3 v2) => v1._x * v2._x + v1._y * v2._y + v1._z * v2._z;
        public static Vector3 operator /(Vector3 v, float f) => new Vector3(v._x / f, v._y / f, v._z / f);
        public static bool operator >(Vector3 v1, Vector3 v2) => v1.Magnitude > v2.Magnitude;
        public static bool operator <(Vector3 v1, Vector3 v2) => v1.Magnitude < v2.Magnitude;
        public static bool operator >=(Vector3 v1, Vector3 v2) => v1.Magnitude >= v2.Magnitude;
        public static bool operator <=(Vector3 v1, Vector3 v2) => v1.Magnitude <= v2.Magnitude;
        public static bool operator ==(Vector3 v1, Vector3 v2) => v1._x == v2._x && v1._y == v2._y && v1._z == v2._z;
        public static bool operator !=(Vector3 v1, Vector3 v2) => !(v1._x == v2._x && v1._y == v2._y && v1._z == v2._z);

        public static implicit operator Vector3(Vector2 v)
        {
            return new Vector3(v.X, v.Y);
        }

        public static implicit operator Vector3((float, float) t)
        {
            return new Vector3(t.Item1, t.Item2);
        }

        public static implicit operator Vector3((float, float, float) t)
        {
            return new Vector3(t.Item1, t.Item2, t.Item3);
        }


        public Vector3(float x = 0, float y = 0, float z = 0)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public Vector3 Normalized()
        {
            if (Magnitude == 0f)
                return Right;
            float bufferMagnitude = Magnitude;
            return new Vector3(_x / bufferMagnitude, _y / bufferMagnitude, _z / bufferMagnitude);

        }

        public static float Dot(Vector3 v1, Vector3 v2)
        {
            return v1._x * v2._x + v1._y * v2._y + v1._z * v2._z;
        }

        public static float Angle(Vector3 v1, Vector3 v2)
        {
            return MathF.Acos(Dot(v1, v2) / v1.Magnitude / v2.Magnitude);
        }

        public static Vector3 Lerp(Vector3 v1, Vector3 v2, float value)
        {
            return v1 + (v2 - v1) * value;
        }

        public static Vector3 Cross(Vector3 v1, Vector3 v2)
        {
            return new Vector3((v1._y * v2._z - v1._z * v2._y), (v1._x * v2._z - v1._z * v2._x), (v1._x * v2._y - v1._y * v2._x));
        }

        public override string ToString()
        {
            return $"Vector3: {_x}, {_y}, {_z}";
        }

        public override int GetHashCode()
        {
            return _x.GetHashCode() ^ _y.GetHashCode() ^ _z.GetHashCode();
        }

        public override bool Equals(object? v)
        {
            if (v == null)
                return false;
            if (v is Vector3 bufferVector)
                return bufferVector._x.Equals(_x) && bufferVector._y.Equals(_y) && bufferVector._z.Equals(_z);
            return false;
        }

        public static new bool Equals(object? v1, object? v2)
        {
            if (v1 == null ^ v2 == null)
                return false;
            if (v1 == null && v2 == null)
                return true;
            if (v1 is Vector3 bufferVector1 && v2 is Vector3 bufferVector2)
                return bufferVector1._x.Equals(bufferVector2._x) && bufferVector1._y.Equals(bufferVector2._y) && bufferVector1._z.Equals(bufferVector2._z);
            return false;
        }

    }
}
