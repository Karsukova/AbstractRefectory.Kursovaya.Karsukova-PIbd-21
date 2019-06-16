namespace DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminId = c.Int(nullable: false),
                        OrderListId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .ForeignKey("dbo.OrderLists", t => t.OrderListId, cascadeDelete: true)
                .Index(t => t.AdminId)
                .Index(t => t.OrderListId);
            
            CreateTable(
                "dbo.OrderLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderListName = c.String(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderListProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderListId = c.Int(nullable: false),
                        ProductName = c.String(),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderLists", t => t.OrderListId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderListId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FridgeProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FridgeId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fridges", t => t.FridgeId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.FridgeId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Fridges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FridgeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderListId", "dbo.OrderLists");
            DropForeignKey("dbo.OrderListProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.FridgeProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.FridgeProducts", "FridgeId", "dbo.Fridges");
            DropForeignKey("dbo.OrderListProducts", "OrderListId", "dbo.OrderLists");
            DropForeignKey("dbo.Orders", "AdminId", "dbo.Admins");
            DropIndex("dbo.FridgeProducts", new[] { "ProductId" });
            DropIndex("dbo.FridgeProducts", new[] { "FridgeId" });
            DropIndex("dbo.OrderListProducts", new[] { "ProductId" });
            DropIndex("dbo.OrderListProducts", new[] { "OrderListId" });
            DropIndex("dbo.Orders", new[] { "OrderListId" });
            DropIndex("dbo.Orders", new[] { "AdminId" });
            DropTable("dbo.Fridges");
            DropTable("dbo.FridgeProducts");
            DropTable("dbo.Products");
            DropTable("dbo.OrderListProducts");
            DropTable("dbo.OrderLists");
            DropTable("dbo.Orders");
            DropTable("dbo.Admins");
        }
    }
}
