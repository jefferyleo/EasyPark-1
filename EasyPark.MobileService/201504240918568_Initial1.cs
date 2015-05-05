namespace EasyPark.MobileService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("EasyPark.Cars", "CarId");
            DropColumn("EasyPark.Users", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("EasyPark.Users", "UserId", c => c.Guid(nullable: false));
            AddColumn("EasyPark.Cars", "CarId", c => c.Guid(nullable: false));
        }
    }
}
