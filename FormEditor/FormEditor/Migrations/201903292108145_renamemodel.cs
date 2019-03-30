namespace FormEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Renamemodel : DbMigration
    {
        public override void Up()
        {
            this.RenameTable(name: "dbo.CompletedForms", newName: "FilledForms");
        }

        public override void Down()
        {
            this.RenameTable(name: "dbo.FilledForms", newName: "CompletedForms");
        }
    }
}
