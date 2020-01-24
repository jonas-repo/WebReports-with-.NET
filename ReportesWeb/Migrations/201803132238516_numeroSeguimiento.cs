namespace ReportesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class numeroSeguimiento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fallas", "Numero_Seguimiento", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fallas", "Numero_Seguimiento");
        }
    }
}
