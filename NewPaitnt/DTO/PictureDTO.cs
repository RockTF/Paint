using System;
using System.Collections.Generic;

namespace DTO
{
    public class PictureDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PictureName { get; set; }
        public string PictureContent { get; set; }
        public DateTime CreationDate { get; set; }
        public EPictureTypes PictureType { get; set; }
        public List<KeyValuePair<string, int>> Dictionary { get; set; }

        public PictureDTO()
        {

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
