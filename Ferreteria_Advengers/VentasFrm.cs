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
    public partial class Ventasfrm : Form
    {
        int id_ventas = 0;
        public Ventasfrm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            bool resultado = Venta.eliminar(id);
            if (resultado)
            {
                MessageBox.Show("Eliminado Corerectamente");
            }
            dataGridView1.DataSource = Venta.Obtener();
            limpiar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numero_comprobante = txtnum_comp.Text;
            string tipo_comprobante = txttipo_comp.Text;
            string tipo_pago = txttipo_pago.Text;
            string fecha_venta = txtfecha_venta.MaxDate.ToString();
            string total = txttotal.Text;
            string tipo_venta = txttipo_venta.Text;
            string estado = txtestado.Text;
            bool resultado = false;
            if (id_ventas == 0)
            {
                resultado = Venta.Guardar(numero_comprobante, tipo_comprobante, tipo_pago, fecha_venta, total,
                    tipo_venta, estado);
                {

                }
            }
        }
        private void Ventasfrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Venta.Obtener();
            if (dataGridView1.Columns.Count > 0 )
            {
                dataGridView1.Columns["id_venta"].Visible = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtestado.Text = dataGridView1.CurrentRow.Cells["estado"].Value.ToString();
            txtnum_comp.Text = dataGridView1.CurrentRow.Cells["numero_comprobante"].Value.ToString();
            txttipo_comp.Text = dataGridView1.CurrentRow.Cells["tipo_comprobante"].Value.ToString();
            txttipo_pago.Text = dataGridView1.CurrentRow.Cells["tipo_pago"].Value.ToString();
            txttipo_venta.Text = dataGridView1.CurrentRow.Cells["tipo_venta"].Value.ToString();
            txttotal.Text = dataGridView1.CurrentRow.Cells["total"].Value.ToString();
            txtfecha_venta.Text = dataGridView1.CurrentRow.Cells["fecha_venta"].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void limpiar()
        {
            txtestado.Clear();
            txtnum_comp.Clear();
            txttipo_comp.Clear();
            txttipo_pago.Clear();
            txttipo_venta.Clear();
            txttotal.Clear();
            txtestado.Focus();
        }
    }
}
