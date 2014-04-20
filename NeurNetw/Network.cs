using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace NeurNetw
{
    class Network
    {
        int neurCnt = 5;
        public int signCnt = 16;
        double[,] weights;
        public List<Correspondance> corr = new List<Correspondance>(3);

        public Network()
        {
            this.weights = new double[signCnt, neurCnt];
        }
        public Network(string filename)
        {
            String st;
            string[] x = new string[neurCnt];
            double[,]z = new double[signCnt,neurCnt];
            StreamReader sr = File.OpenText(filename);
            for (int i = 0; i < signCnt; i++)
            {
                st = sr.ReadLine();
                x = st.Split(' ');
                for (int j = 0; j < neurCnt; j++)
                    z[i,j] = Convert.ToDouble(x[j]);
            }
            sr.Close();
        }

        public void resetWeights()
        {
            for (int i = 0; i < signCnt; i++)
                for (int j = 0; j < neurCnt; j++)
                    weights[i, j] = 0;
        }

        public double[,] getWeights()
        {
            return this.weights;
        }

        public void setCorr(List<Correspondance> corr)
        {
            this.corr = corr;
        }

        public void correctWeights(double[] y)
        {
            for (int i = 0; i < weights.GetLength(0); i++)
                for (int j = 0; j < y.Length; j++)
                    weights[i, j] -= y[j]; 
        }



        public string recognize(double[] x)
        {
            double[] y = Oper.mult(x, weights);
            Predicate<Correspondance> pr = c=>c.y.Equals(y);
            String result = corr.Find(pr).filename;
            return result;
        }
    }
}
