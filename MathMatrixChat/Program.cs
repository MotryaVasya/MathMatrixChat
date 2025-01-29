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
            Matrix matr1 = new Matrix(3, 3,true);
            Console.WriteLine(matr1.ToString());

        }
    }
}
