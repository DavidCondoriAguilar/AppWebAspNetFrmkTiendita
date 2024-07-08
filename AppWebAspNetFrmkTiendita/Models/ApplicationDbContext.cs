using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AplicacionTiendita.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base("DefaultConnection")
        {
        }


        public DbSet<T_Categoria> t_categoria { get; set; }
        public DbSet<T_Producto> t_producto { get; set; }
    }
}