// <copyright file="201903291906108_NewTableFillForms.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class NewTableFillForms : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.CompletedForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            this.DropTable("dbo.CompletedForms");
        }
    }
}
