using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProblemaRealOrgArchivos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            // Crear un nuevo contacto con los datos ingresados en el formulario
            Contacto nuevoContacto = new Contacto
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text
            };

            // Agregar el contacto según la organización de archivos seleccionada
            if (rbSecuencial.Checked)
            {
                ArchivoSecuencial.AgregarContacto(nuevoContacto);
            }
            else if (rbSecuencialIndexado.Checked)
            {
                ArchivoSecuencialIndexado.AgregarContacto(nuevoContacto);
            }
            else if (rbAccesoDirecto.Checked)
            {
                ArchivoAccesoDirecto.AgregarContacto(nuevoContacto);
            }

            LimpiarCampos();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            int id = int.Parse(txtBuscarId.Text);
            Contacto contactoEncontrado = null;

            // Buscar el contacto según la organización de archivos seleccionada
            if (rbSecuencial.Checked)
            {
                contactoEncontrado = ArchivoSecuencial.BuscarContacto(id);
            }
            else if (rbSecuencialIndexado.Checked)
            {
                contactoEncontrado = ArchivoSecuencialIndexado.BuscarContacto(id);
            }
            else if (rbAccesoDirecto.Checked)
            {
                contactoEncontrado = ArchivoAccesoDirecto.BuscarContacto(id);
            }

            if (contactoEncontrado != null)
            {
                MostrarContacto(contactoEncontrado);
            }
            else
            {
                MessageBox.Show("Contacto no encontrado.");
                LimpiarCampos();
            }
        }
        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtBuscarId.Clear();
        }

        private void MostrarContacto(Contacto contacto)
        {
            txtId.Text = contacto.Id.ToString();
            txtNombre.Text = contacto.Nombre;
            txtEmail.Text = contacto.Email;
            txtTelefono.Text = contacto.Telefono;
        }
    }
}

