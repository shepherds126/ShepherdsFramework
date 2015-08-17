namespace ShepherdsFramework.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
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
                        Avtar = c.String(maxLength: 100,defaultValue:""),
                        Email = c.String(maxLength: 50,defaultValue:""),
                        Phone = c.String(maxLength: 11,defaultValue:""),
                        IsDelete = c.Boolean(nullable: false,defaultValue:false),
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
