// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using FormEditor.Models;

    public class HomeController : Controller
    {
        private Form form;
        private IRepository formRepository;

        [ActionName("Index")]
        public ActionResult Index()
        {
            this.form = new Form();
            Block block = new Block();
            block.FieldsType = FieldsType.SeveralFromTheList;
            this.form.Blocks = new List<Block>();
            this.form.Blocks.Add(block);
            this.ViewBag.ListItems = FieldsType.OneOfTheList;

            return this.View(this.form);
        }

        [HttpPost]
        public ActionResult Index(Form form)
        {
            if (form != null)
            {
                this.RemoveData(form);
                if (this.ModelState.IsValid)
                {
                    if (form.Guid == null)
                    {
                        form.Guid = this.GetFormId(form.Guid);

                        this.formRepository.Create(form);
                        this.formRepository.Save();
                        this.ViewBag.ListItems = FieldsType.OneOfTheList;
                    }
                    else
                    {
                    }

                    return this.RedirectToAction("GetForm", "Home", new { id = form.Guid });
                }

                return this.View(form);
            }
            else
            {
                return this.View(form);
            }
        }

        public ActionResult GetForm(string id)
        {
            Form form = null;
            form = this.formRepository.GetForms().Include(o => o.Blocks).Where(o => o.Guid == id).ToList()[0];

            return this.View("Index", form);
        }

        /// <summary>
        /// Deleting data on the server after releting in view
        /// </summary>
        /// <param name="form">Current form</param>
        public void RemoveData(Form form)
        {
            form.Blocks.RemoveAll(o => string.IsNullOrEmpty(o.Header));
        }

        /// <summary>
        /// Sets the Id of the current form if it's null
        /// </summary>
        /// <param name="formId">The current form id</param>
        /// <returns>Returned id of the current form</returns>
        public string GetFormId(string formId)
        {
            if (formId != null && formId != string.Empty)
            {
                return formId;
            }
            else
            {
                Guid id = Guid.NewGuid();
                return id.ToString();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class (for tests).
        /// </summary>
        /// <param name="repository">data rep.</param>
        public HomeController(IRepository repository)
        {
            repository = new FormRepository();
            this.formRepository = repository;
        }

        public HomeController()
        {
            this.formRepository = new FormRepository();
        }
    }
}