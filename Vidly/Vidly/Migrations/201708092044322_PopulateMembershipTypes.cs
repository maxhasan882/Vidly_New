namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("insert into MembershipTypes (Id,SignupFee,DurationInMonths,DiscountRate) values(1,0,0,0)");
            Sql("insert into MembershipTypes (Id,SignupFee,DurationInMonths,DiscountRate) values(2,10,1,5)");
            Sql("insert into MembershipTypes (Id,SignupFee,DurationInMonths,DiscountRate) values(3,90,3,15)");
            Sql("insert into MembershipTypes (Id,SignupFee,DurationInMonths,DiscountRate) values(4,300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
