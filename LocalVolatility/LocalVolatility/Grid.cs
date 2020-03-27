using System;
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

       
    }
}
