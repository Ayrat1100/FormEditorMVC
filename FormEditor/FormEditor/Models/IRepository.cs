namespace FormEditor
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using FormEditor.Models;

    public interface IRepository : IDisposable
    {
        List<Form> GetFormList();

        Form GetForm(int id);

        DbSet<Form> GetForms();

        void Create(Form item);

        void Update(Form item);

        void Delete(int id);

        void Save();
    }
}
