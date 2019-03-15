// <copyright file="ControllerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using FormEditor;
    using FormEditor.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ControllerTests
    {
        private Form form;

        [TestInitialize]
        public void TestDataInitialize()
        {
            this.form = new Form();
            Block block = new Block() { Header = "Header1" };
            Block block2 = new Block() { Header = "Header2" };
            Block block3 = new Block() { Header = null };
            this.form.Blocks = new List<Block>();
            this.form.Blocks.Add(block);
            this.form.Blocks.Add(block2);
            this.form.Blocks.Add(block3);
        }

        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        // на записи в сессию пока вылетает
        [TestMethod]
        public void SaveForm_Test()
        {
            string id = "1";
            HomeController controller = new HomeController();

            ViewResult result = controller.GetForm(id) as ViewResult;

            Assert.IsNotNull(result);
        }

        // на извлечении из сессии пока вылетает
        [TestMethod]
        public void SendForm_Test()
        {
            Form form = new Form();
            Block block = new Block() { Header = "Header1" };
            Block block2 = new Block() { Header = "Header1" };
            form.Blocks = new List<Block>();
            form.Blocks.Add(block);
            form.Blocks.Add(block2);

            HomeController controller = new HomeController();
            ActionResult result = controller.Index(form);

            // Assert.IsInstanceOfType(result, typeof(RedirectResult));
            Assert.AreEqual("Home/GetForm", ((RedirectResult)result).Url);
        }

        [TestMethod]
        public void SetFormId_Test()
        {
            Guid formId = Guid.NewGuid();
            string id = formId.ToString();

            HomeController controller = new HomeController();
            string actual = controller.GetFormId(id);

            Assert.AreEqual(id, actual);
        }

        [TestMethod]
        public void SetFormId_if_idIsNull_Test()
        {
            string id = null;

            HomeController controller = new HomeController();
            string actual = controller.GetFormId(id);

            Assert.IsFalse(actual is null);
        }

        [TestMethod]
        public void RemoveData_Test()
        {
            HomeController controller = new HomeController();
            controller.RemoveData(this.form);

            Assert.AreEqual(2, this.form.Blocks.Count);
        }
    }
}
