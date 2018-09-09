using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroLibros.Entidades
{
    class Libro
    {
        [Key]
        public int LibroId { get; set; }
        public string Descripcion { get; set; }

        public string Siglas { get; set; }

        public int TipoId { get; set; }

        public Libro()
        {
            this.LibroId = 0;
            this.Descripcion = String.Empty;
            this.Siglas = String.Empty;
            this.TipoId = 0;

        }
    }

   
}
