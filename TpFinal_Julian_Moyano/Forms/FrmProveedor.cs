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
    public partial class FrmProveedor : Form
    {
        public FrmProveedor()
        {
            InitializeComponent();
            CbIVA.Items.Add("SRL");
            CbIVA.Items.Add("SA");
            CbIVA.Items.Add("Consumidor Final");

        }

        public void SeleccionarProveedor()
        {
            RepositorioProveedores repositorio = new RepositorioProveedores();

            int id = int.Parse(DgvProveedores.SelectedRows[0].Cells[0].Value.ToString());

            Proveedor proveedorSeleccionado = repositorio.BuscarProveedorPorId(id);

            TxtNombre.Text = proveedorSeleccionado.Nombre;
            TxtUsuario.Text = proveedorSeleccionado.Usuario.NombreUsuario;
            TxtContraseña.Text = proveedorSeleccionado.Usuario.Contraseña;
            ChbEstado.Checked = proveedorSeleccionado.Estado;
            CbIVA.Text = proveedorSeleccionado.CondicionIva;
            DtpFechaNac.Value = proveedorSeleccionado.FechaNacimiento;

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            RepositorioProveedores repositorioProveedores = new RepositorioProveedores();
            DgvProveedores.DataSource = repositorioProveedores.ListarProveedors().ToList();
        }



        private void DtpFechaNac_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarProveedor();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show($"¿Estas seguro que desea salir?", "Eliminar", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                Close();
            }
        }

        private void BtnEliminar_Click_1(object sender, EventArgs e)
        {
            RepositorioProveedores repositorioClientes = new RepositorioProveedores();
            int id = int.Parse(DgvProveedores.SelectedRows[0].Cells[0].Value.ToString());

            Proveedor proveedorSeleccionado = repositorioClientes.BuscarProveedorPorId(id);

            DialogResult resultado = MessageBox.Show($"¿Seguro que quieres eliminar a {proveedorSeleccionado.Nombre}?", "Eliminar", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                repositorioClientes.EliminarProveedor(proveedorSeleccionado);

                Cargar();
            }
        }

        private void BtnAgregar_Click_1(object sender, EventArgs e)
        {
            RepositorioProveedores repositorioProveedores = new RepositorioProveedores();
            Proveedor proveedor = new Proveedor();
            Usuario usuario = new Usuario();

            proveedor.Nombre = TxtNombre.Text;
            proveedor.FechaNacimiento = DtpFechaNac.Value;
            proveedor.CondicionIva = CbIVA.Text;
            proveedor.Estado = ChbEstado.Checked;

            usuario.NombreUsuario = TxtUsuario.Text;
            usuario.Contraseña = TxtContraseña.Text;
            usuario.Admin = false;

            proveedor.Usuario = usuario;

            repositorioProveedores.AgregarProveedor(proveedor);
            Cargar();
        }

        private void BtnModificar_Click_1(object sender, EventArgs e)
        {
            RepositorioProveedores repositorioProveedores = new RepositorioProveedores();
            int id = 0;
            try
            {
                id = int.Parse(DgvProveedores.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch (Exception)
            {

                throw;
            }

            if (id != 0)
            {

                Proveedor proveedor = repositorioProveedores.BuscarProveedorPorId(id);
                Usuario usuario = proveedor.Usuario;

                proveedor.Nombre = TxtNombre.Text;
                proveedor.FechaNacimiento = DtpFechaNac.Value;
                proveedor.CondicionIva = CbIVA.Text;
                proveedor.Estado = ChbEstado.Checked;

                usuario.NombreUsuario = TxtUsuario.Text;
                usuario.Contraseña = TxtContraseña.Text;
                usuario.Admin = false;

                proveedor.Usuario = usuario;

                repositorioProveedores.ModificarProveedor(proveedor);

                Cargar();

            }
        }
    }
}
