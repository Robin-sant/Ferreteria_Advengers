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
    public partial class Marcafrm : Form
    {
        int id_marca = 0;
        public Marcafrm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            if (id != 0)
            {
                Marca.Eliminar(id);
            }
            dataGridView1.DataSource = Marca.Obtener();
            limpiar();
        }

        private void Marcafrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Marca.Obtener();
            if (dataGridView1.Columns.Count > 0 )
            {
                dataGridView1.Columns["id_marca"].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtnombre.Text;
            string fecha = txtTime.Value.ToString("yyyy-MM-dd");
            bool resultado = false;
            if (id_marca == 0)
            {
                resultado = Marca.Guardar(nombre, fecha);
                MessageBox.Show("Marca Guardado Correctamente");
            }
            else
            {
                resultado = Marca.Editar(id_marca, nombre, fecha);
                MessageBox.Show("Marca Editada Correctamente");
            }
            dataGridView1.DataSource = Usuario.Obtener();
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtnombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
            txtTime.Text = dataGridView1.CurrentRow.Cells["fecha"].Value.ToString();
            id_marca = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
        }
        private void limpiar()
        {
            txtnombre.Clear();
            txtnombre.Focus();
        }
    }
}
