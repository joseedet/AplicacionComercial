using AplicacionComercial.Web.Repository;

using System;
using System.Windows.Forms;

namespace AplicacionComercial.Windows
{
    public partial class frmAlmacen : Form
    {
        //private readonly BodegaRepository _bodegaRepository;
        public frmAlmacen(/*BodegaRepository bodegaRepository*/)
        {
            InitializeComponent();
            //_bodegaRepository = bodegaRepository;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAlmacen_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(txtDescripcion.Text==string.Empty)
            {

                errorProvider1.SetError(txtDescripcion, "Descripción no puede estar vacion");
            }
            errorProvider1.Clear();
        }
    }
}
