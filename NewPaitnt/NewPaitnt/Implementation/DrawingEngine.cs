using NewPaitnt.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace NewPaitnt.Implementation
{
    public static class DrawingEngine
    {
        public static int Xclick { get; set; }
        public static int Yclick { get; set; }
        public static int Xmove { get; set; }
        public static int Ymove { get; set; }
        public static int Xstart { get; set; }
        public static int Ystart { get; set; }
        public static int Xend { get; set; }
        public static int Yend { get; set; }
        public static int UndoIndex { get; set; }

        public static bool IsLineFinished { get; set; }
        public static bool AddNextPoint { get; set; }

        public static Bitmap MainImage { get; set; }
        public static Bitmap TempImage { get; set; }
        public static Bitmap Figure { get ; set; }
        public static Bitmap Transparent { get; set; }
        public static Bitmap ClearTransparent { get; set; }
        
        // Прозрачный черный цвет для очистки изображения фигуры
        public static Color BlackTrasparent { get; set; }
        public static Graphics MainGraphics { get; set; }
        
        // Обьект графики для работы с временным изображением - чтобы перерисовывать а не копировать
        public static Graphics TempGraphics { get; set; }
        public static Graphics FigureGraphics { get; set; }
        public static List<Point> CurvePoints { get; set; }
        public static List<Point> SmoothCurvePoints { get; set; }
        public static List<Point> Triangle { get; set; }
        public static List<Point> Line { get; set; }
        public static List<Bitmap> History { get; set; }
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
        // Временный тип штриха для рисования точек (возможно костыль)
        public static DashStyle TempDashStyle { get; set; }

        public static void Initialize()

        {
            MainImage = new Bitmap(Settings.ImageWidth, Settings.ImageHeight); // создавание основного изображения области рисования
            TempImage = new Bitmap(Settings.ImageWidth, Settings.ImageHeight); // создавание временного изображения
            Transparent = new Bitmap(Settings.ImageWidth, Settings.ImageHeight);  // создавание второй области рисования для того чтобы мы смогли таскать фигуру по форме
            ClearTransparent = new Bitmap(Settings.ImageWidth, Settings.ImageHeight);  // создавание второй области рисования для того чтобы мы смогли таскать фигуру по форме
            BlackTrasparent = Color.FromArgb(0, 0, 0, 0); // Прозрачный черный цвет

            MainGraphics = Graphics.FromImage(MainImage); // создание основного обьекта графики
            TempGraphics = Graphics.FromImage(TempImage); // создание обьекта графики для работы с временным изображением
            MainGraphics.Clear(Color.White);  // установка белого цвета
            FigureGraphics = Graphics.FromImage(Transparent); // создание обьекта графики фигуры

            History = new List<Bitmap>();  // создание списка истории изменения изображения 
            History.Add((Bitmap)MainImage.Clone());  // добавление исходного изображения в историю
            UndoIndex = 0;  // текущий индекс отмены для истории

            CurvePoints = new List<Point>();  // создавание пустого списка для точек

            IsLineFinished = true;  // установка флага окончания рисования кривой
            AddNextPoint = false;  // установка флага на добавление следующей точки в список

            SmoothCurvePoints = new List<Point>();  // создавание списка для сглаженной кривой
        }
        
        public static void ClearCanvas()
        {
            MainGraphics.Clear(Color.White);
        }

        public static void CalculateCoordinates(int Xcurrent, int Ycurrent)
        {
            Xstart = (Xclick < Xcurrent) ? Xclick : Xcurrent;  
            Xend = (Xclick < Xcurrent) ? Xcurrent : Xclick;
            Ystart = (Yclick < Ycurrent) ? Yclick : Ycurrent;
            Yend = (Yclick < Ycurrent) ? Ycurrent : Yclick;
        }

        public static void Draw()
        {
            switch(Settings.Mode)
            {
                case Buttons.point:
                    DrawPoint();
                    break;
                case Buttons.curve:
                    DrawCurve();
                    break;
                case Buttons.rectangle:
                    DrawRectangle();
                    break;
                case Buttons.ellipse:
                    DrawEllipse();
                    break;
                case Buttons.triangle:
                    DrawTriangle();
                    break;
                case Buttons.line:
                    DrawLine();
                    break;
                case Buttons.smoothCorv:
                    DrawSmoothCurve();
                    break;
                default:
                    break;
            }
        }

        public static void DrawCurve() // Найден баг - если рисовать очень активно, в какой то момент перестает рисовать,
                                       // а при отпускании кнопки мыши все оставшееся отрисовывается
        {
            RefreshDrawingProcess();
            if (CurvePoints.Count == 0)
            {
                // Добавляем кординаты клика (сохраненные на mouseDown) если список пустой
                CurvePoints.Add(new Point(Xclick, Yclick));
            }
            // На каджом перемещении мыши добавляем точку движения в список
            CurvePoints.Add(new Point(Xmove, Ymove));
            // Отрисовывем кривую по всем точкам в списке, список приводим к массиву
            FigureGraphics.DrawCurve(Settings.Pen, CurvePoints.ToArray());
            MainGraphics.DrawImage(Transparent, 0, 0);
        }

        public static void DrawTriangle()
        {
            RefreshDrawingProcess();

            Triangle = new List<Point>();

            Triangle.Add(new Point(Xend, Yend));
            Triangle.Add(new Point(Xstart,Yend));
            Triangle.Add(new Point((Xstart + Xend) / 2, Ystart));

            FigureGraphics.FillPolygon(Settings.Brush, Triangle.ToArray());
            FigureGraphics.DrawPolygon(Settings.Pen, Triangle.ToArray());

            MainGraphics.DrawImage(Transparent, 0, 0);
        }

        public static void DrawEllipse()
        {
            RefreshDrawingProcess();
            FigureGraphics.FillEllipse(Settings.Brush, Xstart, Ystart, Xend - Xstart, Yend - Ystart);
            FigureGraphics.DrawEllipse(Settings.Pen, Xstart, Ystart, Xend - Xstart, Yend - Ystart);
            MainGraphics.DrawImage(Transparent, 0, 0);
        }

        public static void DrawLine()
        {
            RefreshDrawingProcess();

            Line = new List<Point>();

            Line.Add(new Point(Xclick, Yclick));
            Line.Add(new Point(Xmove, Ymove));

            FigureGraphics.DrawLines(Settings.Pen, Line.ToArray());
            MainGraphics.DrawImage(Transparent, 0, 0);
        }

        public static void DrawPoint() // переделал - убрал клонирование Pen для экономии памяти
        {
            TempDashStyle = Settings.Pen.DashStyle;
            Settings.Pen.DashPattern = new float[] { 1f, 1f }; // временно меняем стиль штриха карандашу для отрисовки точки
            MainGraphics.SmoothingMode = Settings.SmoothingMode;  // устанавливаем обьекту графики свойство сглаживания
            MainGraphics.DrawLine(Settings.Pen, Xclick, Yclick, Xclick + 1, Yclick + 1);  // рисуется линия, но из за штриха - фактически в первой точке
            Settings.Pen.DashStyle = TempDashStyle;
        }

        public static void DrawRectangle() // Баг - при рисовании малого прямоугольника большим пером серидина не окрашивается, в других фигурах то же самое
        {
            RefreshDrawingProcess();
            // Собственно, рисование фигуры
            FigureGraphics.FillRectangle(Settings.Brush, Xstart, Ystart, Xend - Xstart, Yend - Ystart);
            FigureGraphics.DrawRectangle(Settings.Pen, Xstart, Ystart, Xend - Xstart, Yend - Ystart);
            // Отрисовка фигуры по основному изображению
            MainGraphics.DrawImage(Transparent, 0, 0);

        }

        public static void DrawSmoothCurve()
        {
            RefreshDrawingProcess();

            if (SmoothCurvePoints.Count == 0)
            {
                SmoothCurvePoints.Add(new Point(Xclick, Yclick));
            }

                if (AddNextPoint)
                {
                    SmoothCurvePoints.Add(new Point(Xmove, Ymove));
                }
                else
                {
                    SmoothCurvePoints[SmoothCurvePoints.Count - 1] = new Point(Xmove, Ymove);
                }

                if (IsLineFinished)
                {
                    SmoothCurvePoints.Add(new Point(Xend, Yend));
                }
           
            FigureGraphics.DrawCurve(Settings.Pen, SmoothCurvePoints.ToArray());
            MainGraphics.DrawImage(Transparent, 0, 0);
        }

        public static void MainImageToTemporary()
        {
            // Копирование текущего изображения во временное для того, чтобы не затронуть его, пока нажата кнопка мыши
            // и фигура динамически изменяется
            // только для старого метода RefreshDrawingProcess
            //TempImage = (Bitmap)MainImage.Clone();

            // Заменено на перерисовывание вместо клонирования, чтобы не создавать новые тяжелые обьекты Bitmap
            TempGraphics.DrawImage(MainImage, 0, 0);
        }

        public static void SaveToHistory()
        {
            if (History.Count < 32)
            {
                History.Add((Bitmap)MainImage.Clone());
            }
            else
            {
                History.RemoveAt(0);
                History.Add((Bitmap)MainImage.Clone());
            }
            UndoIndex = History.Count - 1;
        }

        public static void Undo()
        {
            UndoIndex = (UndoIndex > 0) ? UndoIndex - 1 : UndoIndex;
            MainGraphics.DrawImage(History[UndoIndex], 0, 0);
        }

        public static void Redo()
        {
            UndoIndex = (UndoIndex < History.Count - 1) ? UndoIndex + 1 : UndoIndex;
            MainGraphics.DrawImage(History[UndoIndex], 0, 0);
        }

        public static void ClearUnnecessaryHistory()
        {
            if (UndoIndex == History.Count - 1)
            {
                return;
            }
            else
            {
                History.RemoveRange(UndoIndex + 1, History.Count - 1 - UndoIndex);
            }
        }

        public static void RefreshDrawingProcess()
        {
            // Новый метод, не требует большого количества памяти, но дергается при резком рывке указателя мыши после простоя
            // Отрисовываем временное изображение в основном для обновления в процессе рисования
            MainGraphics.DrawImage(TempImage, 0, 0);
            // Очищаем изображение с фигурой
            FigureGraphics.Clear(BlackTrasparent);
            // Устанавливаем режим сглаживания обьекту графики с фигурой
            FigureGraphics.SmoothingMode = Settings.SmoothingMode; //требует доработки чтобы не пересечивать постоянно

            //Старая версия метода, по ощущениям самая плавная
            // Копирование временного изображения в основное каждый раз при перемещении указателя мыши
            // для динамической отрисовки фигуры
            //MainImage = (Bitmap)TempImage.Clone();
            // Пересоздание основного обьекта графики на основе основного изображения
            // так как существующий обьект графики продолжает ссылаться в памяти на старое изображение
            //MainGraphics = Graphics.FromImage(MainImage);
            // Пересоздание основы для рисования фигуры на основе прозрачного изображения
            // для того, чтобы на каждом движении мыши с зажатой кнопкой отрисовывать фигуру по чистому прозрачному изображению
            //Transparent = (Bitmap)ClearTransparent.Clone();
            // Пересоздание обьекта графики фигуры на основе прозрачного изображения
            // причина аналогичная
            //FigureGraphics = Graphics.FromImage(Transparent);
            // Задаем новому обьекту графики фигуры режим сглаживания
            //FigureGraphics.SmoothingMode = Settings.SmoothingMode;
            
            // В методе рисования необходимо явно вызывать сборщик мусора
        }
    }
}