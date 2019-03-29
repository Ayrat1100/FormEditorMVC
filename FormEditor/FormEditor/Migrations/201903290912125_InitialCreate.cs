// <copyright file="201903290912125_InitialCreate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Blocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Header = c.String(nullable: false),
                        TextField = c.String(),
                        Mandatory = c.Boolean(nullable: false),
                        FormId = c.Int(nullable: false),
                        FieldsType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Forms", t => t.FormId, cascadeDelete: true)
                .Index(t => t.FormId);

            this.CreateTable(
                "dbo.Forms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Guid = c.String(),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            this.DropForeignKey("dbo.Blocks", "FormId", "dbo.Forms");
            this.DropIndex("dbo.Blocks", new[] { "FormId" });
            this.DropTable("dbo.Forms");
            this.DropTable("dbo.Blocks");
        }
    }
}
