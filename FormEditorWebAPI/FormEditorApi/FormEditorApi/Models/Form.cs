// <copyright file="Form.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ColumnAttribute = System.Data.Linq.Mapping.ColumnAttribute;

    public enum FieldsType
    {
        [Display(Name ="Текст - строка")]
        TextString = 1,
        [Display(Name = "Текст - абзац")]
        Paragraph = 2,
        [Display(Name = "Один из списка")]
        OneOfTheList = 3,
        [Display(Name = "Несколько из списка")]
        SeveralFromTheList = 4,
        [Display(Name = "Раскрывающийся список")]
        DropdownList = 5
    }

    [System.Data.Linq.Mapping.Table(Name = "Forms")]
    public class Form
    {
        [Column]
        public int Id { get; set; }

        [Column]
        public string Guid { get; set; }

        [Column]
        [Required(ErrorMessage = "Поле обязательно для заполнения!")]
        public string Name { get; set; }

        [Column]
        public string Description { get; set; }

        public List<Block> Blocks { get; set; }
    }
}