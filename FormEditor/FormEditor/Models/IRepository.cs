// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public interface IRepository<T> : IDisposable
        where T : class
    {
        List<T> GetFormList();

        T GetForm(int id);

        DbSet<T> GetForms();

        void Create(T item);

        void Update(T item);

        void Delete(int id);

        void Save();
    }
}
