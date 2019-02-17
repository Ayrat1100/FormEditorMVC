// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using FormEditor.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // для первого блока
            Form form = new Form();
            Block block = new Block() { SelectedField = 3 };
            form.Blocks = new List<Block>();
            form.Blocks.Add(block);
            return this.View(form);
        }

        [HttpPost]
        public ActionResult Index(Form form)
        {
            if (this.ModelState.IsValid)
            {
                // возвращается все кроме SelectedItem у выпадающего списка
                return this.Content("<script language='javascript' type='text/javascript'>alert('Succes');</script>");
            }
            else
            {
                return this.View(form);
            }
        }
    }
}