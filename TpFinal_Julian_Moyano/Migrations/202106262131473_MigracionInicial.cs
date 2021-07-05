namespace TpFinal_Julian_Moyano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 25),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        CondicionIva = c.String(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(nullable: false, maxLength: 25),
                        Contraseña = c.String(nullable: false, maxLength: 25),
                        Admin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Clientes", new[] { "UsuarioId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Clientes");
        }
    }
}
