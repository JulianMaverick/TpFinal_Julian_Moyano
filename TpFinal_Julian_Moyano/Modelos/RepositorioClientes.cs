using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinal_Julian_Moyano.Modelos
{
    public class RepositorioClientes
    {
        private Context context = new Context();
        public bool AgregarCliente (Cliente cliente)
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();
            return true;
        }

        public DbSet<Cliente> ListarClientes()
        {
            DbSet<Cliente> listaClientes = context.Clientes;

            return listaClientes;
        }
        public Cliente BuscarClientePorId(int id)
        {
            return context.Clientes.Find(id);
        }

        public bool ModificarCliente(Cliente cliente) {
            context.Entry(cliente).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }

        public void EliminarCliente(Cliente cliente) {
        
            context.Entry(cliente).State = EntityState.Deleted;
            context.SaveChangesAsync();



        }

    }
}
