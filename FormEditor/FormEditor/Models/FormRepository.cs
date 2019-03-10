// <copyright file="FormRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class FormRepository : IRepository
    {
        private bool disposed = false;
        private FormContext db;

        public FormRepository()
        {
            this.db = new FormContext();
        }

        public List<Form> GetFormList()
        {
            return this.db.Forms.ToList();
        }

        public DbSet<Form> GetForms()
        {
            return this.db.Forms;
        }

        public Form GetForm(int id)
        {
            return this.db.Forms.Find(id);
        }

        public void Create(Form c)
        {

            this.db.Forms.Add(c);
        }

        public void Update(Form c)
        {
            this.db.Entry(c).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Form c = this.db.Forms.Find(id);
            if (c != null)
            {
                this.db.Forms.Remove(c);
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