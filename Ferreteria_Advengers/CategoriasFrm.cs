using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Ferreteria_Advengers.Models;

namespace Ferreteria_Advengers
{
    public partial class CategoriasFrm : Form
    {
        int Id_categoria = 0;
        public CategoriasFrm()
        {
            InitializeComponent();
        }

        private void CategoriasFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Categoria.Obtener();
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["Id_categoria"].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            bool resultado = false;
            if (Id_categoria == 0)
            {
                resultado = Categoria.Guardar(nombre);
                MessageBox.Show("Categoría guardada correctamente.");
            }
            else
            {
                resultado = Categoria.Editar(Id_categoria, nombre);
                MessageBox.Show("Categoría Editada correctamente.");
            }
            dataGridView1.DataSource = Categoria.Obtener();
            limpiar();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
            Id_categoria = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_categoria"].Value.ToString());
            txtNombre.Focus();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id_categoria"].Value.ToString());
            if (Id != 0)
            {
                Categoria.Eliminar(Id);
            }
            dataGridView1.DataSource = Categoria.Obtener();
            limpiar();
            MessageBox.Show("Categoría eliminada correctamente.");

        }
        private void limpiar()
        {
            txtNombre.Clear();
            txtNombre.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
