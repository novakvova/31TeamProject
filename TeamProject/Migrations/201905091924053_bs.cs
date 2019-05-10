namespace TeamProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false, maxLength: 255),
                        GraduationYear = c.String(nullable: false, maxLength: 255),
                        VIN = c.String(nullable: false, maxLength: 255),
                        StateNumber = c.String(nullable: false, maxLength: 255),
                        BrokerId = c.Int(),
                        UserId = c.Int(),
                        Broker_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblBrokers", t => t.Broker_ID)
                .ForeignKey("dbo.tblBrokers", t => t.BrokerId)
                .ForeignKey("dbo.tblBrokers", t => t.UserId)
                .ForeignKey("dbo.tblUsers", t => t.UserId)
                .Index(t => t.BrokerId)
                .Index(t => t.UserId)
                .Index(t => t.Broker_ID);
            
            CreateTable(
                "dbo.tblBrokers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblCars", "UserId", "dbo.tblUsers");
            DropForeignKey("dbo.tblCars", "UserId", "dbo.tblBrokers");
            DropForeignKey("dbo.tblCars", "BrokerId", "dbo.tblBrokers");
            DropForeignKey("dbo.tblCars", "Broker_ID", "dbo.tblBrokers");
            DropIndex("dbo.tblCars", new[] { "Broker_ID" });
            DropIndex("dbo.tblCars", new[] { "UserId" });
            DropIndex("dbo.tblCars", new[] { "BrokerId" });
            DropTable("dbo.tblUsers");
            DropTable("dbo.tblBrokers");
            DropTable("dbo.tblCars");
        }
    }
}
