using System;
using System.Collections.Generic;

namespace DTO
{
    public class PictureDTO
    {
        public int UserId { get; set; }
        public string PictureName { get; set; }
        public string PictureContent { get; set; }
        public int PictureSize { get; set; }
        public DateTime CreationDate { get; set; }
        public EPictureTypes PictureType { get; set; }
        public List<KeyValuePair<string, int>> Dictionary { get; set; }

        public PictureDTO()
        {
            Dictionary = new List<KeyValuePair<string, int>>();
            Dictionary.Add(new KeyValuePair<string, int>("Curve", 0));
            Dictionary.Add(new KeyValuePair<string, int>("Dot", 0));
            Dictionary.Add(new KeyValuePair<string, int>("Ellipse", 0));
            Dictionary.Add(new KeyValuePair<string, int>("Line", 0));
            Dictionary.Add(new KeyValuePair<string, int>("Triangle", 0));
            Dictionary.Add(new KeyValuePair<string, int>("Polygon", 0));
            Dictionary.Add(new KeyValuePair<string, int>("Rectangle", 0));
            Dictionary.Add(new KeyValuePair<string, int>("SmoothCurve", 0));
            Dictionary.Add(new KeyValuePair<string, int>("RoundedRectangle", 0));

            CreationDate = DateTime.Now;
        }

        public void FillFigures(Dictionary<string, int> values)
        {
            for (int i = 0; i < Dictionary.Count; i++)
            {
                var asd = values.GetValueOrDefault(Dictionary[i].Key);
                Dictionary[i] = new KeyValuePair<string, int> (Dictionary[i].Key, Dictionary[i].Value + asd);
            }
        }

        public void FillFiguresasdf()
        {
            var asdf = new List<string>();
            for (int i = 0; i < Dictionary.Count; i++)
            {
                if (Dictionary[i].Value >= 5) asdf.Add(Dictionary[i].Key);
            }
        }
    }
}
