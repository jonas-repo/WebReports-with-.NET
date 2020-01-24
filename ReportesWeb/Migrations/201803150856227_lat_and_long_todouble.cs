namespace ReportesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lat_and_long_todouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fallas", "Latitud", c => c.Double(nullable: false));
            AlterColumn("dbo.Fallas", "Longitud", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fallas", "Longitud", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Fallas", "Latitud", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
