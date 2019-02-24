// <copyright file="Form.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class Form
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Block> Blocks { get; set; }

        public List<SelectListItem> Fields { get; set; } = new List<SelectListItem>()
                      {
                          new SelectListItem { Value = "1", Text = "Текст - строка" },
                          new SelectListItem { Value = "2", Text = "Текст - абзац" },
                          new SelectListItem { Value = "3", Text = "Один из списка", Selected = true },
                          new SelectListItem { Value = "4", Text = "Несколько из списка" },
                          new SelectListItem { Value = "5", Text = "Раскрывающийся список" }
                      };
    }
}