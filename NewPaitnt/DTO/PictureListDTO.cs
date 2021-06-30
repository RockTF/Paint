using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO
{
    public class PictureListDTO
    {
        public List<string> PictureNames { get; set; }
        public List<int> PictureIds { get; set; }
        public PictureListDTO()
        {
            PictureNames = new List<string>();
            PictureIds = new List<int>();
        }
    }
}
