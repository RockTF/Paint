using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ContextDAL : DbContext
    {
        public ContextDAL(DbContextOptions<ContextDAL> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<PersonModel> Persons { get; set; }

        public DbSet<PictureModel> Pictures { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        //}
    }
}
