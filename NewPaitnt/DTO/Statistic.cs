using System;
using System.Collections.Generic;

namespace DTO
{
    class Statistic
    {
        public int JsonCount { get; set; }
        public int BmpCount { get; set; }
        public int JpegCount { get; set; }
        public int GifCount { get; set; }
        public int PngCount { get; set; }
        public List<string> Names { get; set; }
        DateTime RegisterDate { get; set; }
        DateTime LastVisitDate { get; set; }
    }
}
