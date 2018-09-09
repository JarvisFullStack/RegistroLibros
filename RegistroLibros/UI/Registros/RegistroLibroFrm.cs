using RegistroLibros.BLL;
using RegistroLibros.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroLibros.UI.Registros
{
    public partial class RegistroLibroFrm : Form
    {
        public object PersonasBLL { get; private set; }
        public object SuperErrorProvider { get; private set; }

        public RegistroLibroFrm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegistroLibroFrm_Load(object sender, EventArgs e)
        {

        }


        public void Limpiar()
        {
            nudID.Value = 0;
            tbDescripcion.Text = String.Empty;
            tbSiglas.Text = String.Empty;
            cbTipo.SelectedIndex = 0;

        }

        public bool Validar()
        {
            bool paso = false;
            if(tbDescripcion.Text != String.Empty || tbSiglas.Text != String.Empty)
            {
                paso = true;
            }
            return paso;
        }

        private Libro LlenarClase()
        {
            Libro libro = new Libro();
            libro.LibroId = Convert.ToInt32(nudID.Value);
            libro.Descripcion = tbDescripcion.Text;
            libro.Siglas = tbSiglas.Text;
            libro.TipoId = Convert.ToInt32(cbTipo.SelectedIndex);
            return libro;
        }

        private void LlenarCampos(Libro libro)
        {
            nudID.Value = libro.LibroId;
            tbDescripcion.Text = libro.Descripcion;
            tbSiglas.Text = libro.Siglas;
            cbTipo.SelectedIndex = libro.TipoId;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuargar_Click(object sender, EventArgs e)
        {
            Libro libro;
            bool paso = false;
            if (!Validar()) {
                MessageBox.Show("Debe llenar todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
                
            libro = LlenarClase();

            if(nudID.Value == 0)
            {
                paso = LibrosBLL.Guardar(libro);
                if(paso == true)
                {
                    MessageBox.Show("Libro Guardado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                }

            }
            else
            {              
                Libro l = LibrosBLL.Buscar(Convert.ToInt32(nudID.Value));
                if (l==null)
                {
                    MessageBox.Show("Este libro no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                paso = LibrosBLL.Modificar(l);
                if (paso == true)
                {
                    MessageBox.Show("Libro Modificado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Limpiar();
            if (!paso)
            {
                if (paso == true)
                {
                    MessageBox.Show("No se pudo guardar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id;
            Libro libro = new Libro();
            id = Convert.ToInt32(nudID.Value);
            libro = LibrosBLL.Buscar(id);
            if(libro != null)
            {
                MessageBox.Show("Libro Encontrada!");
                LlenarCampos(libro);
            }
            else
            {
                MessageBox.Show("Libro no Encontrado.");
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(nudID.Value);
            if (LibrosBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!");
            }
            else
            {
                MessageBox.Show("No se puede encontrar el registro con id: "+id);

            }
        }
    }
}
