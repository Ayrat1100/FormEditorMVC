// <copyright file="FeldsType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

public enum FieldsType
{
    [Display(Name = "Текст - строка")]
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