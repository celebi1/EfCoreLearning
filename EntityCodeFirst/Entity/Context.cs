﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace EntityCodeFirst.Entity
{
     class Context : DbContext
    {
        public DbSet<Urunler> Urunlers { get; set; }
    }
}
