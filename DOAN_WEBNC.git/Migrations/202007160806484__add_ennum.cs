namespace DOAN_WEBNC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _add_ennum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChiTietDiems", "IDLoaiDiem", "dbo.LoaiDiems");
            DropIndex("dbo.ChiTietDiems", new[] { "IDLoaiDiem" });
            DropPrimaryKey("dbo.ChiTietDiems");
            AddColumn("dbo.ChiTietDiems", "LoaiDiem", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ChiTietDiems", new[] { "MaBangDiem", "LoaiDiem", "LanThi" });
            DropColumn("dbo.ChiTietDiems", "IDLoaiDiem");
            DropTable("dbo.LoaiDiems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LoaiDiems",
                c => new
                    {
                        IDLoaiDiem = c.Int(nullable: false, identity: true),
                        TenLoai = c.String(),
                    })
                .PrimaryKey(t => t.IDLoaiDiem);
            
            AddColumn("dbo.ChiTietDiems", "IDLoaiDiem", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.ChiTietDiems");
            DropColumn("dbo.ChiTietDiems", "LoaiDiem");
            AddPrimaryKey("dbo.ChiTietDiems", new[] { "MaBangDiem", "IDLoaiDiem", "LanThi" });
            CreateIndex("dbo.ChiTietDiems", "IDLoaiDiem");
            AddForeignKey("dbo.ChiTietDiems", "IDLoaiDiem", "dbo.LoaiDiems", "IDLoaiDiem", cascadeDelete: true);
        }
    }
}
