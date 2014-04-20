using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NeurNetw
{
    class ImgToVector
    {
        Bitmap bm;
        double[] x;
        int maxX, maxY;
        int squares = 16;
        int lines = 8;
        int sqSize;
        
        public ImgToVector(Bitmap bm, int dim)
        {
            
            this.bm = bm;
            this.maxX = bm.Width;
            this.maxY = bm.Height;
            this.sqSize = maxX/4;
            this.x = new double[dim];
        }

        public double[] getVector()
        {
            int[,] matr = new int [maxX, maxY];
            int m;
            for (int i = 0; i<maxX; i++)
            {
                for (int j = 0; j<maxY; j++)
                {
                    if (bm.GetPixel(i,j).ToArgb() == Color.Black.ToArgb())
                    matr[i,j] = 1;
                }
            }
            int n = 0;
            for (int i = 0; i < squares/4; i++)
            {
                for (int j = 0; j < squares/4; j++)
                {
                    m = 0;
                    for (int k = i * sqSize; k < (i + 1) * sqSize; k++)
                    {
                        for (int l = j * sqSize; l < (j + 1) * sqSize; l++)
                            if (matr[k, l] == 1) m++;
                    }
                    //if (m*2 > sqSize * sqSize / 2) x[n] = 1;
                    if (m > 1) x[n] = 1;
                    else x[n] = 0;
                    n++;
                }                   
            }

            /*int lr = maxX/lines;
            for (int i = 0; i < lines; i++)
            {
                int k1 = 0;
                for (int j = 0; j < maxY-1; j++)
                {
                    if ((matr[i, j] == 0) && (matr[i, j + 1] == 1) || (matr[i, j] == 1) && (matr[i, j + 1] == 0)) k1++;
                }
                if 
            }*/
            return x;
        }



    }
}
