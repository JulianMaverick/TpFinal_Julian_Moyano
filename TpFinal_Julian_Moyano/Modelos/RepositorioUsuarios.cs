using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinal_Julian_Moyano.Modelos
{    
    public class RepositorioUsuarios
    {
        private Context context = new Context();
        public DbSet<Usuario> ListarUsuarios()
        {
            DbSet<Usuario> listaUsuarios = context.Usuarios;

            return listaUsuarios;
        }

        
    }
}
