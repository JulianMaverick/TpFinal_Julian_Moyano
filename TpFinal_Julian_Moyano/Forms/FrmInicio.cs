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

namespace TpFinal_Julian_Moyano
{
    public partial class FrmClientes : Form
    {
        
        public FrmClientes()
        {
            InitializeComponent();
            CbIVA.Items.Add("SRL");
            CbIVA.Items.Add("SA");
            CbIVA.Items.Add("Consumidor Final");

        }

        public void SeleccionarCliente ()
        {
            RepositorioClientes repositorio = new RepositorioClientes();

            int id = int.Parse(DgvClientes.SelectedRows[0].Cells[0].Value.ToString());

            Cliente clienteSeleccionado = repositorio.BuscarClientePorId(id);

            TxtNombre.Text = clienteSeleccionado.Nombre;
            TxtUsuario.Text = clienteSeleccionado.Usuario.NombreUsuario;
            TxtContraseña.Text = clienteSeleccionado.Usuario.Contraseña;
            ChbEstado.Checked = clienteSeleccionado.Estado;
            CbIVA.Text = clienteSeleccionado.CondicionIva;
            DtpFechaNac.Value = clienteSeleccionado.FechaNacimiento;
           
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            RepositorioClientes repositorioClientes = new RepositorioClientes();
            int id = 0;
            try
            {
                id = int.Parse(DgvClientes.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch (Exception)
            { 

                throw;
            }

            if (id != 0) {

                Cliente cliente = repositorioClientes.BuscarClientePorId(id);
                Usuario usuario = cliente.Usuario;

                cliente.Nombre = TxtNombre.Text;
                cliente.FechaNacimiento = DtpFechaNac.Value;
                cliente.CondicionIva = CbIVA.Text;
                cliente.Estado = ChbEstado.Checked;

                usuario.NombreUsuario = TxtUsuario.Text;
                usuario.Contraseña = TxtContraseña.Text;
                usuario.Admin = false;

                cliente.Usuario = usuario;

                repositorioClientes.ModificarCliente(cliente);

                Cargar();
                    
             }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            RepositorioClientes repositorioClientes = new RepositorioClientes();
            Cliente cliente = new Cliente();
            Usuario usuario = new Usuario();

            cliente.Nombre = TxtNombre.Text;
            cliente.FechaNacimiento = DtpFechaNac.Value;
            cliente.CondicionIva = CbIVA.Text;
            cliente.Estado = ChbEstado.Checked;

            usuario.NombreUsuario = TxtUsuario.Text;
            usuario.Contraseña = TxtContraseña.Text;
            usuario.Admin = false;

            cliente.Usuario = usuario;

            repositorioClientes.AgregarCliente(cliente);
            Cargar();
        }

        private void Cargar()
        {
            RepositorioClientes repositorioClientes = new RepositorioClientes();
            DgvClientes.DataSource = repositorioClientes.ListarClientes().ToList();
        }



        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioClientes repositorioClientes = new RepositorioClientes();
            int id = int.Parse(DgvClientes.SelectedRows[0].Cells[0].Value.ToString());

            Cliente clienteSeleccionado = repositorioClientes.BuscarClientePorId(id);

            DialogResult resultado = MessageBox.Show($"¿Seguro que quieres eliminar a {clienteSeleccionado.Nombre}?", "Eliminar", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                repositorioClientes.EliminarCliente(clienteSeleccionado);

                Cargar();
            }                                                                   


        }

        private void DtpFechaNac_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarCliente ();
        }
    }
}
