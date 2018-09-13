using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoursApi.Models
{
    public class HourContext : DbContext
    {
        public DbSet<HourItem> HourItems { get; set; }

        public HourContext(DbContextOptions<HourContext> options) : base(options)
        {

        }
    }
}
