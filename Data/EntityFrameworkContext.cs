using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Models;

namespace EntityFramework.Data
{
    public class EntityFrameworkContext : DbContext
    {
        public EntityFrameworkContext (DbContextOptions<EntityFrameworkContext> options)
            : base(options)
        {
        }

        public DbSet<EntityFramework.Models.movement> movement { get; set; }

        public DbSet<EntityFramework.Models.person> person { get; set; }

        public DbSet<EntityFramework.Models.account> account { get; set; }

        public DbSet<EntityFramework.Models.client> client { get; set; }
    }
}
