namespace ReportesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fallas",
                c => new
                    {
                        Id_fallaID = c.Guid(nullable: false),
                        Latitud = c.String(),
                        Longitud = c.String(),
                        Url_imagen = c.String(),
                        Descripcion = c.String(),
                        Fecha_inicio_falla = c.DateTime(nullable: false),
                        Id_usuario = c.Guid(nullable: false),
                        Id_tipo_fallaID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id_fallaID)
                .ForeignKey("dbo.Tipo_falla", t => t.Id_tipo_fallaID, cascadeDelete: true)
                .Index(t => t.Id_tipo_fallaID);
            
            CreateTable(
                "dbo.Tipo_falla",
                c => new
                    {
                        Id_tipo_fallaID = c.Guid(nullable: false),
                        Nombre_falla = c.String(),
                        Descripcion_falla = c.String(),
                    })
                .PrimaryKey(t => t.Id_tipo_fallaID);
            
            CreateTable(
                "dbo.Reportes",
                c => new
                    {
                        Id_reporteID = c.Guid(nullable: false),
                        Fecha_inicio = c.DateTime(nullable: false),
                        Fecha_fin = c.DateTime(nullable: false),
                        Resumen = c.String(),
                    })
                .PrimaryKey(t => t.Id_reporteID);
            
            CreateTable(
                "dbo.Tipo_falla_reporte",
                c => new
                    {
                        Id_tipo_reporteID = c.Guid(nullable: false),
                        Id_tipo_fallaID = c.Guid(nullable: false),
                        Id_reporteID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id_tipo_reporteID)
                .ForeignKey("dbo.Reportes", t => t.Id_reporteID, cascadeDelete: true)
                .ForeignKey("dbo.Tipo_falla", t => t.Id_tipo_fallaID, cascadeDelete: true)
                .Index(t => t.Id_tipo_fallaID)
                .Index(t => t.Id_reporteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tipo_falla_reporte", "Id_tipo_fallaID", "dbo.Tipo_falla");
            DropForeignKey("dbo.Tipo_falla_reporte", "Id_reporteID", "dbo.Reportes");
            DropForeignKey("dbo.Fallas", "Id_tipo_fallaID", "dbo.Tipo_falla");
            DropIndex("dbo.Tipo_falla_reporte", new[] { "Id_reporteID" });
            DropIndex("dbo.Tipo_falla_reporte", new[] { "Id_tipo_fallaID" });
            DropIndex("dbo.Fallas", new[] { "Id_tipo_fallaID" });
            DropTable("dbo.Tipo_falla_reporte");
            DropTable("dbo.Reportes");
            DropTable("dbo.Tipo_falla");
            DropTable("dbo.Fallas");
        }
    }
}
