using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPaitnt.Implementation
{
    class MouseHandler
    {
        private static MouseHandler _mouseHandler;

        private Point _click;
        private Point _previousMove;
        private Point _move;
        private Point _rightClick;

        private MouseHandler()
        {
            _click = new Point(0, 0);
            _previousMove = new Point(0, 0);
            _move = new Point(0, 0);
            _rightClick = new Point(0, 0);
        }

        public static MouseHandler Initialize()
        {
            if (_mouseHandler == null)
            {
                _mouseHandler = new MouseHandler();
            }
            return _mouseHandler;
        }
        public void NewRightClick(Point rightClick)
        {
            _rightClick = rightClick;
        }
        public void NewMove(Point move)
        {
            _previousMove = _move;
            _move = move;
        }
        public void NewClick(Point click)
        {
            _click = click;
            _previousMove = click;
            _move = click;
        }
        public Point GetClick()
        {
            return _click;

        }
        public Point GetMove()
        {
            return _move;
        }
        public Point GetPreviousMove()
        {
            return _previousMove;
        }
        public Point GetRightClick()
        {
            return _rightClick;
        }

    }
}
