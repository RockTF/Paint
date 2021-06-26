using System;

namespace DTO
{
    public class Logs
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastVisitDate { get; set; }
    }
}
