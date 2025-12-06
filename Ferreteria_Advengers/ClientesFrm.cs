using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ferreteria_Advengers.Models;

namespace Ferreteria_Advengers
{
    public partial class ClientesFrm : Form
    {
        int id_cliente = 0;
        public ClientesFrm()
        {
            InitializeComponent();
        }

        private void ClientesFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Cliente.Obtener();
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["Id_cliente"].Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string documento = txtDocumento.Text;
            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            bool resultado = false;
            if (id_cliente == 0)
            {
                resultado = Cliente.Guardar(documento, nombre, telefono, direccion);
                MessageBox.Show("Cliente guardado correctamente.");
            }
            else
            {
                resultado = Cliente.Editar(id_cliente, documento, nombre, telefono, direccion);
                MessageBox.Show("Cliente Editado correctamente.");
            }
            dataGridView1.DataSource = Cliente.Obtener();
            limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtDocumento.Text = dataGridView1.CurrentRow.Cells["documento"].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
            txtDireccion.Text = dataGridView1.CurrentRow.Cells["direccion"].Value.ToString();
            txtTelefono.Text = dataGridView1.CurrentRow.Cells["telefono"].Value.ToString();
            Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_cliente"].Value.ToString());
            if (Id != 0)
            {
                Cliente.Eliminar(Id);
                dataGridView1.DataSource = Cliente.Obtener();
            }
            dataGridView1.DataSource = Cliente.Obtener();
            limpiar();  
        }
        private void limpiar()
        {
            txtDocumento.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtDocumento.Focus();
        }
    }
}
