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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {   

            RepositorioUsuarios repositorio = new RepositorioUsuarios();
            string usuarioNombre = TxtUsuario.Text;
            string contraseña = TxtContraseña.Text;
            bool acceso = false;
            Usuario usuario = null;
            List<Usuario> Listausuarios = repositorio.ListarUsuarios().ToList();

            foreach (var item in Listausuarios)
            {
                if (item.NombreUsuario.Equals (usuarioNombre ) && item.Contraseña.Equals(contraseña))
                {
                    acceso = true;
                    usuario = item;

                }

            }

            if (acceso)
            {
                FrmPrincipal form = new FrmPrincipal(usuario);
                form.Show();
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta", "Error con credenciales", MessageBoxButtons.OK);
            }
        }   

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show($"¿Estas seguro que desea salir?", "Eliminar", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
