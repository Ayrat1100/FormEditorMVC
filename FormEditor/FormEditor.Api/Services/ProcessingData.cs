// <copyright file="ProcessingData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FormEditor.Api
{
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Xml;
    using ChoETL;
    using CsvHelper;
    using Newtonsoft.Json;

    public static class ProcessingData
    {
        public static string JsonStringToCSV(string jsonContent)
        {
            StringBuilder sb = new StringBuilder(jsonContent);
            using (var r = new ChoJSONReader(sb))
            {
                sb.Clear();
                using (var w = new ChoCSVWriter(sb).WithFirstLineHeader())
                {
                    w.Write(r);
                }
            }

            return sb.ToString();
        }

        public static string JsonStringToXml(string jsonContent)
        {
            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(jsonContent, "root");
            return doc.OuterXml;
        }
    }
}
