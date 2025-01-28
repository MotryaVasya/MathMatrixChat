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
    public class Matrix
    {
        public int Rows { get; }
        public int Columns { get; }
        public double[,] Matrixx { get; }
        #region Constructors
        public Matrix(int rows, int columns) // конструктор нулевой матрицы
        {
            Matrixx = new double[rows, columns];
            Rows = rows; Columns = columns;

        }
        public Matrix(int rows, int columns, double element) : this(rows, columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Matrixx[i, j] = element;
                }
            }
        }

        public Matrix(int rows, int columns, double[] elements, bool refill = false, double filling = 0) : this(rows, columns)
        {
            if (rows * columns != elements.Length && !refill) throw new ArgumentException("");
            int curent_e = 0;
            if (elements.Length > rows * columns) throw new ArgumentException("Слишком большой массив данных");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (curent_e == elements.Length)
                    {
                        if (filling == 0) return;
                        Matrixx[i, j] = filling;
                    }
                    if (curent_e < elements.Length)
                    {
                        Matrixx[i, j] = elements[curent_e];
                        curent_e++;
                    }
                }
            }
        }
        #endregion
        #region Math operation
        public static bool operator !=(Matrix a, Matrix b)
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
        public static bool operator ==(Matrix a, Matrix b)
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
        public static Matrix operator *(Matrix a, double value)
        {
            Matrix res = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Columns; i++)
            {
                for (int j = 0; j < a.Rows; j++)
                {
                    res.Matrixx[i, j] = a.Matrixx[i, j] * value;
                }
            }
            return res;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Columns != b.Rows) throw new
                    ArgumentException("Умнажать матрицы можно только когда кол-во столбцов у первой матрицы совподают с кол-во строк во второй.");

            Matrix matrix = new Matrix(a.Rows, b.Columns);
            double first_value;
            double second_value;

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
        public static Matrix operator +(Matrix a) => a;
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows && a.Columns != b.Columns) throw new ArgumentException("не совподают матрицы!");
            Matrix res = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    res.Matrixx[i, j] = a.Matrixx[i, j] + b.Matrixx[i, j];
                }
            }
            return res;
        }
        public static Matrix operator -(Matrix a) => a * (-1);
        public static Matrix operator -(Matrix a, Matrix b) => a + b * (-1);

        //public static Matrix operator /(Matrix a, Matrix b)
        //{
        //    Matrix res = new Matrix(a.Rows, a.Columns);
        //}

        public Matrix Transpose()
        {
            Matrix res = new Matrix(Columns, Rows);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                   res.Matrixx[i, j] = Matrixx[j, i]; 
                }
            }


            return res;
        }

        #endregion

        #region Override
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    res += $"{Matrixx[i, j],-6}";
                }
                if (i < Rows - 1) res += "\n";
            }
            return res;
        }

        public override bool Equals(object obj)
        {
            return obj is Matrix matrix &&
                   Rows == matrix.Rows &&
                   Columns == matrix.Columns &&
                   EqualityComparer<double[,]>.Default.Equals(Matrixx, matrix.Matrixx);
        }
        public override int GetHashCode()
        {
            int hashCode = -2035033584;
            hashCode = hashCode * -1521134295 + Rows.GetHashCode();
            hashCode = hashCode * -1521134295 + Columns.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<double[,]>.Default.GetHashCode(Matrixx);
            return hashCode;
        }
        #endregion
    }
}
