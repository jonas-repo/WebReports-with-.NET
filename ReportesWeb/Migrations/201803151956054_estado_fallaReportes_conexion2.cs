namespace ReportesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estado_fallaReportes_conexion2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fallas", "Estado", c => c.String());
            AddColumn("dbo.Reportes", "Id_fallaID", c => c.Guid(nullable: true));
            CreateIndex("dbo.Reportes", "Id_fallaID");
            AddForeignKey("dbo.Reportes", "Id_fallaID", "dbo.Fallas", "Id_fallaID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reportes", "Id_fallaID", "dbo.Fallas");
            DropIndex("dbo.Reportes", new[] { "Id_fallaID" });
            DropColumn("dbo.Reportes", "Id_fallaID");
            DropColumn("dbo.Fallas", "Estado");
        }
    }
}
