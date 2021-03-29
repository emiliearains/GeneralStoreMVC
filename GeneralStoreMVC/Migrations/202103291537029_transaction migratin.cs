namespace GeneralStoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactionmigratin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        DateofTransaction = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Transactions", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "ProductID" });
            DropIndex("dbo.Transactions", new[] { "CustomerID" });
            DropTable("dbo.Transactions");
        }
    }
}
