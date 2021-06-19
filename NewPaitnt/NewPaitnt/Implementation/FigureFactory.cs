using NewPaitnt.Enum;
using NewPaitnt.Interfaces;
using NewPaitnt.VectorModel;
using System;

namespace NewPaitnt.Implementation
{
    public class FigureFactory
    {
        public IDrawable CreateFigure(Point2D click, Point2D move, Settings settings)
        {
            IDrawable figure;
            switch (settings.Mode)
            {
                case EMode.Dot:
                    figure = new Dot(click, settings);
                    break;
                case EMode.Line:
                    figure = new Line(click, move, settings);
                    break;
                case EMode.Rectangle:
                    figure = new Rectangle(click, move, settings);
                    break;
                case EMode.Triangle:
                    figure = new Triangle(click, move, settings);
                    break;
                case EMode.Ellipse:
                    figure = new Ellipse(click, move, settings);
                    break;
                case EMode.RoundedRectangle:
                    figure = new RoundedRectangle(click, move, settings);
                    break;
                case EMode.Curve:
                    figure = new Curve(click, move, settings);
                    break;
                case EMode.SmoothCurve:
                    figure = new SmoothCurve(click, move, settings);
                    break;
                case EMode.Polygon:
                    figure = new Polygon(click, move, settings);
                    break;
                default:
                    throw new Exception("Invalid Mode!");
            }
            return figure;
        }
        public IDrawable ConvertToFigure(IDrawableDTO figure)
        {
            IDrawable convertedFigure;

            Settings settings = Settings.Initialize();

            settings.SetPenColor(figure.PenColor);
            settings.SetPenWidth(figure.PenWidth);
            settings.SetPenDashStyle(figure.PenDashStyle);
            settings.SetBrushColor(figure.BrushColor);
            if (figure.IsSmoothed)
            {
                settings.SetSmooth();
            }
            else
            {
                settings.SetUnsmooth();
            }

            switch (figure.FigureType)
            {
                case EFigure.Dot:
                    settings.SetMode(EMode.Dot);
                    convertedFigure = new Dot(figure.Points, settings);
                    break;
                case EFigure.Line:
                    settings.SetMode(EMode.Line);
                    convertedFigure = new Line(figure.Points[0],figure.Points[1], settings);
                    break;
                case EFigure.Rectangle:
                    settings.SetMode(EMode.Rectangle);
                    convertedFigure = new Rectangle(figure.Points[0], figure.Points[1], settings);
                    break;
                case EFigure.Triangle:
                    settings.SetMode(EMode.Triangle);
                    convertedFigure = new Triangle(figure.Points[0], figure.Points[1], settings);
                    break;
                case EFigure.Ellipse:
                    settings.SetMode(EMode.Ellipse);
                    convertedFigure = new Ellipse(figure.Points[0], figure.Points[1], settings);
                    break;
                case EFigure.RoundedRectangle:
                    settings.SetMode(EMode.RoundedRectangle);
                    convertedFigure = new RoundedRectangle(figure.Points[0], figure.Points[1], settings);
                    break;
                case EFigure.Curve:
                    settings.SetMode(EMode.Curve);
                    convertedFigure = new Curve(figure.Points, settings);
                    break;
                case EFigure.SmoothCurve:
                    settings.SetMode(EMode.SmoothCurve);
                    convertedFigure = new SmoothCurve(figure.Points, settings);
                    break;
                case EFigure.Polygon:
                    settings.SetMode(EMode.Polygon);
                    convertedFigure = new Polygon(figure.Points, settings);
                    break;
                default:
                    throw new Exception("Invalid Figure Type!");
            }
            return convertedFigure;
        }

        public void ResetAllCounters()
        {
            Point2D click = new Point2D(0, 0);
            Point2D move = new Point2D(1, 1);
            Settings settings = Settings.Initialize();

            (new Dot(click, settings)).ResetCounter();
            (new Line(click, move, settings)).ResetCounter();
            (new Rectangle(click, move, settings)).ResetCounter();
            (new Triangle(click, move, settings)).ResetCounter();
            (new Ellipse(click, move, settings)).ResetCounter();
            (new RoundedRectangle(click, move, settings)).ResetCounter();
            (new Curve(click, move, settings)).ResetCounter();
            (new SmoothCurve(click, move, settings)).ResetCounter();
            (new Polygon(click, move, settings)).ResetCounter();
        }
    }
}
