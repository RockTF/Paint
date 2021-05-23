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
        private MouseHandeler _mouseHandeler;
        // Список фигур по интерфейсу
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

        private DrawingEngine(Settings settings, MouseHandeler mouseHandeler)
        {
            _settings = settings;
            _mouseHandeler = mouseHandeler;
            _figures = new List<IDrawable>();
            MainImage = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);
            Background = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);
            CurrentFigure = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);
            Foreground = new Bitmap(_settings.ImageWidth, _settings.ImageHeight);
            BlackTransparrent = Color.FromArgb(0, 0, 0, 0);
            MainGraphics = Graphics.FromImage(MainImage);
            BackgroundGraphics = Graphics.FromImage(Background);
            FigureGraphics = Graphics.FromImage(CurrentFigure);
            ForegroundGraphics = Graphics.FromImage(Foreground);
            MainGraphics.Clear(Color.White);
        }

        public static DrawingEngine Initialize(Settings settings, MouseHandeler mouseHandeler)
        {
            if (_drawingEngine == null)
            {
                _drawingEngine = new DrawingEngine(settings, mouseHandeler);
            }
            return _drawingEngine;
        }

        public void ClearCanvas()
        {
            // Чистим список фигур и картинку
            _figures.Clear();
            MainGraphics.Clear(Color.White);
        }

        public void CreateFigure()
        {
            switch (_settings.Mode)
            {
                case Buttons.point:
                    // Добавляем новую соответствующую фигуру в список
                    _figures.Add(new vectorPoint(_settings, _mouseHandeler));
                    break;
                case Buttons.curve:
                    // Закомментировал чтобы не вызывались
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
            // Очищаем основное изображение
            MainGraphics.Clear(Color.White);
            // Отрисовываем на нем последовательно все что есть в списке фигур
            foreach (var figure in _figures)
            {
                figure.Draw(ref MainGraphics);
            }
        }

        // Расписан ниже самый распространенный случай
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
                // Очищаем основное изображение
                MainGraphics.Clear(Color.White);
                // Отрисовиваем все фигуры ниже выделенной на отдельном прозрачном изображении
                BackgroundGraphics.Clear(BlackTransparrent);
                for (int i = 0; i < figurePosition; i++)
                {
                    _figures[i].Draw(ref BackgroundGraphics);
                }
                // Отрисовываем текущую фигуру на отдельном прозрачном изображении
                FigureGraphics.Clear(BlackTransparrent);
                _figures[figurePosition].Draw(ref FigureGraphics);
                // Отрисовываем все фигуры выше выделенной на отдельном прозрачном изображении
                ForegroundGraphics.Clear(BlackTransparrent);
                for (int i = figurePosition + 1; i < _figures.Count - 1; i++)
                {
                    _figures[i].Draw(ref ForegroundGraphics);
                }
                // Совмещаем все три созданных изображения на основном
                MainGraphics.DrawImage(Background, 0, 0);
                MainGraphics.DrawImage(CurrentFigure, 0, 0);
                MainGraphics.DrawImage(Foreground, 0, 0);
            }
        }

        // Метод для перерисовки выделенной фигуры при каком либо изменении ее свойств
        public void RedrawFigure(int figurePosition)
        {
            _figures[figurePosition].Draw(ref MainGraphics);
        }
    }
}