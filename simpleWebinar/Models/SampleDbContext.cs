﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Models
{
    public class SampleDbContext : DbContext
    {
        //public DbSet<Sample> Samples { get; set; }

        public SampleDbContext()
        {
        }

        public SampleDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
