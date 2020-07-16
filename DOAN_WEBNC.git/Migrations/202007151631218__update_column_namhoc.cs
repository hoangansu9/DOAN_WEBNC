namespace DOAN_WEBNC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _update_column_namhoc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NamHocs", "TenNamHoc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NamHocs", "TenNamHoc");
        }
    }
}
