// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using FormEditor.Models;
    using FormContext = Models.FormContext;

    public class HomeController : Controller
    {
        private readonly FieldsType fieldsType;
        private Form form;
        private FormContext formContext = new FormContext();

        public ActionResult Index()
        {
            this.form = new Form();
            Block block = new Block();
            block.FieldsType = FieldsType.SeveralFromTheList;
            this.form.Blocks = new List<Block>();
            this.form.Blocks.Add(block);
            this.ViewBag.ListItems = this.fieldsType;

            return this.View(this.form);
        }

        [HttpPost]
        public ActionResult Index(Form form)
        {
            this.RemoveData(form);
            if (this.ModelState.IsValid)
            {
                form.Guid = this.SetFormId(form.Guid);
                using (this.formContext)
                {
                    this.formContext.Forms.Add(form);
                    this.formContext.SaveChanges();
                }

                this.ViewBag.ListItems = this.fieldsType;

                return this.RedirectToAction("SaveForm", "Home", new { id = form.Guid });
            }
            else
            {
                return this.View(form);
            }
        }

        public ActionResult SaveForm(string id)
        {
            Form form = null;
            using (this.formContext)
            {
                form = this.formContext.Forms.Include(o => o.Blocks).Where(o => o.Guid == id).ToList()[0];
            }

            this.ViewBag.ListItems = this.fieldsType;
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