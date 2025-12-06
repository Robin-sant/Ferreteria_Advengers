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
    public partial class ProductosFrm : Form
    {
        int Producto_id = 0;
        public ProductosFrm()
        {
            InitializeComponent();
        }

        private void ProductosFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Producto.Obtener();
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["id_producto"].Visible = false;

            }
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = dataGridView1.CurrentRow.Cells["codigo_barra"].Value.ToString();
            txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
            txtDescrip.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
            txtColor.Text = dataGridView1.CurrentRow.Cells["color"].Value.ToString();
            txtUnidad.Text = dataGridView1.CurrentRow.Cells["unidad_medida"].Value.ToString();
            txtStock_Actual.Text = dataGridView1.CurrentRow.Cells["stock_actual"].Value.ToString();
            txtStock_Mini.Text = dataGridView1.CurrentRow.Cells["stock_minimo"].Value.ToString();
            txtCosto.Text = dataGridView1.CurrentRow.Cells["costo_actual"].Value.ToString();
            txtPrecio_Mini.Text = dataGridView1.CurrentRow.Cells["precio_minorista"].Value.ToString();
            txtPrecio_Mayo.Text = dataGridView1.CurrentRow.Cells["precio_mayorista"].Value.ToString();
            Producto_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            bool resultado = Producto.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Producto eliminado correctamente.");
            }
            dataGridView1.DataSource = Producto.Obtener();
            limpiar();

        }
        private void limpiar()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescrip.Clear();
            txtColor.Clear();
            txtUnidad.Clear();
            txtStock_Actual.Clear();
            txtStock_Mini.Clear();
            txtCosto.Clear();
            txtPrecio_Mini.Clear();
            txtPrecio_Mayo.Clear();
            txtCodigo.Focus();
        }

        private void Guardarbtn_Click(object sender, EventArgs e)
        {
            int codigo_barra = Convert.ToInt32(txtCodigo.Text);
            string nombre = txtNombre.Text;
            string descripcion = txtDescrip.Text;
            string color = txtColor.Text;
            string unidad_medida = txtUnidad.Text;
            int stock_actual = Convert.ToInt32(txtStock_Actual.Text);
            int stock_minimo = Convert.ToInt32(txtStock_Mini.Text);
            decimal costo_actual = Convert.ToDecimal(txtCosto.Text);
            decimal precio_minorista = Convert.ToDecimal(txtPrecio_Mini.Text);
            decimal precio_mayorista = Convert.ToDecimal(txtPrecio_Mayo.Text);
            bool resultado=false;
            if (Producto_id == 0)
            {
                resultado = Producto.Guardar(codigo_barra, nombre, descripcion, color, unidad_medida, stock_actual, stock_minimo,
                costo_actual, precio_minorista, precio_mayorista);
                if (resultado)
                {
                    MessageBox.Show("Producto guardado correctamente.");
                }
            }
            else
            {
                resultado = Producto.Editar(Producto_id, codigo_barra, nombre, descripcion, color, unidad_medida, stock_actual, stock_minimo,
                costo_actual, precio_minorista, precio_mayorista);
                if (resultado)
                {
                    MessageBox.Show("Producto actualizado correctamente.");
                }
            }
        }
    }
}
