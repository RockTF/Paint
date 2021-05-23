﻿using System.Drawing;
using System.Windows.Forms;

namespace NewPaitnt.Implementation
{
    public class MouseHandeler
    {
        private static MouseHandeler _mouseHandeler;
        public Point Click { get; private set; }
        public Point PreviousMove { get; private set; }
        public Point Move { get; private set; }
        public Point RightClick { get; private set; }
        private DrawingEngine _drawingEngine;

        private MouseHandeler()
        {
            Click = new Point(0, 0); 
            PreviousMove = new Point(0, 0);
            Move = new Point(0, 0);
            RightClick = new Point(0, 0);
        }
        public static MouseHandeler Initialize()
        {
            if (_mouseHandeler == null)
            {
                _mouseHandeler = new MouseHandeler();
            }
            return _mouseHandeler;
        }
        public void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Click = e.Location;
                PreviousMove = e.Location;
                Move = e.Location;
            }
            else if(e.Button == MouseButtons.Right)
            {
                RightClick = e.Location;
            }
            // Вызываем метод создания новой фигуры
            _drawingEngine.CreateFigure();
            // Отрисовываем все фигуры - пока чтобы работало, потом надо будет переделать более корректно
            _drawingEngine.DrawAllFigures();
        }
        public void MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PreviousMove = Move;
                Move = e.Location;
            }
        }
        public void MouseUp(object sender, MouseEventArgs e)
        {

        }

        public void SetDrawingEngine(DrawingEngine drawingEngine)
        {
            _drawingEngine = drawingEngine;
        }
    }
}
