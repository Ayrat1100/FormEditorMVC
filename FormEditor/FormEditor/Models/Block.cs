// <copyright file="Block.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Block
    {
        public int BlockId { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public string Header { get; set; }

        public string TextField { get; set; }

        public bool Mandatory { get; set; }

        public Form Form { get; set; }

        public FieldsType FieldsType { get; set; }
    }
}