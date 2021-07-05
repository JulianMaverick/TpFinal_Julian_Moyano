namespace TpFinal_Julian_Moyano.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AGREGOPROVEEDORES : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proveedors",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proveedors", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Proveedors", new[] { "UsuarioId" });
            DropTable("dbo.Proveedors");
        }
    }
}
