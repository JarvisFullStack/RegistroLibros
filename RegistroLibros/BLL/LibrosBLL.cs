using RegistroLibros.DAL;
using RegistroLibros.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RegistroLibros.BLL
{
    class LibrosBLL
    {
        public static bool Guardar(Libro libro) {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if(contexto.Libro.Add(libro) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
               
                throw;
            }

            return paso;
        }

        public static bool Modificar(Libro libro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(libro).State = EntityState.Modified;
                if(contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Libro libro = contexto.Libro.Find(id);
                contexto.Libro.Remove(libro);
                if(contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static Libro Buscar(int id)
        {
            
            Contexto contexto = new Contexto();
            Libro libro = new Libro();
            try
            {
                libro = contexto.Libro.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return libro;
        }

        public static List<Libro> GetList(Expression<Func<Libro, bool>> expresion)
        {
            List<Libro> Libros = new List<Libro>();
            Contexto contexto = new Contexto();
            try
            {
                Libros = contexto.Libro.Where(expresion).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Libros;

        }
    }
}


    

