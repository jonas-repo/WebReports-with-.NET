namespace ReportesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lat_and_long_todecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Fallas", "Latitud", c => c.Decimal(nullable: false, precision: 12, scale: 12));
            AlterColumn("dbo.Fallas", "Longitud", c => c.Decimal(nullable: false, precision: 12, scale: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Fallas", "Longitud", c => c.String());
            AlterColumn("dbo.Fallas", "Latitud", c => c.String());
        }
    }
}
