using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MathMatrixChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] data = { 3, 4, 5, 7, 8 };
            Matrix matr = new Matrix(3, 3, data, true, 2);
            matr = matr.Transpose();
            Console.WriteLine(matr.ToString());
        }
    }
}
