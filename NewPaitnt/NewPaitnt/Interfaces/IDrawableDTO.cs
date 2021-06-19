using NewPaitnt.Enum;
using NewPaitnt.VectorModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NewPaitnt.Interfaces
{
    public class IDrawableDTO
    {
        [JsonProperty]
        public EFigure FigureType { get; set; }

        [JsonProperty]
        public string FigureName { get; set; }

        [JsonProperty]
        public List<Point2D> Points { get; set; }

        [JsonProperty]
        public string PenColor { get; set; }

        [JsonProperty]
        public float PenWidth { get; set; }

        [JsonProperty]
        public EDashStyle PenDashStyle { get; set; }

        [JsonProperty]
        public string BrushColor { get; set; }

        [JsonProperty]
        public bool IsSmoothed { get; set; }
    }
}
