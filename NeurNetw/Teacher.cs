using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace NeurNetw
{
    class Teacher
    {
        double[][] outputs;
        public Bitmap bm;
        int signCnt = 16;
        int lettCnt = 3;
        public List<Correspondance> corr = new List<Correspondance>();

        public void initCorr()
        {
            for (int i = 0; i < lettCnt; i++)
                corr.Add(new Correspondance());
        }

        public void getOuts(string filename)
        {
            double[][] z = new double[signCnt][];
            for (int i = 0; i < signCnt; i++)
                z[i] = new double[lettCnt];
            string[] x = new string[lettCnt];
            string st;
            StreamReader sr = File.OpenText(filename);
            for (int i = 0; i < signCnt-1; i++)
            {
                st = sr.ReadLine();
                if (st != null)
                {
                    x = st.Split(' ');
                    for (int j = 0; j < lettCnt; j++)
                        z[i][j] = Convert.ToDouble(x[j]);
                }
            }
            sr.Close();
            this.outputs = z;
        }

        public void teach(float speed, Network network)
        {
            Boolean complete = false;
            initCorr();
            while (!complete)
            {
                int changes = 0;
                for (int i = 0; i < lettCnt; i++)
                {
                    Image img = Image.FromFile(Convert.ToString(i) + ".jpg");
                    Bitmap bm = new Bitmap(img);
                    this.bm = bm;
                    double[] x = new ImgToVector(bm, signCnt).getVector();
                    double[] y = Oper.mult(x, network.getWeights());
                    if (!y.Equals(outputs[i]))
                    {
                        y = Oper.add(outputs[i], y);
                        network.correctWeights(y);
                        changes++;
                    }
                    corr[i].y = y;
                    corr[i].filename = Convert.ToString(i) + ".jpg";
                    
                }
                if (changes == 0) complete = true;
                network.setCorr(corr);
            }
        }



    }
}
