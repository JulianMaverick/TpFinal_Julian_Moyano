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
            RepositorioClientes repoCli = new RepositorioClientes();
            RepositorioProveedores repoProv = new RepositorioProveedores();

            bool esCliente = false;
            Cliente cli = null;
            Proveedor prov = null;
            bool esProveedor = false;

            foreach (var item in repoCli.ListarClientes().ToList())
            {
                if (item.UsuarioId == usuario.Id)
                {
                    esCliente = true;
                    cli = item;
                }
            }

            foreach (var item in repoProv.ListarProveedors().ToList())
            {
                if (item.UsuarioId == usuario.Id)
                {
                    esProveedor = true;
                    prov = item;
                }
            }

            if (esCliente)
            {
                nombre = cli.Nombre;
            }

            if (esProveedor)
            {
                nombre = prov.Nombre;
            }

            LblBienvenido.Text = "Bienvenido " + nombre;

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
