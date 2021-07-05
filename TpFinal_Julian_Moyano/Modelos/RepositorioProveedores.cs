using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinal_Julian_Moyano.Modelos
{
    public class RepositorioProveedores
    {
        private Context context = new Context();
        public bool AgregarProveedor(Proveedor proveedor)
        {
            context.Proveedors.Add(proveedor);
            context.SaveChanges();
            return true;
        }

        public DbSet<Proveedor> ListarProveedors()
        {
            DbSet<Proveedor> listaProveedors = context.Proveedors;

            return listaProveedors;
        }
        public Proveedor BuscarProveedorPorId(int id)
        {
            return context.Proveedors.Find(id);
        }

        public bool ModificarProveedor(Proveedor proveedor)
        {
            context.Entry(proveedor).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }

        public void EliminarProveedor(Proveedor proveedor)
        {

            context.Entry(proveedor).State = EntityState.Deleted;
            context.SaveChangesAsync();



        }
    }
}
