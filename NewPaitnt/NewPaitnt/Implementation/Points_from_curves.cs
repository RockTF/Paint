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
        //класс для создания точек
        private int _numOfPoint = 0; // номер точки 
        private Point[] _points; // подключаем using System.Drawing массив точек
        private Point[] _pointsForTriangle;
        private Point[] _pointsForLine;

        public void CalculateCoordinatesTriangle(int xStart, int yStart, int xEnd, int yEnd)
        {
            _pointsForTriangle = new Point[]
            {
                new Point(DrawingEngine.Xend, DrawingEngine.Yend),
                new Point(DrawingEngine.Xstart, DrawingEngine.Yend),
                new Point((DrawingEngine.Xstart + DrawingEngine.Xend) / 2, DrawingEngine.Ystart)
            };
        }

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
            // устанавливаем точки 
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

        public Point[] GetPointsTriangle()
        {
            //массив точек для фигур
            return _pointsForTriangle;
        }

        public void CalculatePointForLine(int xClick, int yClick, int xMove, int yMove)
        {
            _pointsForLine = new Point[]
            {
                new Point(xClick,yClick),
                new Point(xMove,yMove)
            };
        }
        public Point[] GetPointsForLine()
        {
           
            return _pointsForLine;
        }
    }
}
