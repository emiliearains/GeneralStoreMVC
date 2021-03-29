namespace GeneralStoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "DateofTransaction", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "DateofTransaction", c => c.DateTime(nullable: false));
        }
    }
}
