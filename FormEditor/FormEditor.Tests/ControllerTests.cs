// <copyright file="ControllerTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using FormEditor.Controllers;
    using FormEditor.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class ControllerTests
    {
        private Form form;

        [TestInitialize]
        public void TestDataInitialize()
        {
            this.form = new Form() { Name = "test" };
            Block block = new Block() { Header = "Header1" };
            Block block2 = new Block() { Header = "Header2" };
            Block block3 = new Block() { Header = null };
            this.form.Blocks = new List<Block>();
            this.form.Blocks.Add(block);
            this.form.Blocks.Add(block2);
            this.form.Blocks.Add(block3);
        }

        // по какой-то причине ViewName == "", а не "Index"
        [TestMethod]
        public void GetForm_If_formIsNotValid_Test()
        {
            string expected = string.Empty;
            var mock = new Mock<IRepository>();
            Form form = new Form() { Name = "test" };
            HomeController controller = new HomeController(mock.Object);
            controller.ModelState.AddModelError("Name", "Название модели не установлено");
            ViewResult result = controller.Index(this.form) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ViewName);
        }

        [TestMethod]
        public void GetForm_If_formIsNull()
        {
            string expected = string.Empty;
            var mock = new Mock<IRepository>();
            Form form = null;
            HomeController controller = new HomeController(mock.Object);
            controller.ModelState.AddModelError("Name", "Название модели не установлено");
            ViewResult result = controller.Index(form) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ViewName);
        }

        [TestMethod]
        public void Index_Test()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.GetFormList()).Returns(new List<Form>());
            HomeController controller = new HomeController(mock.Object);
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result.Model);
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
