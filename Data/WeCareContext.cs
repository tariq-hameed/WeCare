using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeCare.Data.Entities;

namespace WeCare.Data
{
    public class WeCareContext :DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public WeCareContext(DbContextOptions<WeCareContext> options) : base (options)
        {

        }
    }
}
