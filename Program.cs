using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            string[] inputNumbersString = inputString.Split(' ');
            float[] inputNumbersFloat = new float[inputNumbersString.Length];

            for (int i = 0; i < inputNumbersString.Length; i++)
                inputNumbersFloat[i] = float.Parse(inputNumbersString[i]);

            Vector3 v1 = new Vector3(inputNumbersFloat[0], inputNumbersFloat[1], inputNumbersFloat[2]);
            Vector3 v2 = new Vector3(inputNumbersFloat[3], inputNumbersFloat[4], inputNumbersFloat[5]);

            Console.WriteLine();
            Console.WriteLine($"v1 = {v1}");
            Console.WriteLine($"v2 = {v2}");
            Console.WriteLine();
            Console.WriteLine($"v1 + v2 = {v1 + v2}");
            Console.WriteLine($"v1 - v2 = {v1 - v2}");
            Console.WriteLine($"v1 * 10 = {v1 * 10}");
            Console.WriteLine();
            Console.WriteLine($"v1 > v2 = {v1 > v2}");
            Console.WriteLine();
            Console.WriteLine($"v1.Magnitude = {v1.Magnitude}");
            Console.WriteLine($"v1.Normalized() = {v1.Normalized()}");
            Console.WriteLine($"Vector3.Dot(v1, v2) = {Vector3.Dot(v1,v2)}");
            Console.WriteLine($"Vector3.Angle(v1, v2) = {Vector3.Angle(v1, v2)}");
            Console.WriteLine($"Vector3.Lerp(v1, v2, 0.5f) = {Vector3.Lerp(v1, v2, 0.5f)}");
            Console.WriteLine($"Vector3.Cross(v1, v2) = {Vector3.Cross(v1, v2)}");
        }
    }

}
