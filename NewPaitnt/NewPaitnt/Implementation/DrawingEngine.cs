﻿using NewPaitnt.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static Graphics MainGraphics { get; set; }
        public static Graphics FigureGraphics { get; set; }
        public static Points Points { get; set; }
        public static List<Point> CurvePoints { get; set; }
        public static List<Point> SmoothCurvePoints { get; set; }
        public static List<Bitmap> History { get; set; }


        public static void Initialize()

        {
            MainImage = new Bitmap(Settings.ImageWidth, Settings.ImageHeight);
            //TempImage = new Bitmap(Settings.ImageWidth, Settings.ImageHeight);
            ClearTransparent = new Bitmap(Settings.ImageWidth, Settings.ImageHeight);
            MainGraphics = Graphics.FromImage(MainImage);
            MainGraphics.Clear(Color.White);

            History = new List<Bitmap>();
            History.Add((Bitmap)MainImage.Clone());
            UndoIndex = 0;

            Points = new Points(2);
            CurvePoints = new List<Point>();

            IsLineFinished = true;
            AddNextPoint = false;
            SmoothCurvePoints = new List<Point>();
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
            // Вызывается соответствующий метод рисования
            switch (Settings.Mode)
            {
                case "point":
                    DrawPoint();
                    break;
                case "curve":
                    DrawCurve();
                    break;
                case "rectangle":
                    DrawRectangle();
                    break;
                case "ellipse":
                    DrawEllipse();
                    break;
                case "triangle":
                    DrawTriangle();
                    break;
                case "line":
                    DrawLine();
                    break;
                case "smoothCorv":
                    DrawSmoothCurve();
                    break;
                default:
                    break;
            }
        }

        public static void DrawCurve()
        {
            MainImage = (Bitmap)TempImage.Clone();
            MainGraphics = Graphics.FromImage(MainImage);
            Transparent = (Bitmap)ClearTransparent.Clone();
            FigureGraphics = Graphics.FromImage(Transparent);
            FigureGraphics.SmoothingMode = Settings.SmoothingMode;

            // Мой вариант
            if (CurvePoints.Count == 0)
            {
                // Добавляем кординаты клика (сохраненные на mouseDown) если список пустой
                CurvePoints.Add(new Point(Xclick, Yclick));
            }
            // На каджом перемещении мыши добавляем точку движения в список
            CurvePoints.Add(new Point(Xmove, Ymove));
            // Отрисовывем кривую по всем точкам в списке, список приводим к массиву
            FigureGraphics.DrawCurve(Settings.Pen, CurvePoints.ToArray());

            // Метод Наташи
            //DrawingEngine.Points.SetPoint(Xmove, Ymove);
            //if (DrawingEngine.Points.GetCountPoints() >= 2) //проверяем заполнено или нет 
            //{
            //    DrawingEngine.MainGraphics.DrawLines(Settings.Pen, DrawingEngine.Points.GetPoints());
            //    DrawingEngine.Points.SetPoint(Xmove, Ymove);
            //}
            //DrawingEngine.Points.SetPoint(Xmove, Ymove);

            MainGraphics.DrawImage(Transparent, 0, 0);
            
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static void DrawTriangle()
        {
            MainImage = (Bitmap)TempImage.Clone(); // Преобразование в Bitmap ибо Object
            MainGraphics = Graphics.FromImage(MainImage);
            Transparent = (Bitmap)ClearTransparent.Clone();
            FigureGraphics = Graphics.FromImage(Transparent);
            FigureGraphics.SmoothingMode = Settings.SmoothingMode;
            Points.CalculateCoordinatesTriangle(Xstart, Ystart, Xend, Yend);
            FigureGraphics.FillPolygon(Settings.Brush, Points.GetPointsTriangle());
            FigureGraphics.DrawPolygon(Settings.Pen, Points.GetPointsTriangle());
            MainGraphics.DrawImage(Transparent, 0, 0);

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static void DrawEllipse()
        {
            MainImage = (Bitmap)TempImage.Clone(); // Преобразование в Bitmap ибо Object
            MainGraphics = Graphics.FromImage(MainImage);

            Transparent = (Bitmap)ClearTransparent.Clone();

            FigureGraphics = Graphics.FromImage(Transparent);
            FigureGraphics.SmoothingMode = Settings.SmoothingMode;
            FigureGraphics.FillEllipse(Settings.Brush, Xstart, Ystart, Xend - Xstart, Yend - Ystart);
            FigureGraphics.DrawEllipse(Settings.Pen, Xstart, Ystart, Xend - Xstart, Yend - Ystart);
            MainGraphics.DrawImage(Transparent, 0, 0);

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static void DrawLine()
        {
            MainImage = (Bitmap)TempImage.Clone(); // Преобразование в Bitmap ибо Object
            MainGraphics = Graphics.FromImage(MainImage);
            Transparent = (Bitmap)ClearTransparent.Clone();
            FigureGraphics = Graphics.FromImage(Transparent);
            FigureGraphics.SmoothingMode = Settings.SmoothingMode;
            Points.CalculatePointForLine(Xclick, Yclick, Xmove, Ymove);
            FigureGraphics.DrawLines(Settings.Pen, Points.GetPointsForLine());
            MainGraphics.DrawImage(Transparent, 0, 0);

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static void DrawPoint()
        {
            Pen pointPen = (Pen)Settings.Pen.Clone();
            pointPen.DashPattern = new float[] { 1f, 1f };
            MainGraphics.SmoothingMode = Settings.SmoothingMode;
            MainGraphics.DrawLine(pointPen, Xclick, Yclick, Xclick + 1, Yclick + 1);
        }

        public static void DrawRectangle()
        {
            // Копирование временного изображения в основное каждый раз при перемещении указателя мыши
            // для динамической отрисовки фигуры
            MainImage = (Bitmap)TempImage.Clone();
            // Пересоздание основного обьекта графики на основе основного изображения
            // так как существующий обьект графики продолжает ссылаться в памяти на старое изображение
            MainGraphics = Graphics.FromImage(MainImage);
            // Пересоздание основы для рисования фигуры на основе прозрачного изображения
            // для того, чтобы на каждом движении мыши с зажатой кнопкой отрисовывать фигуру по чистому прозрачному изображению
            Transparent = (Bitmap)ClearTransparent.Clone();
            // Пересоздание обьекта графики фигуры на основе прозрачного изображения
            // причина аналогичная
            FigureGraphics = Graphics.FromImage(Transparent);
            // Задаем новому обьекту графики фигуры режим сглаживания
            FigureGraphics.SmoothingMode = Settings.SmoothingMode;
            // Отрисофка фигуры по прозрачному изображению
            FigureGraphics.FillRectangle(Settings.Brush, Xstart, Ystart, Xend - Xstart, Yend - Ystart);
            FigureGraphics.DrawRectangle(Settings.Pen, Xstart, Ystart, Xend - Xstart, Yend - Ystart);
            // Отрисовка изображения с фигурой на прозрачном фоне поверх основного изображения
            MainGraphics.DrawImage(Transparent, 0, 0);
            // Явный вызов сборщика мусора для удаления старых обьектов графики
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static void DrawSmoothCurve()
        {
            MainImage = (Bitmap)TempImage.Clone();
            MainGraphics = Graphics.FromImage(MainImage);
            Transparent = (Bitmap)ClearTransparent.Clone();
            FigureGraphics = Graphics.FromImage(Transparent);
            FigureGraphics.SmoothingMode = Settings.SmoothingMode;

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

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static void MainImageToTemporary()
        {
            // Копирование текущего изображения во временное для того, чтобы не затронуть его, пока нажата кнопка мыши
            // и фигура динамически изменяется
            TempImage = (Bitmap)MainImage.Clone();
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
    }
}