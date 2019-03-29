// <copyright file="Global.asax.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Api
{
    using System.Linq;
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest()
        {
            if (this.Request.Headers.AllKeys.Contains("Origin") && this.Request.HttpMethod == "OPTIONS")
            {
                this.Response.Flush();
            }
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
