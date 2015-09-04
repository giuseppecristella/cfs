using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

namespace Shop.Web.Mvp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            //var webAddr = "http://localhost:4992/WCFService/CatalogDataService.svc/AddProductToSessionCart";
            //var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            //httpWebRequest.ContentType = "application/json; charset=utf-8";
            //httpWebRequest.Method = "POST";

            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    string json = "{\"name\":\"peppe\"}";

            //    streamWriter.Write(json);
            //    streamWriter.Flush();
            //}

            //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    var result = streamReader.ReadToEnd();

            //}


        }
    }
}