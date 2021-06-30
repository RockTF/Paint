using System.ComponentModel.DataAnnotations.Schema;

namespace DTO

{
    public class StatisticsModel
    {
        public int Id { get; set; }

        [ForeignKey("personModel")]
        public int PersonId { get; set; }
        public int Curve { get; set; }
        public int Dot { get; set; }
        public int Ellipse { get; set; }
        public int Line { get; set; }
        public int Triangle { get; set; }
        public int Polygon { get; set; }
        public int Rectangle { get; set; }
        public int SmoothCurve { get; set; }
        public int RoundedRectangle { get; set; }
         public PersonModel personModel { get; set; }
    }
}
