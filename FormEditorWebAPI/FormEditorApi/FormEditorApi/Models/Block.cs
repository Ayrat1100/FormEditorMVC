// <copyright file="Block.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditorApi.Models
{
    using System.ComponentModel.DataAnnotations;
    using ColumnAttribute = System.Data.Linq.Mapping.ColumnAttribute;

    [System.Data.Linq.Mapping.Table(Name = "Blocks")]
    public class Block
    {
        [Column]
        public int BlockId { get; set; }

        [Column]
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public string Header { get; set; }

        [Column]
        public string TextField { get; set; }

        [Column]
        public bool Mandatory { get; set; }

        [Column]
        public int Form_Id { get; set; }

        public Form Form { get; set; }

        [Column]
        public FieldsType FieldsType { get; set; }
    }
}