namespace ShepherdsFramework.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 10),
                        Password = c.String(),
                        Avtar = c.String(maxLength: 100),
                        Email = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 11),
                        Actived = c.Boolean(nullable: false),
                        Baned = c.Boolean(nullable: false),
                        PasswordFormat = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customer");
        }
    }
}
