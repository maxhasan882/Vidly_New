namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populatecustommer : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Customers(Name,IsSubscribeToNewsLetter,MembershipTypeId) values('Hasan','True',4)");
            Sql("insert into Customers(Name,IsSubscribeToNewsLetter,MembershipTypeId) values('Sohan','false',3)");
            Sql("insert into Customers(Name,IsSubscribeToNewsLetter,MembershipTypeId) values('Gazi','True',2)");
            Sql("insert into Customers(Name,IsSubscribeToNewsLetter,MembershipTypeId) values('Shanto','false',1)");
            Sql("insert into Customers(Name,IsSubscribeToNewsLetter,MembershipTypeId) values('Fahim','True',4)");
        }
        
        public override void Down()
        {
        }
    }
}
