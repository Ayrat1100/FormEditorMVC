// <copyright file="FormContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Models
{
    using System.Data.Entity;

    public class FormContext : DbContext
    {
        static FormContext()
        {
            Database.SetInitializer(new ContextInitializer());
        }

        public FormContext()
            : base("name=FormContext")
        {
            Database.SetInitializer<FormContext>(new ContextInitializer());
        }

        public DbSet<Form> Forms { get; set; }

        public DbSet<Block> Blocks { get; set; }
    }
}