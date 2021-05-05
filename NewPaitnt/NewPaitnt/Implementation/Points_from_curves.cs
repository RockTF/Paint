using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Implementation
{
   public class Points
    {
        //класс для создвние точек
        private int _numOfPoint = 0; // номер точки 
        private Point[] _points; // подключаем using System.Drawing массив точек
        public Points(int size)
        {
            if (size <= 0) // проверка на размер 
            {
                size = 2;
            }
            else
            {
                _points = new Point[size];
            }
        }

        public void SetPoint(int x, int y)
        {
            // устанавливае точки 
            if (_numOfPoint >= _points.Length) // проверяем не выходим ли мы за длину
            {
                _numOfPoint = 0;
            }
            else
            {
                _points[_numOfPoint] = new Point(x, y);
                _numOfPoint++;
            }

        }

        public void ResetPoints()
        {
            //обнуляем количество точек чтоб начать заново
            _numOfPoint = 0;
        }
        public int GetCountPoints()
        {
            // для проверки кол-ва точек 
            return _numOfPoint;
        }
        public Point[] GetPoints()
        {
            //массив точек для фигур
            return _points;
        }
    }
}
