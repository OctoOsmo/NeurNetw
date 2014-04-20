using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeurNetw
{
    class Oper
    {
        public static double[] mult(double[] x, double[,] y)
        {
            double[] z = new double[x.Length];
            for (int i = 0; i < y.GetLongLength(1); i++)
            {
                for (int j = 0; j < y.GetLongLength(0); j++)
                {
                    z[i] += x[j]*y[j, i];
                }
            }
            return z;
        }

        public static double[] add(double[] x, float s)
        {
            double[] z = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
                z[i] = x[i] + s;
            return z;

        }

        public static double[] add(double[] x, double[] y)
        {
            double[] z = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
                z[i] = x[i] - y[i];
            return z;

        }
    }
}
