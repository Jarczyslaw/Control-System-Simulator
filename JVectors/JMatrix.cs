using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JVectors
{
    public class JMatrix
    {
        public double[,] data { get; private set; }

        public JMatrix(int x, int y) : this(x, y, 0.0) { }

        public JMatrix(int x, int y, double value)
        {
            data = new double[x, y];
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    data[i, j] = value;
        }

        public JMatrix(double[,] data)
        {
            int x = data.GetLength(0);
            int y = data.GetLength(1);
            this.data = new double[x, y];
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    this.data[i, j] = data[i, j];
        }

        public JMatrix(JMatrix matrix) : this(matrix.data) { }

        public JMatrix(JVector vector, bool column = true)
        {
            if (column)
            {
                data = new double[vector.Count(), 1];
                for (int i = 0; i < vector.Count(); i++)
                    data[i, 0] = vector[i];
            }
            else
            {
                data = new double[1, vector.Count()];
                for (int i = 0; i < vector.Count(); i++)
                    data[0, i] = vector[i];
            }
        }

        public double this[int i, int j]
        {
            get { return data[i,j]; }
            set { data[i,j] = value; }
        }

        #region BASIC FUNCTIONS
        public int SizeX()
        {
            return data.GetLength(0);
        }

        public int SizeY()
        {
            return data.GetLength(1);
        }

        public int Count()
        {
            return SizeX() * SizeY();
        }

        public double Min()
        {
            return data.Cast<double>().Min();
        }

        public double Max()
        {
            return data.Cast<double>().Max();
        }

        public double Average()
        {
            return data.Cast<double>().Average();
        }

        public double Sum()
        {
            return data.Cast<double>().Sum();
        }

        public double Det()
        {
            if (SizeX() != SizeY())
                throw new NonSquareMatrixException("Can't get determinant for non square matrix.");

            if (SizeX() == 1)
                return data[0, 0];
            else if (SizeX() == 2)
                return data[0, 0] * data[1, 1] - data[1, 0] * data[0, 1];
            else if (SizeX() == 3)
                return data[0, 0] * data[1, 1] * data[2, 2] +
                    data[1, 0] * data[2, 1] * data[0, 2] +
                    data[2, 0] * data[0, 1] * data[1, 2] -
                    data[1, 0] * data[0, 1] * data[2, 2] -
                    data[0, 0] * data[2, 1] * data[1, 2] -
                    data[2, 0] * data[1, 1] * data[0, 2];
            else
                throw new NotImplementedException("Determinant for matrix larger than 3x3 is not implemented yet.");
        }

        public JMatrix Inv()
        {
            double det = Det();
            if (Math.Abs(det) < 0.0001)
                throw new MatrixInversionException("Determinant to low to calculate inversion.");

            JMatrix result = new JMatrix(SizeX(), SizeY());
            if (SizeX() == 1)
            {
                result[0, 0] = 1 / data[0, 0];
                return result;
            }
            else if (SizeX() == 2)
            {
                result[0, 0] = data[1, 1];
                result[0, 1] = -data[0, 1];
                result[1, 0] = -data[1, 0];
                result[1, 1] = data[0, 0];
                result = 1 / det * result;
                return result;
            }
            else if (SizeX() == 3)
            {
                result[0, 0] = data[1,1] * data[2,2] - data[1,2] * data[2,1];
                result[0, 1] = data[0, 2] * data[2, 1] - data[0, 1] * data[2, 2];
                result[0, 2] = data[0, 1] * data[1, 2] - data[0, 2] * data[1, 1];
                result[1, 0] = data[1, 2] * data[2, 0] - data[1, 0] * data[2, 2];
                result[1, 1] = data[0, 0] * data[2, 2] - data[0, 2] * data[2, 0];
                result[1, 2] = data[0, 2] * data[1, 0] - data[0, 0] * data[1, 2];
                result[2, 0] = data[1, 0] * data[2, 1] - data[1, 1] * data[2, 0];
                result[2, 1] = data[0, 1] * data[2, 0] - data[0, 0] * data[2, 1];
                result[2, 2] = data[0, 0] * data[1, 1] - data[0, 1] * data[1, 0];
                result = 1 / det * result;
                return result;
            }
            else
                throw new NotImplementedException("Inversion of matrix larger than 3x3 is not implemented yet."); 
        }

        public JMatrix Neg()
        {
            JMatrix result = new JMatrix(data);
            for (int i = 0; i < SizeX(); i++)
                for (int j = 0; j < SizeY(); j++)
                    result[i, j] = -result[i, j];
            return result;
        }

        public JMatrix T()
        {
            int x = SizeX();
            int y = SizeY();
            JMatrix result = new JMatrix(y, x);
            for (int i = 0; i < y; i++)
                for (int j = 0; j < x; j++)
                    result[i, j] = data[j, i];
            return result;
        }

        public JMatrix Clone()
        {
            return new JMatrix(this);
        }

        public override string ToString()
        {
            int x = SizeX();
            int y = SizeY();
            string result = "JMatrix, size: " + x + "x" + y + Environment.NewLine;
            for (int i = 0;i < x;i++)
            {
                result += "[";
                for (int j = 0;j < y;j++)
                {
                    result += data[i,j].ToString(CultureInfo.InvariantCulture);
                    if (j != y - 1)
                        result += ", ";
                }
                result += "]" + Environment.NewLine;
            }
            return result;
        }
        #endregion

        #region OPERATORS
        public static JMatrix operator +(JMatrix m1, JMatrix m2)
        {
            int m1x = m1.SizeX();
            int m1y = m1.SizeY();
            int m2x = m2.SizeX();
            int m2y = m2.SizeY();

            if (m1x != m2x || m1y != m2y)
                throw new InvalidMatrixSizeException("Invalid matrix size. Matrix should have the same rows and columns count.");

            JMatrix result = new JMatrix(m1x, m1y);
            for (int i = 0; i < m1x; i++)
                for (int j = 0; j < m1y; j++)
                    result[i,j] = m1[i, j] + m2[i, j];
            return result;
        }

        public static JMatrix operator +(double d, JMatrix m)
        {
            JMatrix result = new JMatrix(m);
            for (int i = 0; i < result.SizeX(); i++)
                for (int j = 0; j < result.SizeY(); j++)
                    result[i, j] += d;
            return result;
        }

        public static JMatrix operator +(JMatrix m, double d)
        {
            return d + m;
        }

        public static JMatrix operator -(JMatrix m1, JMatrix m2)
        {
            return m1 + m2.Neg();
        }

        public static JMatrix operator -(double d, JMatrix m)
        {
            return d + m.Neg();
        }

        public static JMatrix operator -(JMatrix m, double d)
        {
            return m + (-d);
        }

        public static JMatrix operator *(JMatrix m1, JMatrix m2)
        {
            int m1x = m1.SizeX();
            int m1y = m1.SizeY();
            int m2x = m2.SizeX();
            int m2y = m2.SizeY();

            if (m1y != m2x)
                throw new InvalidMatrixSizeException("Invalid matrix size. Left side matrix should have the sam columns as right side matrix has.");

            JMatrix result = new JMatrix(m1x, m2y);
            for (int i = 0; i < m1x; i++)
                for (int j = 0; j < m2y; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < m2x; k++)
                        sum += m1[i, k] * m2[k, j];
                    result[i, j] = sum;
                }     
            return result;
        }

        public static JVector operator *(JMatrix m, JVector v)
        {
            // kazdy wektor domyslnie traktowany jest jako kolumnowy
            if (m.SizeY() != v.Count())
                throw new InvalidMatrixSizeException("Invalid matrix size. Matrix should have columns as many as vector's count");

            int c = m.SizeX();
            JVector result = new JVector(c, 0);
            for (int i = 0; i < c; i++)
                for (int j = 0; j < m.SizeY(); j++)
                    result[i] += v[j] * m[i, j];
            return result;
        }

        public static JMatrix operator *(double d, JMatrix m)
        {
            JMatrix result = new JMatrix(m);
            int x = m.SizeX();
            int y = m.SizeY();
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    result[i, j] *= d;
            return result;
        }

        public static JMatrix operator *(JMatrix m, double d)
        {
            return d * m;
        }

        public static JMatrix operator -(JMatrix m)
        {
            return m.Neg();
        }
        #endregion
    }
}
