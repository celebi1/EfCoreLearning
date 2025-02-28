namespace CodeFirstProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameMusteriSoyadToMusteriUnvanInMusterisTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Musteris", "MusteriUnvan", c => c.String());
            DropColumn("dbo.Musteris", "MusteriSoyad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Musteris", "MusteriSoyad", c => c.String()); //fdwsf
            DropColumn("dbo.Musteris", "MusteriUnvan");
        }
    }
}
