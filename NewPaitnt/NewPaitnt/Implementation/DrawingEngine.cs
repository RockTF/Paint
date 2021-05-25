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
using Rectangle = NewPaitnt.Vector.Rectangle;

namespace NewPaitnt.Implementation
{
    public class DrawingEngine
    {
        //public int Xclick { get; set; }
        //public int Yclick { get; set; }
        //public int Xmove { get; set; }
        //public int Ymove { get; set; }
        //public int Xstart { get; set; }
        //public int Ystart { get; set; }
        //public int Xend { get; set; }
        //public int Yend { get; set; }
        public int UndoIndex { get; set; }

       

        public Bitmap MainImage { get; set; }
        public  Bitmap TempImage { get; set; }
       
        public  Bitmap Transparent { get; set; }
        public Bitmap ClearTransparent { get; set; }
        
        // Прозрачный черный цвет для очистки изображения фигуры
        public  Color BlackTrasparent { get; set; }
        public Graphics MainGraphics { get; set; }
        
        // Обьект графики для работы с временным изображением - чтобы перерисовывать а не копировать
        public Graphics TempGraphics { get; set; }
        public Graphics FigureGraphics { get; set; }
       
        public List<Bitmap> History { get; set; }
        public List<Figure> figure { get; set; }


        // Временный тип штриха для рисования точек (возможно костыль)
        public DashStyle TempDashStyle { get; set; }
        public Settings settings;
        



        public void Initialize()
        {
            

            MainImage = new Bitmap(settings.ImageWidth, settings.ImageHeight); // создавание основного изображения области рисования
            TempImage = new Bitmap(settings.ImageWidth, settings.ImageHeight); // создавание временного изображения
            Transparent = new Bitmap(settings.ImageWidth, settings.ImageHeight);  // создавание второй области рисования для того чтобы мы смогли таскать фигуру по форме
            ClearTransparent = new Bitmap(settings.ImageWidth, settings.ImageHeight);  // создавание второй области рисования для того чтобы мы смогли таскать фигуру по форме
            BlackTrasparent = Color.FromArgb(0, 0, 0, 0); // Прозрачный черный цвет

            MainGraphics = Graphics.FromImage(MainImage); // создание основного обьекта графики
            TempGraphics = Graphics.FromImage(TempImage); // создание обьекта графики для работы с временным изображением
            MainGraphics.Clear(Color.White);  // установка белого цвета
            FigureGraphics = Graphics.FromImage(Transparent); // создание обьекта графики фигуры

            History = new List<Bitmap>();  // создание списка истории изменения изображения 
            History.Add((Bitmap)MainImage.Clone());  // добавление исходного изображения в историю
            UndoIndex = 0;  // текущий индекс отмены для истории
                        
            //IsLineFinished = true;  // установка флага окончания рисования кривой
            //AddNextPoint = false;  // установка флага на добавление следующей точки в список
                   
        }
        
        public void ClearCanvas()
        {
            MainGraphics.Clear(Color.White);
        }

       

        public void Draw()
        {
            switch(settings.Mode)
            {
                case EFigure.Dot:
                    Dot dot = new Dot();
                    figure.Add(dot);
                    dot.Draw();
                    
                    break;
                case EFigure.Curve:
                    Curve curve = new Curve();
                    curve.Draw();
                    figure.Add(curve);
                    break;
                case EFigure.Rectangle:
                    Rectangle rectangle = new Rectangle();
                    rectangle.Draw();
                    figure.Add(rectangle);
                    break;
                case EFigure.Ellipse:
                    Ellipse ellipse = new Ellipse();
                    ellipse.Draw();
                    figure.Add(ellipse);
                    break;
                case EFigure.Triangle:
                    Triangle triangle = new Triangle();
                    triangle.Draw();
                    figure.Add(triangle);
                    break;
                case EFigure.Line:
                    Line line = new Line();
                    line.Draw();
                    figure.Add(line);
                    break;
               case EFigure.SmoothCorv:
                    SmoothCurve smoothCurve = new SmoothCurve();
                    smoothCurve.Draw();
                    figure.Add(smoothCurve);
                    break;
                default:
                    break;
            }
        }
            

        /*public static void DrawPoint() // переделал - убрал клонирование Pen для экономии памяти
        {
           TempDashStyle = Settings.Pen.DashStyle;
            Settings.Pen.DashPattern = new float[] { 1f, 1f }; // временно меняем стиль штриха карандашу для отрисовки точки
            MainGraphics.SmoothingMode = Settings.SmoothingMode;  // устанавливаем обьекту графики свойство сглаживания
            MainGraphics.DrawLine(Settings.Pen, Xclick, Yclick, Xclick + 1, Yclick + 1);  // рисуется линия, но из за штриха - фактически в первой точке
            Settings.Pen.DashStyle = TempDashStyle;
        }*/

       
       public static void MainImageToTemporary()
        {
            // Копирование текущего изображения во временное для того, чтобы не затронуть его, пока нажата кнопка мыши
            // и фигура динамически изменяется
            // только для старого метода RefreshDrawingProcess
            //TempImage = (Bitmap)MainImage.Clone();

            // Заменено на перерисовывание вместо клонирования, чтобы не создавать новые тяжелые обьекты Bitmap
            //TempGraphics.DrawImage(MainImage, 0, 0);
        }

        public static void SaveToHistory()
        {
           /* if (History.Count < 32)
            {
                History.Add((Bitmap)MainImage.Clone());
            }
            else
            {
                History.RemoveAt(0);
                History.Add((Bitmap)MainImage.Clone());
            }
            UndoIndex = History.Count - 1;*/
        }

        public static void Undo()
        {
           /* UndoIndex = (UndoIndex > 0) ? UndoIndex - 1 : UndoIndex;
            MainGraphics.DrawImage(History[UndoIndex], 0, 0);*/
        }

        public static void Redo()
        {
           /* UndoIndex = (UndoIndex < History.Count - 1) ? UndoIndex + 1 : UndoIndex;
            MainGraphics.DrawImage(History[UndoIndex], 0, 0);*/
        }

        public static void ClearUnnecessaryHistory()
        {
           /* if (UndoIndex == History.Count - 1)
            {
                return;
            }
            else
            {
                History.RemoveRange(UndoIndex + 1, History.Count - 1 - UndoIndex);
            }*/
        }

        public static void RefreshDrawingProcess()
        {
           /* // Новый метод, не требует большого количества памяти, но дергается при резком рывке указателя мыши после простоя
            // Отрисовываем временное изображение в основном для обновления в процессе рисования
            MainGraphics.DrawImage(TempImage, 0, 0);
            // Очищаем изображение с фигурой
            FigureGraphics.Clear(BlackTrasparent);
            // Устанавливаем режим сглаживания обьекту графики с фигурой
            FigureGraphics.SmoothingMode = Settings.SmoothingMode; //требует доработки чтобы не пересечивать постоянно
*/
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