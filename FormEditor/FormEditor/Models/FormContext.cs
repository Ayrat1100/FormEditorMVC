// <copyright file="FormContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor
{
    using System.Data.Entity;
    using FormEditor.Models;

    public class FormContext : DbContext
    {
        public FormContext()
            : base("name=FormContext")
        {
            Database.SetInitializer<FormContext>(new ContextInitializer());
        }

        public DbSet<Form> Forms { get; set; }

        public DbSet<Block> Blocks { get; set; }

        public DbSet<FilledForm> CompletedForms { get; set; }
    }
}