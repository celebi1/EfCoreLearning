﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstProject.Entity
{
   public  class Kategori
    {
        [Key]

        public int KategoriID { get; set; }
        public string KategoriAd { get; set; }
        public ICollection <Urunler> Urunlers { get; set; }

    }
}
