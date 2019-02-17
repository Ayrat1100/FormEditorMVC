// <copyright file="Form.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Form
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public string Name { get; set; }

        public string Description { get; set; }

        public Block Block { get; set; }

        public List<Block> Blocks { get; set; }
    }
}