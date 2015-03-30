namespace ENETCare.Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DistributionCentres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.AspNetUsers", "Fullname", c => c.String());
            AddColumn("dbo.AspNetUsers", "DistributionCentre_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "DistributionCentre_ID");
            AddForeignKey("dbo.AspNetUsers", "DistributionCentre_ID", "dbo.DistributionCentres", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "DistributionCentre_ID", "dbo.DistributionCentres");
            DropIndex("dbo.AspNetUsers", new[] { "DistributionCentre_ID" });
            DropColumn("dbo.AspNetUsers", "DistributionCentre_ID");
            DropColumn("dbo.AspNetUsers", "Fullname");
            DropTable("dbo.DistributionCentres");
        }
    }
}
