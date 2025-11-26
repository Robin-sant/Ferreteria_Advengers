using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria_Advengers
{
    public partial class FormularioPrincipalFrm : Form
    {
        public FormularioPrincipalFrm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ProductosFrm frm = new ProductosFrm(); 
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CategoriasFrm frm = new CategoriasFrm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ProductosFrm frm = new ProductosFrm();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
