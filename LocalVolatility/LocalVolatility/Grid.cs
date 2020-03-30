﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalVolTest
{
    class Grid
    {
        private readonly double [,] prices;
        public int nbRows { get; }
        public int nbCols { get; }
        public double[] tenors { get; }
        public double[] strikes { get; }
        public double this[int i, int j]
        {
            get => prices[i, j];
            set => prices[i, j] = value;
        }
        public Grid(double?[,] source, double[] tenors, double[] strikes)
        {
            nbRows = source.GetLength(0);
            nbCols = source.GetLength(1);
            //Check if it contains null values and apply cubic spline if its the case
            prices= RemoveHoles(source);
            this.tenors = tenors;
            this.strikes = strikes;
            if (nbCols != tenors.Length)
            {
                throw new Exception($"Cannot build Grid, dimension error :\n\tA : {nbCols}x{tenors.Length}");
            }
            if (nbRows != strikes.Length)
            {
                throw new Exception($"Cannot build Grid, dimension error :\n\tA : {nbRows}x{strikes.Length}");
            }

        }
        private double[,] RemoveHoles(double?[,] source)
        {
            double[,] sourceWithoutNulls = new double[nbRows, nbCols];
            ///////////////////////////////////////////////////////////
            ////////////////CUBIC SPLINE/////////////////////////////
            ///////////////////////////////////////////////////////////

            return sourceWithoutNulls;
        }
        
        public Dictionary<string, double[,]> Sensitivities()
        {
            double[,] dK = new double[nbRows - 1, nbCols - 1];
            double[,] dT = new double[nbRows - 1, nbCols - 1];
            double[,] dK2 = new double[nbRows - 1, nbCols - 1];
            for (int t = nbCols-1; t>0; t--)
            {
                for(int k = nbRows - 1; k>1; k--)
                {
                    dT[k - 1, t - 1] = (this[k, t] - this[k, t - 1]) / (tenors[t] - tenors[t - 1]);
                    dK[k - 1, t - 1] = (this[k, t] - this[k - 1, t]) / (strikes[k] - strikes[k - 1]);
                    dK2[k - 1, t - 1] = (this[k, t] - 2 * this[k - 1, t] + this[k - 2, t]) / Math.Pow(strikes[k] - strikes[k - 1],2) ;
                }
            }
            Dictionary<string, double[,]> dict = new Dictionary<string, double[,]>();
            dict.Add("dK", dK);
            dict.Add("dT", dT);
            dict.Add("dK2", dK2);
            return dict;
        }
        
       public double[,] LocalVolatility(double [,]dT, double[,]dK, double[,] dK2, double r)
        {
            double[,] locvol = new double[nbRows-1, nbCols-1];
            for(int i = 0; i < nbRows -1; i++)
            {
                for(int j = 0; j < nbCols; j++)
                {
                    locvol[i,j] = Math.Sqrt((dT[i,j] +r*strikes[i]*dK[i,j])/2*Math.Pow(strikes[i],2)*dK2[i,j]);

                }
            }
            return locvol;
        }
    }
}
