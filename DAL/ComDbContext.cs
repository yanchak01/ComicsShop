using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ComDbContext:DbContext
    {
        public ComDbContext(DbContextOptions<ComDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }


    }
}
