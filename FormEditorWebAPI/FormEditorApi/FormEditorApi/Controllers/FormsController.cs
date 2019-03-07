// <copyright file="FormsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditorApi.Controllers
{
    using System.Configuration;
    using System.Data.Linq;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.Http;
    using FormEditor.Models;

    public class FormsController : ApiController
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["FormContext"].ConnectionString;

        public Form GetFormData(string id)
        {
            DataContext dataContext = new DataContext(this.connectionString);

            //Table<Form> users = dataContext.GetTable<Form>();

            var formTable = dataContext.GetTable<Form>().Where(u => u.Guid == id).ToList()[0];
            var blockTable = dataContext.GetTable<Block>().ToList();

            formTable.Blocks = blockTable.Where(o => o.Form_Id == formTable.Id).ToList();

            return formTable;
        }
    }
}
