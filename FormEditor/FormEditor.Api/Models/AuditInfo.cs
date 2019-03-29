// <copyright file="AuditInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditorApi
{
    using System.Data.Linq.Mapping;

    [Table(Name = "AuditInfo")]
    public class AuditInfo
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public string RequestTime { get; set; }

        [Column]
        public string FormId { get; set; }

        [Column]
        public string ClientIP { get; set; }
    }
}