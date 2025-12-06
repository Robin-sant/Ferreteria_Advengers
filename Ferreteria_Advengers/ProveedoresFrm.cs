using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ferreteria_Advengers.Models;

namespace Ferreteria_Advengers
{
    public partial class ProveedoresFrm : Form
    {
        int id_proveedor = 0;
        public ProveedoresFrm()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProveedoresFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Proveedore.Obtener();
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["Id_proveedor"].Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string razon_social = txtRazon.Text;
            string ruc = txtRuc.Text;
            string telefono = txtTelef.Text;
            string email = txtEmail.Text;
            string direccion = txtDireccion.Text;
            bool resultado = false;
            if (id_proveedor == 0)
            {
                resultado = Proveedore.Guardar(razon_social, ruc, telefono, email, direccion);
            }
            else
            {
                resultado = Proveedore.Editar(id_proveedor, razon_social, ruc, telefono, email, direccion);
            }
            if (resultado)
            {
                MessageBox.Show("Proveedor guardado correctamente.");
                dataGridView1.DataSource = Proveedore.Obtener();
            }
            dataGridView1.DataSource = Proveedore.Obtener();
            limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtRazon.Text = dataGridView1.CurrentRow.Cells["razon_social"].Value.ToString();
            txtRuc.Text = dataGridView1.CurrentRow.Cells["ruc"].Value.ToString();
            txtTelef.Text = dataGridView1.CurrentRow.Cells["telefono"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
            txtDireccion.Text = dataGridView1.CurrentRow.Cells["direccion"].Value.ToString();
            id_proveedor = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_proveedor"].Value);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id_proveedor = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_proveedor"].Value.ToString());
            bool resultado = Proveedore.Eliminar(id_proveedor);
            if (id_proveedor != 0)
            {
                Proveedore.Eliminar(id_proveedor);
            }
            dataGridView1.DataSource = Proveedore.Obtener();
            limpiar();
        }
        private void limpiar()
        {
            txtRazon.Clear();
            txtRuc.Clear();
            txtTelef.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtRazon.Focus();
        }
    }
}
