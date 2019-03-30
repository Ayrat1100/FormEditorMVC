// <copyright file="CompletedForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Models
{
    using System;

    public class FilledForm
    {
        public int Id { get; set; }

        public DateTime FilingDate { get; set; }

        public string DataCSV { get; set; }
    }
}