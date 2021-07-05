using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpFinal_Julian_Moyano.Modelos;

namespace TpFinal_Julian_Moyano.Forms
{
    public partial class FrmPrincipal : Form
    {
        public string nombre;
        public FrmPrincipal(Usuario usuario)
        {
            InitializeComponent();
            

            LblBienvenido.Text = "Bienvenido " + usuario.NombreUsuario;

        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            FrmClientes form = new FrmClientes();
            form.Show();
        }

        private void BtnProveedor_Click(object sender, EventArgs e)
        {
            FrmProveedor form = new FrmProveedor();
            form.Show();
        }
    }
}
