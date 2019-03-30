// <copyright file="201903291911409_NewColumnInFilledFormtble.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class NewColumnInFilledFormtble : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.CompletedForms", "DataCSV", c => c.String());
        }

        public override void Down()
        {
            this.DropColumn("dbo.CompletedForms", "DataCSV");
        }
    }
}
