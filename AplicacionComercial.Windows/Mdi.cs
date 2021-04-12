using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionComercial.Windows
{
    public partial class Mdi : Form
    {
        public Mdi()
        {
            InitializeComponent();
        }

        private void toolStripMenuAlmacenes_Click(object sender, EventArgs e)
        {
            frmAlmacen frm = new frmAlmacen();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
