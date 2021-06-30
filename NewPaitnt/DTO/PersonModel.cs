using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class PersonModel
    {
        public PersonModel()
        {
            pictureModel = new List<PictureModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastVisitDate { get; set; }
        public ICollection<PictureModel> pictureModel { get; set; }
        public StatisticsModel statisticModel { get; set; }
    }
}
