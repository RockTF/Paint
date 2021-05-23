using NewPaitnt.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using NewPaitnt.Vector;

namespace NewPaitnt.Implementation
{
    public class DrawingEngine
    {
        private static DrawingEngine _drawingEngine;
        private Settings _settings;
        private MouseHandeler _mouseHandler;
        private List<IDrawable> _figures;
        public Bitmap MainImage;
        private Bitmap Background;
        private Bitmap CurrentFigure;
        private Bitmap Foreground;
        private Color BlackTransparrent;
        private Graphics MainGraphics;
        private Graphics BackgroundGraphics;
        private Graphics FigureGraphics;
        private Graphics ForegroundGraphics;
        public enum Buttons // переместил для читабельности
        {
            point,
            curve,
            rectangle,
            ellipse,
            triangle,
            line,
            smoothCorv
        }

        private DrawingEngine()
        {
            _settings = Settings.Initialize();
            _mouseHandler = MouseHandeler.Initialize();
            MainImage = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);
            Background = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);
            CurrentFigure = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);
            Foreground = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);
            BlackTransparrent = Color.FromArgb(0, 0, 0, 0);
            MainGraphics = Graphics.FromImage(MainImage);
            BackgroundGraphics = Graphics.FromImage(Background);
            FigureGraphics = Graphics.FromImage(CurrentFigure);
            ForegroundGraphics = Graphics.FromImage(Foreground);

        }

        public static DrawingEngine Initialize()
        {
            if (_drawingEngine == null)
            {
                _drawingEngine = new DrawingEngine();
            }
            return _drawingEngine;
        }

        public void ClearCanvas()
        {
            MainGraphics.Clear(Color.White);
        }

        public void CreateFigure()
        {
            switch (_settings.Mode)
            {
                case Buttons.point:
                    _figures.Add(new vectorPoint());
                    break;
                case Buttons.curve:
                    //DrawCurve();
                    break;
                case Buttons.rectangle:
                    //DrawRectangle();
                    break;
                case Buttons.ellipse:
                    //DrawEllipse();
                    break;
                case Buttons.triangle:
                    //DrawTriangle();
                    break;
                case Buttons.line:
                    //DrawLine();
                    break;
                case Buttons.smoothCorv:
                    //DrawSmoothCurve();
                    break;
                default:
                    break;
            }
        }

        public void DrawAllFigures()
        {
            MainGraphics.Clear(Color.White);
            foreach (var figure in _figures)
            {
                figure.Draw(ref MainGraphics);
            }
        }

        public void SelectFigure(int figurePosition)
        {
            if (figurePosition == 0)
            {
                MainGraphics.Clear(Color.White);

                BackgroundGraphics.Clear(BlackTransparrent);

                FigureGraphics.Clear(BlackTransparrent);
                _figures[figurePosition].Draw(ref FigureGraphics);

                ForegroundGraphics.Clear(BlackTransparrent);
                for (int i = figurePosition + 1; i < _figures.Count - 1; i++)
                {
                    _figures[i].Draw(ref ForegroundGraphics);
                }

                MainGraphics.DrawImage(Background, 0, 0);
                MainGraphics.DrawImage(CurrentFigure, 0, 0);
                MainGraphics.DrawImage(Foreground, 0, 0);
            }
            else if (figurePosition == _figures.Count - 1)
            {
                MainGraphics.Clear(Color.White);

                BackgroundGraphics.Clear(BlackTransparrent);
                for (int i = 0; i < figurePosition; i++)
                {
                    _figures[i].Draw(ref BackgroundGraphics);
                }

                FigureGraphics.Clear(BlackTransparrent);
                _figures[figurePosition].Draw(ref FigureGraphics);

                ForegroundGraphics.Clear(BlackTransparrent);

                MainGraphics.DrawImage(Background, 0, 0);
                MainGraphics.DrawImage(CurrentFigure, 0, 0);
                MainGraphics.DrawImage(Foreground, 0, 0);
            }
            else
            {
                // очистить основное изображение
                MainGraphics.Clear(Color.White);
                // отрисовать все фигуры ниже выделенной
                BackgroundGraphics.Clear(BlackTransparrent);
                for (int i = 0; i < figurePosition; i++)
                {
                    _figures[i].Draw(ref BackgroundGraphics);
                }
                // отрисовать текущую фигуру
                FigureGraphics.Clear(BlackTransparrent);
                _figures[figurePosition].Draw(ref FigureGraphics);
                // отрисовать все фигуры выше выделенной
                ForegroundGraphics.Clear(BlackTransparrent);
                for (int i = figurePosition + 1; i < _figures.Count - 1; i++)
                {
                    _figures[i].Draw(ref ForegroundGraphics);
                }
                // перерисовать основное изображение
                MainGraphics.DrawImage(Background, 0, 0);
                MainGraphics.DrawImage(CurrentFigure, 0, 0);
                MainGraphics.DrawImage(Foreground, 0, 0);
            }
        }

        public void RedrawFigure(int figurePosition)
        {
            _figures[figurePosition].Draw(ref MainGraphics);
        }
               
    }
}