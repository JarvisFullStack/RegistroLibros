using RegistroLibros.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroLibros.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Libro> Libro { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
