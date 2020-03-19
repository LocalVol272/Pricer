using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalVolatility
{
    public class MatrixDecomposition : Matrix<double>
    {
        public MatrixDecomposition(int n):base(n){}
        public MatrixDecomposition(int m, int n) : base(m, n) { }
        public MatrixDecomposition(int m, int n, double x) : base(m, n, x) { }
        public MatrixDecomposition(double[,] source) : base(source) { }
        public MatrixDecomposition(Matrix<double> A): base(A) { }        

        protected override Matrix<double> Clone() => new MatrixDecomposition(this);
        protected override Matrix<double> CreateMatrix(int m, int n) => new MatrixDecomposition(m, n);
        protected override double Negative(double x) => -x;
        protected override double Add(double x, double y) => x + y;
        protected override double Multiply(double x, double y) => x * y;
        protected override double Sqrt(double x) => Math.Sqrt(x);
        
        public Dictionary<string,Matrix<double>> CholeskyDecomposition()
        {
            if (nbRows != nbCols)
            {
                throw new Exception($"Cannot compute Cholesky decomposition, matrix is not square:\n\tA : {nbRows}x{nbCols}");
            }
            Matrix<double> res = CreateMatrix(nbRows, nbCols);
            double dscnt;
            for(int i =0; i < nbRows; i++)
            {
                for(int j =0; j < nbCols; j++)
                {
                    dscnt = this[i, j];
                    for(int h=0; h <i; h++)
                    {
                        dscnt -= res[i, h] * res[j, h];
                    }
                    if (i == j)
                    {
                        res[i,j] = Sqrt(dscnt);
                    }
                    else
                    {
                        res[j, i] = dscnt / res[i, i];
                    }
                }
            }
            Dictionary<string, Matrix<double>> dict = new Dictionary<string, Matrix<double>>();
            dict.Add("L", res);
            dict.Add("Lt", res.Transpose());
            return dict;
        }
        public Dictionary<string, Matrix<double>> LUDecomposition()
        {
            if (nbRows != nbCols)
            {
                throw new Exception($"Cannot compute LU decomposition, matrix is not square:\n\tA : {nbRows}x{nbCols}");
            }
            Matrix<double> L = CreateMatrix(nbRows, nbCols);
            Matrix<double> U = CreateMatrix(nbRows, nbCols);
            double dummy = 0;
            for(int i =0; i < nbRows; i++)
            {
                L[i, i] = 1;
            }
            for (int i = 0; i < nbRows; i++)
            {
                for(int j =0; j < nbCols; j++)
                {
                    dummy = this[i, j];
                    if (i <= j)
                    {
                        for(int h = 0; h <i; h++)
                        {
                            dummy -= U[h, j] * L[i, h];
                        }
                        U[i, j] = dummy;
                    }
                    else
                    {
                        for(int h = 0; h <j; h++)
                        {
                            dummy -= U[h, j] * L[i, h];
                        }
                        L[i, j] = dummy / U[j, j];
                    }
                }
            }
            Dictionary<string, Matrix<double>> dict = new Dictionary<string, Matrix<double>>();
            dict.Add("L", L);
            dict.Add("U", U);
            return dict;
        }
    }
}
