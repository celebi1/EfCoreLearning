﻿namespace CodeFirstProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMusteriSehirColumnInMusterisTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Musteris",
                c => new
                    {
                        MusteriId = c.Int(nullable: false, identity: true),
                        MusteriAd = c.String(),
                        MusteriSoyad = c.String(),
                        MusteriSehir = c.String(),
                    })
                .PrimaryKey(t => t.MusteriId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Musteris");
        }
    }
}
