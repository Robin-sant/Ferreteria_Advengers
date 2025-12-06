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
    public partial class Cuentas_CobrarFrm : Form
    {
        int Id_cxc = 0;
        public Cuentas_CobrarFrm()
        {
            InitializeComponent();
        }

        private void Cuentas_CobrarFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Cuenta_Cobrar.Obtener();
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["id_cxc"].Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string fecha_vencimiento = txtTime.Value.ToString("yyyy-MM-dd");
            decimal monto_total = Convert.ToInt32(txtMonto_Total.Text);
            decimal monto_pendiente = Convert.ToInt32(txtMonto_Pend.Text);
            string estado = txtEstado.Text;
            bool resultado = false;
            if (Id_cxc == 0)
            {
                resultado = Cuenta_Cobrar.Guardar(fecha_vencimiento, monto_total, monto_pendiente, estado);
                MessageBox.Show("Cuenta por cobrar guardada correctamente.");
            }
            else
            {
                resultado = Cuenta_Cobrar.Editar(Id_cxc, fecha_vencimiento, monto_total, monto_pendiente, estado);
                MessageBox.Show("Cuenta por cobrar Editada correctamente.");
            }
            dataGridView1.DataSource = Cuenta_Cobrar.Obtener();
            limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtTime.Text = dataGridView1.CurrentRow.Cells["fecha_vencimiento"].Value.ToString();
            txtMonto_Total.Text = dataGridView1.CurrentRow.Cells["monto_total"].Value.ToString();
            txtMonto_Pend.Text = dataGridView1.CurrentRow.Cells["monto_pendiente"].Value.ToString();
            txtEstado.Text = dataGridView1.CurrentRow.Cells["estado"].Value.ToString();
            Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id_cxc"].Value.ToString());
            if (Id != 0)
            {
                Cuenta_Cobrar.Eliminar(Id);
                dataGridView1.DataSource = Cuenta_Cobrar.Obtener();
            }
            limpiar();
        }
        private void limpiar()
        {
            txtTime.Value = DateTime.Now;
            txtMonto_Total.Clear();
            txtMonto_Pend.Clear();
            txtEstado.Clear();
            txtTime.Focus();
        }
    }
}
