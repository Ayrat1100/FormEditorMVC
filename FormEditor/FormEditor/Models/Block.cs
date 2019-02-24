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

        public string TextField { get; set; }

        public bool Mandatory { get; set; }

        public string SelectedTypeField { get; set; }
    }
}