// <copyright file="FormsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditorApi
{
    using System;
    using System.Configuration;
    using System.Data.Linq;
    using System.Linq;
    using System.Net.Http;
    using System.ServiceModel.Channels;
    using System.Web;
    using System.Web.Http;
    using FormEditor;
    using FormEditor.Api;
    using FormEditor.Models;

    public class FormsController : ApiController
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["FormContext"].ConnectionString;
        private IRepository<FilledForm> repository;
        private DataContext dataContext;

        public FormsController()
        {
            this.repository = new FillFormRepository();
            this.dataContext = new DataContext(this.connectionString);
            ConnectionService.AuditDbConnect(this.connectionString);
        }

        public FormsController(IRepository<FilledForm> repository)
        {
            repository = new FillFormRepository();
            this.repository = repository;
        }

        public object GetFormData(int id)
        {
            var formTable = this.dataContext.GetTable<Form>().FirstOrDefault(u => u.Id == id);
            if (formTable != null)
            {
                var blockTable = this.dataContext.GetTable<Block>().ToList();
                formTable.Blocks = blockTable.Where(o => o.FormId == formTable.Id).ToList();
                this.AddInfo(formTable.Guid);

                return formTable;
            }
            else
            {
                return "Записи с идентификатором " + id + " не существует.";
            }
        }

        public object PostUserForm([FromBody]object form)
        {
            string[] formData = { ProcessingData.JsonStringToCSV(form.ToString()), ProcessingData.JsonStringToXml(form.ToString()) };
            if (formData.Any(x => x != null || x != string.Empty))
            {
                FilledForm filledForm = new FilledForm() { FilingDate = DateTime.Now, DataCSVFormat = formData[0], DataXmlFormat = formData[1] };
                this.repository.Create(filledForm);
                this.repository.Save();
                return "Ok";
            }
            else
            {
                return "Bad";
            }
        }

            /// <summary>
            /// Adding query information to the audit info table
            /// </summary>
            /// <param name="formId">Request form GUID</param>
        public void AddInfo(string formId)
        {
            AuditInfo auditInfo = new AuditInfo() { FormId = formId, ClientIP = this.GetClientIp(), RequestTime = DateTime.Now.ToShortTimeString() };
            this.dataContext.GetTable<AuditInfo>().InsertOnSubmit(auditInfo);
            this.dataContext.SubmitChanges();
        }

        private string GetClientIp(HttpRequestMessage request = null)
        {
            request = request ?? this.Request;

            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            else if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            else
            {
                return null;
            }
        }
    }
}
