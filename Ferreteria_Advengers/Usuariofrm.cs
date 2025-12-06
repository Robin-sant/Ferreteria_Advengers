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
    public partial class Usuariofrm : Form
    {
        int id_usuario = 0;
        public Usuariofrm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre_usuario = txtnom_usu.Text;
            string password = txtpassword.Text;
            string nombre_completo = txtnom_comp.Text;
            string rol = txtrol.Text;
            string estado = txtestado.Text;
            string fecha = txtTime.Value.ToString("yyyy-MM-dd");
            bool resultado = false;
            if (id_usuario == 0)
            {
                resultado = Usuario.Guardar(nombre_usuario, password, nombre_completo, rol, estado, fecha);
                MessageBox.Show("Usuario Guardado Correctamente");
            }
            else
            {
                resultado = Usuario.Editar(id_usuario, nombre_usuario, password, nombre_completo, rol, estado, fecha);
                MessageBox.Show("Usuario Editada Correctamente");
            }
            dataGridView1.DataSource = Usuario.Obtener();
            limpiar();
        }

        private void Usuariofrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Usuario.Obtener();
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns[id_usuario].Visible = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtnom_usu.Text = dataGridView1.CurrentRow.Cells["nombre_usuario"].Value.ToString();
            txtpassword.Text = dataGridView1.CurrentRow.Cells["password"].Value.ToString();
            txtnom_comp.Text = dataGridView1.CurrentRow.Cells["nombre_completo"].Value.ToString();
            txtrol.Text = dataGridView1.CurrentRow.Cells["rol"].Value.ToString();
            txtestado.Text = dataGridView1.CurrentRow.Cells["estado"].Value.ToString();
            txtTime.Text = dataGridView1.CurrentRow.Cells["fecha"].Value.ToString();
            id_usuario = Convert.ToInt32(dataGridView1.CurrentRow.Cells ["id"].Value);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells ["id"].Value.ToString());
            if (id != 0)
            {
                Usuario.Eliminar(id);
            }
            dataGridView1.DataSource = Usuario.Obtener();
            limpiar();
        }
        private void limpiar()
        {
            txtnom_usu.Clear();
            txtpassword.Clear();
            txtnom_comp.Clear();
            txtrol.Clear();
            txtestado.Clear();
            txtnom_usu.Focus();
        }
    }
}
