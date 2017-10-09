using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM_LAB_1
{
    class TableInfo1
    {
        public int iter;
        public double integr_step;
        public Point1 point;
        public double half_V;
        public double dV;
        public double S;
        public double err_loc;
        public double corr_V;
        public int plus_corr_Step;
        public int minus_corr_Step;

        public TableInfo1(int _iter, double _integr_step, Point1 _point, double _half_V, double _err_loc,
            double _dV, double _S, double _corr_V, int _plus_corr_Step, int _minus_corr_Step)
        {
            iter = _iter;
            integr_step = _integr_step;
            point = _point;
            half_V = _half_V;
            dV = _dV;
            S = _S;
            err_loc = _err_loc;
            corr_V = _corr_V;
            plus_corr_Step = _plus_corr_Step;
            minus_corr_Step = _minus_corr_Step;
        }
    }
}
