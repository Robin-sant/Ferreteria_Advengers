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
    public partial class Detalle_compraFrm : Form
    {
        int id_detalle_compra = 0;
        public Detalle_compraFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt32(TxtCantidad.Text);
            decimal costo_unitario = Convert.ToDecimal(TxtCu.Text);
            decimal total = Convert.ToDecimal(TxtTotal.Text);
            bool resultado = false;
            if (id_detalle_compra == 0)
            {
                resultado = Detalle_Compra.Guardar(cantidad, costo_unitario, total);
                MessageBox.Show("Guardado Correctamente");   
            }
            else
            {
                resultado = Detalle_Compra.Editar(id_detalle_compra, cantidad, costo_unitario, total);
                MessageBox.Show("Editada Correctamente");
            }
            dataGridView1.DataSource = Detalle_Compra.Obtener();
            limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            bool resultado = Detalle_Compra.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Eliminado Correctamente");
            }
            dataGridView1.DataSource = Detalle_Compra.Obtener();
            limpiar();
        }

        private void Detalle_compraFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Detalle_Compra.Obtener();
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["id_detalle_compra"].Selected = false;
            }
            
        }

        private void TxtEditar_Click(object sender, EventArgs e)
        {
            TxtCantidad.Text = dataGridView1.CurrentRow.Cells["cantidad"].Value.ToString();
            TxtCu.Text = dataGridView1.CurrentRow.Cells["costo_unitario"].Value.ToString();
            TxtTotal.Text = dataGridView1.CurrentRow.Cells["total"].Value.ToString();
            id_detalle_compra = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
        }
        private void limpiar()
        {
            TxtCantidad.Clear();
            TxtCu.Clear();
            TxtTotal.Clear();
            TxtCantidad.Focus();
        }
    }
}
