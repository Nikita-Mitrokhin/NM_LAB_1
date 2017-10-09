using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM_LAB_1
{
    class TrueSolution
    {
        private List<Point> points;

        private double U0;


        public TrueSolution(List<Point> entr, double _U0)
        {
            points = entr;
            U0 = _U0;
        }
        private double GetUValue(double x)
        {            
            return (Math.Exp((-0.5) * x));
        }

        public void BuildSolution()
        {
            double x = points[0].X;
            double u = U0;
            points[0].V = u;
            for (int i = 1; i < points.Count; i++)
            {
                x = points[i].X;
                u = GetUValue(x);
                points[i].V = u;
            }
        }

        public List<Point> GetPoints()
        {
            return points;
        }
    }
}
