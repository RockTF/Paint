using NewPaitnt.Interfaces;
using NewPaitnt.VectorModel;
using System.Drawing;


namespace NewPaitnt.Implementation
{
    public class MouseHandler : IMouseHandler
    {
        private static MouseHandler _mouseHandler;

        private Point2D _click;
        private Point2D _previousMove;
        private Point2D _move;
        private Point2D _rightClick;

        private MouseHandler()
        {
            _click = new Point2D(0, 0);
            _previousMove = new Point2D(0, 0);
            _move = new Point2D(0, 0);
            _rightClick = new Point2D(0, 0);
        }

        public static MouseHandler Initialize()
        {
            if (_mouseHandler == null)
            {
                _mouseHandler = new MouseHandler();
            }
            return _mouseHandler;
        }

        public void NewMove(Point move)
        {
            _previousMove = _move;
            _move = PointConverter.SystemToCustom(move);
        }

        public void NewClick(Point click)
        {
            _click = PointConverter.SystemToCustom(click);
            _previousMove = PointConverter.SystemToCustom(click);
            _move = PointConverter.SystemToCustom(click);
        }

        public Point2D GetClick()
        {
            return _click;

        }

        public Point2D GetMove()
        {
            return _move;
        }

        public Point2D GetPreviousMove()
        {
            return _previousMove;
        }

        public Point2D GetRightClick()
        {
            return _rightClick;
        }
    }
}
