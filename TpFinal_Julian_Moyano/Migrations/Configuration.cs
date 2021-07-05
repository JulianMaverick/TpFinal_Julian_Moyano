namespace TpFinal_Julian_Moyano.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TpFinal_Julian_Moyano.Modelos;

    internal sealed class Configuration : DbMigrationsConfiguration<TpFinal_Julian_Moyano.Modelos.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TpFinal_Julian_Moyano.Modelos.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            Usuario usu = new Usuario();

            usu.Id = 1;
            usu.NombreUsuario = "Admin";
            usu.Contraseña = "Admin";
            usu.Admin = true;

            context.Usuarios.Add(usu);

            base.Seed(context);
        }
    }
}
