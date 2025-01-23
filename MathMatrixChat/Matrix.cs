using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MathMatrixChat
{
    public class Matrix<T>
    {
        public int Rows { get; }
        public int Columns { get; }
        public T[,] Matrixx { get; }

        public Matrix(int rows, int columns) // конструктор нулевой матрицы
        {
            Type type = typeof(T);
            TypeCode typeCode = Type.GetTypeCode(type);
            if (typeCode >= TypeCode.SByte && typeCode <= TypeCode.Decimal)
            {
                Matrixx = new T[rows, columns];
                Rows = rows; Columns = columns;
            }
            else
            {
                throw new ArgumentException("нельзя использовать тип: string");
            }
        }
        public Matrix(int rows, int columns, T element) : this(rows, columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Matrixx[i, j] = element;
                }
            }
        }

        public static bool operator !=(Matrix<T> a, Matrix<T> b)
        {
            if (a.Columns == b.Columns || a.Rows == a.Rows) return false;

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    if (a.Matrixx[i, j].Equals(b.Matrixx[i, j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator ==(Matrix<T> a, Matrix<T> b)
        {
            if (a.Columns != b.Columns || a.Rows != a.Rows) return false;

            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    if (!a.Matrixx[i, j].Equals(b.Matrixx[i, j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static Matrix<T> operator *(Matrix<T> a, decimal value)
        {
            dynamic v = value;
            for (int i = 0; i < a.Columns; i++)
            {
                for (int j = 0; j < a.Rows; j++)
                {
                    a.Matrixx[i, j] *= v;
                }
            }
            return a;
        }
        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            if (a.Columns != b.Rows) throw new ArgumentException("Умнажать матрицы можно только когда кол-во столбцов у первой матрицы совподают с кол-во строк во второй.");

            Matrix<T> matrix = new Matrix<T>(a.Rows, b.Columns);
            dynamic first_value;
            dynamic second_value;

            for (int i = 0; i < a.Columns; i++)
            {
                for (int j = 0; j < a.Rows; j++)
                {
                    first_value = b.Matrixx[0, j];
                    second_value = a.Matrixx[i, 0];

                }
            }
            return a;
        }
    }
}
