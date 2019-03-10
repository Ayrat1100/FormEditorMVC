// <copyright file="FormsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditorApi
{
    using System;
    using System.Configuration;
    using System.Data.Linq;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web.Http;
    using FormEditor.Models;
    using FormEditorApi.Models;

    public class FormsController : ApiController
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["FormContext"].ConnectionString;
        private DataContext dataContext;

        public FormsController()
        {
            this.dataContext = new DataContext(this.connectionString);
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CreateAuditInfoTable.sql");
                string query = @System.IO.File.ReadAllText(path, Encoding.GetEncoding(1251));
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Connection = connection;
            }
        }

        public Form GetFormData(string id)
        {
            if (this.dataContext.GetTable<Form>().Any(o => o.Guid == id))
            {
                var formTable = this.dataContext.GetTable<Form>().Where(u => u.Guid == id).ToList()[0];
                var blockTable = this.dataContext.GetTable<Block>().ToList();

                formTable.Blocks = blockTable.Where(o => o.Form_Id == formTable.Id).ToList();
                this.AddInfo(formTable.Guid);

                return formTable;
            }
            else
            {
                // Пока так
                return null;
            }
        }

        /// <summary>
        /// Adding query information to the audit info table
        /// </summary>
        /// <param name="formId">Request form GUID</param>
        public void AddInfo(string formId)
        {
            AuditInfo auditInfo = new AuditInfo() { FormId = formId, ClientIP = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString(), RequestTime = DateTime.Now.ToShortTimeString() };
            this.dataContext.GetTable<AuditInfo>().InsertOnSubmit(auditInfo);
            this.dataContext.SubmitChanges();
        }
    }
}
