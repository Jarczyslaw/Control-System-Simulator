using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JTMath;
using System.Globalization;

namespace JTMath
{
    public class Vector
    {
        public double[] data;

        #region CONSTRUCTORS

        public Vector(int size) : this(size, 0d) { }

        public Vector(int size, double value)
        {
            data = new double[size];
            for (int i = 0; i < data.Length; i++)
                data[i] = value;
        }

        public Vector(double[] data)
        {
            this.data = new double[data.Length];
            for (int i = 0; i < data.Length; i++)
                this.data[i] = data[i];
        }

        public Vector(Vector vector) : this(vector.data) { }

        public Vector(Matrix matrix)
        {
            int len = matrix.Rows();
            data = new double[len];
            for (int i = 0; i < len; i++)
                data[i] = matrix[i, 0];
        }

        #endregion

        #region ACCESS

        public void ForEach(Action<int, double> callback)
        {
            for (int i = 0; i < data.Length; i++)
                callback(i, data[i]);
        }

        #endregion

        #region BASIC FUNCTIONS

        public double Max()
        {
            return data.Max();
        }

        public double Min()
        {
            return data.Min();
        }

        public double Average()
        {
            return data.Average();
        }

        public double Sum()
        {
            return data.Sum();
        }

        public double Length()
        {
            Vector squared = Pow(2);
            double sum = squared.Sum();
            return Math.Sqrt(sum);
        }

        public Vector Inv()
        {
            Vector result = new Vector(data.Length);
            for (int i = 0; i < data.Length; i++)
                result[i] = 1d / data[i];
            return result;
        }

        public Vector Neg()
        {
            Vector result = new Vector(data.Length);
            for (int i = 0; i < data.Length; i++)
                result[i] = -data[i];
            return result;
        }

        public int Count()
        {
            return data.Length;
        }

        public Vector Clone()
        {
            return new Vector(this);
        }

        public override string ToString()
        {
            string result = "JVector, size: " + data.Length + Environment.NewLine;
            result += "[";
            for (int i = 0; i < data.Length;i++)
            {
                result += data[i].ToString(CultureInfo.InvariantCulture);
                if (i != data.Length - 1)
                    result += ", ";
            }
            result += "]";
            return result;
        }

        public double Push(double value)
        {
            double result = data[0];
            for (int i = data.Length - 1; i >= 1; i--)
                data[i] = data[i - 1];
            data[0] = value;
            return result;
        }
        #endregion

        #region MATH FUNCTIONS

        public Vector Abs()
        {
            Vector result = new Vector(data.Length);
            for (int i = 0; i < data.Length; i++)
                result[i] = Math.Abs(data[i]);
            return result;
        }

        public Vector Exp()
        {
            Vector result = new Vector(data.Length);
            for (int i = 0; i < data.Length; i++)
                result[i] = Math.Exp(data[i]);
            return result;
        }

        public Vector Log()
        {
            Vector result = new Vector(data.Length);
            for (int i = 0; i < data.Length; i++)
                result[i] = Math.Log(data[i]);
            return result;
        }

        public Vector Log10()
        {
            Vector result = new Vector(data.Length);
            for (int i = 0; i < data.Length; i++)
                result[i] = Math.Log10(data[i]);
            return result;
        }

        public Vector Pow(double power)
        {
            Vector result = new Vector(data.Length);
            for (int i = 0; i < data.Length; i++)
                result[i] = Math.Pow(data[i], power);
            return result;
        }

        #endregion

        #region OPERATORS

        public double this[int i]
        {
            get { return data[i]; }
            set { data[i] = value; }
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            if (vector1.Count() != vector2.Count())
                throw new InvalidVectorsLengthException("Vectors have different length");

            Vector result = new Vector(vector1.Count());
            for (int i = 0; i < vector1.Count(); i++)
                result[i] = vector1[i] + vector2[i];

            return result;
        }

        public static Vector operator +(double value, Vector vector)
        {
            Vector result = new Vector(vector.Count());
            for (int i = 0; i < result.Count(); i++)
                result[i] = vector[i] + value;
            return result;
        }

        public static Vector operator +(Vector vector, double value)
        {
            return value + vector;
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return vector1 + vector2.Neg();
        }

        public static Vector operator -(double value, Vector vector)
        {
            return value + vector.Neg();
        }

        public static Vector operator -(Vector vector, double value)
        {
            return vector + (-value);
        }

        public static Vector operator *(Vector vector1, Vector vector2)
        {
            if (vector1.Count() != vector2.Count())
                throw new InvalidVectorsLengthException("Vectors have different length");

            Vector result = new Vector(vector1.Count());
            for (int i = 0; i < vector1.Count(); i++)
                result[i] = vector1[i] * vector2[i];

            return result;
        }

        public static Vector operator *(double value, Vector vector)
        {
            Vector result = new Vector(vector.Count());
            for (int i = 0; i < result.Count(); i++)
                result[i] = vector[i] * value;
            return result;
        }

        public static Vector operator *(Vector vector, double value)
        {
            return value * vector;
        }

        public static Vector operator -(Vector vector)
        {
            return vector.Neg();
        }

        #endregion
    }
}
