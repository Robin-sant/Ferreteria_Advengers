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
    public partial class InventarioFrm : Form
    {
        int id_inventario = 0;
        public InventarioFrm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        { 

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void InventarioFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Inventario.Obtener();
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns[id_inventario].Visible = false;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string tipo = TxtTipo.Text;
            decimal cantidad = Convert.ToDecimal(TxtCantidad.Text);
            string fecha = TxtFecha.Value.ToString("yyyy-MM-dd");
            string referencia =TxtReferencia.Text;
            bool resultado = false;
            if (id_inventario == 0)
            {
                resultado = Inventario.Guardar(tipo, cantidad, fecha, referencia);
                MessageBox.Show("Guardado Correctamente");

            }
            else
            {
                resultado = Inventario.Editar(id_inventario, tipo, cantidad, fecha, referencia);
                MessageBox.Show("Editada Correctamente");
            }
            dataGridView1.DataSource = Detalle_Compra.Obtener();
            limpiar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            TxtTipo.Text = dataGridView1.CurrentRow.Cells["tipo"].Value.ToString();
            TxtCantidad.Text = dataGridView1.CurrentRow.Cells["cantidad"].Value.ToString();
            TxtFecha.Text = dataGridView1.CurrentRow.Cells["fecha"].Value.ToString();
            TxtReferencia.Text = dataGridView1.CurrentRow.Cells["referencia"].Value.ToString();
            id_inventario = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            bool resultado = Inventario.Eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Eliminado Correctamente");
            }
            dataGridView1.DataSource = Inventario.Obtener();
            limpiar();
        }
        private void limpiar()
        {
            TxtTipo.Clear();
            TxtCantidad.Clear();
            TxtReferencia.Clear();
            TxtTipo.Focus();
        }

    }
}
