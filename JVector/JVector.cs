using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JVector.Exceptions;
using System.Globalization;

namespace JVector
{
    public class JVector
    {
        private double[] data;

        public JVector(int size) : this(size, 0) { }

        public JVector(int size, double value)
        {
            data = new double[size];
            for (int i = 0; i < data.Length; i++)
                data[i] = value;
        }

        public JVector(double[] data)
        {
            this.data = new double[data.Length];
            for (int i = 0; i < data.Length; i++)
                this.data[i] = data[i];
        }

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
            JVector squared = Pow(2);
            double sum = squared.Sum();
            return Math.Sqrt(sum);
        }

        public JVector Inv()
        {
            JVector result = new JVector(data.Length);
            for (int i = 0; i < data.Length; i++)
                result[i] = 1d / data[i];
            return result;
        }

        public int Count()
        {
            return data.Length;
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

        #region MATH FUNCTIONS
        public JVector Abs()
        {
            JVector result = new JVector(data.Length);
            for (int i = 0; i < data.Length; i++)
                result[i] = Math.Abs(data[i]);
            return result;
        }

        public JVector Exp()
        {
            JVector result = new JVector(data.Length);
            for (int i = 0; i < data.Length; i++)
                result[i] = Math.Exp(data[i]);
            return result;
        }

        public JVector Log()
        {
            JVector result = new JVector(data.Length);
            for (int i = 0; i < data.Length; i++)
                result[i] = Math.Log(data[i]);
            return result;
        }

        public JVector Log10()
        {
            JVector result = new JVector(data.Length);
            for (int i = 0; i < data.Length; i++)
                result[i] = Math.Log10(data[i]);
            return result;
        }

        public JVector Pow(double power)
        {
            JVector result = new JVector(data.Length);
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

        public static JVector operator +(JVector vector1, JVector vector2)
        {
            if (vector1.Count() != vector2.Count())
                throw new InvalidVectorsLengthException("Vectors have different length");

            JVector result = new JVector(vector1.Count());
            for (int i = 0; i < vector1.Count(); i++)
                result[i] = vector1[i] + vector2[i];

            return result;
        }

        public static JVector operator +(double value, JVector vector)
        {
            JVector temp = new JVector(vector.Count(), value);
            return temp + vector;
        }

        public static JVector operator +(JVector vector, double value)
        {
            JVector temp = new JVector(vector.Count(), value);
            return temp + vector;
        }

        public static JVector operator -(JVector vector1, JVector vector2)
        {
            if (vector1.Count() != vector2.Count())
                throw new InvalidVectorsLengthException("Vectors have different length");

            JVector result = new JVector(vector1.Count());
            for (int i = 0; i < vector1.Count(); i++)
                result[i] = vector1[i] - vector2[i];

            return result;
        }

        public static JVector operator -(double value, JVector vector)
        {
            JVector temp = new JVector(vector.Count(), value);
            return temp - vector;
        }

        public static JVector operator -(JVector vector, double value)
        {
            JVector temp = new JVector(vector.Count(), value);
            return temp - vector;
        }

        public static JVector operator *(JVector vector1, JVector vector2)
        {
            if (vector1.Count() != vector2.Count())
                throw new InvalidVectorsLengthException("Vectors have different length");

            JVector result = new JVector(vector1.Count());
            for (int i = 0; i < vector1.Count(); i++)
                result[i] = vector1[i] * vector2[i];

            return result;
        }

        public static JVector operator *(double value, JVector vector)
        {
            JVector temp = new JVector(vector.Count(), value);
            return temp * vector;
        }

        public static JVector operator *(JVector vector, double value)
        {
            JVector temp = new JVector(vector.Count(), value);
            return temp * vector;
        }
        #endregion
    }
}
