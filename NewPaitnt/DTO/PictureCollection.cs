using System;

namespace DTO
{
    public class PictureCollection
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PictureName { get; set; }
        public int Type { get; set; }
        public string Picture { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditTime { get; set; }
        public DateTime EditCount { get; set; }
    }
}
