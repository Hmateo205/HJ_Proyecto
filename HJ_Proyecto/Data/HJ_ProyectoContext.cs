using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HJ_Proyecto.Models;

namespace HJ_Proyecto.Data
{
    public class HJ_ProyectoContext : DbContext
    {
        public HJ_ProyectoContext (DbContextOptions<HJ_ProyectoContext> options)
            : base(options)
        {
        }

        public DbSet<HJ_Proyecto.Models.Ingresar> Ingresar { get; set; } = default!;
    }
}
