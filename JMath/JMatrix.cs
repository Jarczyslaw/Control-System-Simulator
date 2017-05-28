using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMath
{
    public class JMatrix
    {
        public double[,] data;

        #region CONSTRUCTORS

        public JMatrix(int x, int y) : this(x, y, 0d) { }

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

        #endregion

        #region ACCESS

        public void ForEach(Action<int, int, double> callback)
        {
            int rows = Rows();
            int cols = Cols();
            for (int i = 0; i < rows; i++)
                for (int j = 0;j < cols;j++)
                    callback(i, j, data[i, j]);
        }

        public void ForEachRow(int column, Action<int, int, double> callback)
        {
            int rows = Rows();
            for (int i = 0; i < rows; i++)
                callback(i, column, data[i, column]);
        }

        public void ForEachColumn(int row, Action<int, int, double> callback)
        {
            int cols = Cols();
            for (int i = 0; i < cols; i++)
                callback(row, i, data[row, i]);
        }

        #endregion

        #region BASIC FUNCTIONS

        public int Rows()
        {
            return data.GetLength(0);
        }

        public int Cols()
        {
            return data.GetLength(1);
        }

        public int Count()
        {
            return Rows() * Cols();
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
            if (Rows() != Cols())
                throw new NonSquareMatrixException("Can't get determinant for non square matrix.");

            if (Rows() == 1)
                return data[0, 0];
            else if (Rows() == 2)
                return data[0, 0] * data[1, 1] - data[1, 0] * data[0, 1];
            else if (Rows() == 3)
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
            if (Math.Abs(det) < 0.0001d)
                throw new MatrixInversionException("Determinant to low to calculate inversion.");

            JMatrix result = new JMatrix(Rows(), Cols());
            if (Rows() == 1)
            {
                result[0, 0] = 1d / data[0, 0];
                return result;
            }
            else if (Rows() == 2)
            {
                result[0, 0] = data[1, 1];
                result[0, 1] = -data[0, 1];
                result[1, 0] = -data[1, 0];
                result[1, 1] = data[0, 0];
                result = 1d / det * result;
                return result;
            }
            else if (Rows() == 3)
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
                result = 1d / det * result;
                return result;
            }
            else
                throw new NotImplementedException("Inversion of matrix larger than 3x3 is not implemented yet."); 
        }

        public JMatrix Neg()
        {
            int rows = Rows();
            int cols = Cols();
            JMatrix result = new JMatrix(data);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result[i, j] = -result[i, j];
            return result;
        }

        public JMatrix T()
        {
            int rows = Rows();
            int cols = Cols();
            JMatrix result = new JMatrix(cols, rows);
            for (int i = 0; i < cols; i++)
                for (int j = 0; j < rows; j++)
                    result[i, j] = data[j, i];
            return result;
        }

        public JMatrix Clone()
        {
            return new JMatrix(this);
        }

        public override string ToString()
        {
            int rows = Rows();
            int cols = Cols();
            string result = "JMatrix, size: " + rows + "x" + cols + Environment.NewLine;
            for (int i = 0;i < rows;i++)
            {
                result += "[";
                for (int j = 0;j < cols;j++)
                {
                    result += data[i,j].ToString(CultureInfo.InvariantCulture);
                    if (j != cols - 1)
                        result += ", ";
                }
                result += "]" + Environment.NewLine;
            }
            return result;
        }

        #endregion

        #region MATH FUNCTIONS

        public JMatrix Abs()
        {
            int rows = Rows();
            int cols = Cols();
            JMatrix result = new JMatrix(rows, cols);
            for (int i = 0; i < rows; i++)
                for (int j = 0;j < cols; j++)
                result[i, j] = Math.Abs(data[i, j]);
            return result;
        }

        public JMatrix Exp()
        {
            int rows = Rows();
            int cols = Cols();
            JMatrix result = new JMatrix(rows, cols);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result[i, j] = Math.Exp(data[i, j]);
            return result;
        }

        public JMatrix Log()
        {
            int rows = Rows();
            int cols = Cols();
            JMatrix result = new JMatrix(rows, cols);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result[i, j] = Math.Log(data[i, j]);
            return result;
        }

        public JMatrix Log10()
        {
            int rows = Rows();
            int cols = Cols();
            JMatrix result = new JMatrix(rows, cols);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result[i, j] = Math.Log10(data[i, j]);
            return result;
        }

        public JMatrix Pow(double power)
        {
            int rows = Rows();
            int cols = Cols();
            JMatrix result = new JMatrix(rows, cols);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result[i, j] = Math.Pow(data[i, j], power);
            return result;
        }

        #endregion

        #region OPERATORS

        public double this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }

        public static JMatrix operator +(JMatrix m1, JMatrix m2)
        {
            int m1x = m1.Rows();
            int m1y = m1.Cols();
            int m2x = m2.Rows();
            int m2y = m2.Cols();

            if (m1x != m2x || m1y != m2y)
                throw new InvalidMatrixSizeException("Invalid matrix size. Matrix should have the same rows and columns count.");

            JMatrix result = new JMatrix(m1x, m1y);
            for (int i = 0; i < m1x; i++)
                for (int j = 0; j < m1y; j++)
                    result[i, j] = m1[i, j] + m2[i, j];
            return result;
        }

        public static JMatrix operator +(double d, JMatrix m)
        {
            JMatrix result = new JMatrix(m);
            for (int i = 0; i < result.Rows(); i++)
                for (int j = 0; j < result.Cols(); j++)
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
            int m1x = m1.Rows();
            int m1y = m1.Cols();
            int m2x = m2.Rows();
            int m2y = m2.Cols();

            if (m1y != m2x)
                throw new InvalidMatrixSizeException("Invalid matrix size. Left side matrix should have the same columns as right side matrix has rows.");

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
            // each vector is treated as column in default
            if (m.Cols() != v.Count())
                throw new InvalidMatrixSizeException("Invalid matrix size. Matrix should have columns as many as vector's count");

            int c = m.Rows();
            JVector result = new JVector(c, 0d);
            for (int i = 0; i < c; i++)
                for (int j = 0; j < m.Cols(); j++)
                    result[i] += v[j] * m[i, j];
            return result;
        }

        public static JMatrix operator *(double d, JMatrix m)
        {
            JMatrix result = new JMatrix(m);
            int x = m.Rows();
            int y = m.Cols();
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
