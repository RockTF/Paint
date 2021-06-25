using Microsoft.EntityFrameworkCore;
using PaintServer.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.Entity
{
    public class BdContext : DbContext //  определяет контекст данных, используемый для взаимодействия с базой данных
    {
        public BdContext() : base("DbConnection") // имя будущей строки подключения к базе данных.
        { 
        }

        public DbSet<User> Users { get; set; } //  представляет набор сущностей, хранящихся в базе данных
        public DbSet<Statistics> Statistics { get; set; } // через это свойство будет осуществляться связь с таблицами объектов в бд
    }
}
