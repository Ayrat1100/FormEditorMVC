// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using FormEditor.Models;

    public class HomeController : Controller
    {
        private Form form;

        public ActionResult Index()
        {
            this.form = new Form();
            Block block = new Block();
            block.SelectedTypeField = "4";
            this.form.Blocks = new List<Block>();
            this.form.Blocks.Add(block);
            return this.View(this.form);
        }

        [HttpPost]
        public ActionResult Index(Form form)
        {
            this.RemoveData(form);
            if (this.ModelState.IsValid)
            {
                form.Id = this.SetFormId(form.Id);
                this.Session["CurrentSession"] = form;
                return this.RedirectToAction("SaveForm", "Home", new { id = form.Id });
            }
            else
            {
                return this.View(form);
            }
        }

        public ActionResult SaveForm(string id)
        {
            var form = (Form)this.Session["CurrentSession"];
            return this.View("Index", form);
        }

        public void RemoveData(Form form)
        {
             for (int i = form.Blocks.Count - 1; i > 0; i--)
             {
                 if (form.Blocks[i].Header == null)
                 {
                    form.Blocks.RemoveAt(i);
                 }
             }
        }

        /// <summary>
        /// Sets the Id of the current form if it's null
        /// </summary>
        /// <param name="formId">The current form id</param>
        /// <returns>Returned id of the current form</returns>
        public string SetFormId(string formId)
        {
            if (formId != null)
            {
                return formId;
            }
            else
            {
                Guid id = Guid.NewGuid();
                return id.ToString();
            }
        }
    }
}