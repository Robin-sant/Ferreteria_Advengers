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
    public partial class Detalle_VentaFrm : Form
    {
        int id_detalle_venta = 0;
        public Detalle_VentaFrm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Detalle_VentaFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Detalle_venta.Obtener();
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns[id_detalle_venta].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal cantidad = Convert.ToInt32(TxtCantidad.Text);
            decimal precio_unitario = Convert.ToDecimal(TxtPu.Text);
            decimal descuento = Convert.ToDecimal(TxtDescuento.Text);
            decimal total = Convert.ToDecimal(TxtTotal.Text);
            bool resultado = false;
            if (id_detalle_venta == 0)
            {
                resultado = Detalle_venta.Guardar(cantidad, precio_unitario, descuento, total);
                MessageBox.Show("Guardado Correctamente");

            }
            else
            {
                resultado = Detalle_venta.Editar(id_detalle_venta,cantidad, precio_unitario, descuento, total);
                MessageBox.Show("Editada Correctamente");
            }
            dataGridView1.DataSource = Detalle_Compra.Obtener();
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TxtCantidad.Text = dataGridView1.CurrentRow.Cells["cantidad"].Value.ToString();
            TxtPu.Text = dataGridView1.CurrentRow.Cells["precio_unitario"].Value.ToString();
            TxtDescuento.Text = dataGridView1.CurrentRow.Cells["descuento"].Value.ToString();
            TxtTotal.Text = dataGridView1.CurrentRow.Cells["total"].Value.ToString();
            id_detalle_venta = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            bool resultado = Detalle_venta.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Eliminado Correctamente");
            }
            dataGridView1.DataSource = Detalle_venta.Obtener();
            limpiar();
        }
        private void limpiar()
        {
            TxtCantidad.Clear();
            TxtPu.Clear();
            TxtDescuento.Clear();
            TxtTotal.Clear();
            TxtCantidad.Focus();
        }
    }
}
