// <copyright file="Block.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class Block
    {
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public string Header { get; set; }

        public int SelectedField { get; set; }

        public string TextField { get; set; }

        public bool Mandatory { get; set; }

        public IEnumerable<Field> Fields { get; set; } = new List<Field>()
                      {
                          new Field { Id = 1, Title = "Текст - строка" },
                          new Field { Id = 2, Title = "Текст - абзац" },
                          new Field { Id = 3, Title = "Один из списка" },
                          new Field { Id = 4, Title = "Несколько из списка" },
                          new Field { Id = 5, Title = "Раскрывающийся список" }
                      };
    }
}