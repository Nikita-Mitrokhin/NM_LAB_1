using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM_LAB_1
{
    class Method
    {
        Point currP;

        private int maxsteps;//максимальное количество шагов

        private double h; //шаг
        private double eps; //контроль шага
        private double eBorder; //контроль выхода на границу

        private List<Point> points = new List<Point>(); //массив точек для отрисовки графика
        private List<TableInfo> table_data = new List<TableInfo>(); //массив данных таблицы
        private int step_counter; // Подсчёт шагов
        private int pluscorr_Step;
        private int minuscorr_Step;



        public void Init(Point _currP, int _maxsteps, double _h, double _eps, double _eBorder,
            int _plus_corr_Step, int _minus_corr_Step)
        {
            currP = _currP;
            maxsteps = _maxsteps;
            h = _h;
            eps = _eps;
            eBorder = _eBorder;
            pluscorr_Step = _plus_corr_Step;
            minuscorr_Step = _minus_corr_Step;
            points.Add(currP);
            table_data.Add(new TableInfo(step_counter, h, currP, 0, 0, 0, 0, 0, 0, 0));
            step_counter++;
        }

        public void Start()
        {
            while (!NeedStop())
            {
                double _h = h; // тот h, который нужен для получения новой точки
                Point newpoint = MakeStep(currP, h);
                Point halfpoint = HalfPointM(currP, h);
                double s = Math.Abs(GetS(halfpoint, newpoint));
                double err_l = Math.Abs(Math.Pow(2.0, 2.0) * s);
                double corr_v = GetVCorrect(newpoint, s);
                if (s <= eps / (Math.Pow(2.0, 3.0)))
                {
                    currP = newpoint;
                    h = 2.0 * h;
                    pluscorr_Step++;
                    points.Add(newpoint);
                }
                else if (s > eps)
                {
                    h = h / 2.0;
                    minuscorr_Step++;
                }
                else
                {
                    currP = newpoint;
                    points.Add(newpoint);
                }
                table_data.Add(new TableInfo(step_counter, _h, currP, halfpoint.V, err_l, currP.V - halfpoint.V,
                    s, corr_v, pluscorr_Step, minuscorr_Step));
                step_counter++;
            }
        }

        private double GetVCorrect(Point p, double s)
        {
            return p.V + Math.Pow(2.0, 2.0) * s;
        }
        //p2 - это Vn с двумя крышками , p1 - Vn
       
        private double GetS(Point _halfPoint, Point _newPoint)
        {
            return (_halfPoint.V - _newPoint.V) / (2.0 * 2.0 - 1.0);
        }
        private Point HalfPointM(Point p, double h)
        {
            Point _p = MakeStep(p, h / 2.0);
            return MakeStep(_p, h / 2.0);
        }

        public bool NeedStop()
        {
            bool stop = false;
            if (step_counter >= maxsteps || currP.V < eBorder)
                stop = !stop;
            return stop;
        }

        private Point MakeStep(Point p, double h)
        {
            double pX = GetNextX(p.X, h);
            double pV = GetNextV(p.X, p.V, h);
            return new Point(pX, pV);
        }

     
        private double GetNextX(double x, double h)
        {
            return (x + h);
        }

        private double GetNextV(double x, double v, double h)
        {

            double F = f(x + h / 2.0, v + (h / 2.0) * f(x, v));
            return v + h * F;
        }
             
        private double f(double x, double u)  //Вычисление правой части д.у
        {

            return ((-0.5) * u);
        }

     
        public List<TableInfo> GetMetodInfos()
        {
            return table_data;
        }
        public List<Point> GetPoints()
        {
            return points;
        }

    }
}
