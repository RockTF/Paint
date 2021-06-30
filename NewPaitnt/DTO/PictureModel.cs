using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class PictureModel
    {
        public int Id { get; set; }

        [ForeignKey("personModel")]
        public int PersonId { get; set; }
        public string PictureName { get; set; }
        public string Picture { get; set; }
        public DateTime CreationDate { get; set; }
        public EPictureTypes PictureType { get; set; }
        public PersonModel personModel { get; set; }
    }
}
