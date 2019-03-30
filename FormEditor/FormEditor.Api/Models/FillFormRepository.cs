// <copyright file="FillFormRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using FormEditor.Models;

    public class FillFormRepository : IRepository<FilledForm>
    {
        private bool disposed = false;
        private FormContext db;

        public FillFormRepository()
        {
            this.db = new FormContext();
        }

        public List<FilledForm> GetFormList()
        {
            return this.db.CompletedForms.ToList();
        }

        public DbSet<FilledForm> GetForms()
        {
            return this.db.CompletedForms;
        }

        public FilledForm GetForm(int id)
        {
            return this.db.CompletedForms.Find(id);
        }

        public void Create(FilledForm c)
        {
            this.db.CompletedForms.Add(c);
        }

        public void Update(FilledForm c)
        {
           // this.db.Entry(c).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            FilledForm c = this.db.CompletedForms.Find(id);
            if (c != null)
            {
                this.db.CompletedForms.Remove(c);
            }
        }

        public void Save()
        {
            this.db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.db.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}