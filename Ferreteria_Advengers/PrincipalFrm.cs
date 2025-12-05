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
    public partial class PrincipalFrm : Form
    {
        public PrincipalFrm()
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
            ProveedoresFrm frm = new ProveedoresFrm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ComprasFrm frm = new ComprasFrm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Cuentas_CobrarFrm frm = new Cuentas_CobrarFrm();}
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Detalle_compraFrm frm = new Detalle_compraFrm();

            frm.MdiParent = this;
            frm.Show();
        }

        private void toolClientes_Click(object sender, EventArgs e)
        {
            ClientesFrm frm = new ClientesFrm();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
