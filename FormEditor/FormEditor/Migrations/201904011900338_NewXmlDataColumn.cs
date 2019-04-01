// <copyright file="201904011900338_NewXmlDataColumn.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class NewXmlDataColumn : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.FilledForms", "DataCSVFormat", c => c.String());
            this.AddColumn("dbo.FilledForms", "DataXmlFormat", c => c.String());
            this.DropColumn("dbo.FilledForms", "DataCSV");
        }

        public override void Down()
        {
            this.AddColumn("dbo.FilledForms", "DataCSV", c => c.String());
            this.DropColumn("dbo.FilledForms", "DataXmlFormat");
            this.DropColumn("dbo.FilledForms", "DataCSVFormat");
        }
    }
}
