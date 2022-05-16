using System;
using System.Windows.Forms;
using EntidadesSP;

namespace SP.LABII.WinFormsApp
{
    public partial class FrmProducto : Form
    {
        private EntidadesSP.Producto miProducto;

        public EntidadesSP.Producto MiProducto
        {
            get { return this.miProducto; }
        }

        public FrmProducto(Producto p)
        {
            InitializeComponent();
            this.miProducto = p;
        }


        /// Crar una instancia de tipo Producto
        /// Establecer, como valor de la propiedad, el atributo miProducto
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
