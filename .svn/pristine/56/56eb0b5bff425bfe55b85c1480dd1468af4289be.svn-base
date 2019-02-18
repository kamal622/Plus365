using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace _365Plus.Web.Framework
{
    public class JsonpResult : JsonResult
    {
        public JsonpResult(string callbackName)
        {
            CallbackName = callbackName;
            this.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }

        public JsonpResult() : this("callback")
        {
        }

        public string CallbackName { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;

            string jsoncallback = ((context.RouteData.Values[CallbackName] as string) ?? request[CallbackName]) ?? CallbackName;

            if (!string.IsNullOrEmpty(jsoncallback))
            {
                response.ContentType = "application/x-javascript"; // string.IsNullOrEmpty(ContentType) ? "application/x-javascript" : ContentType;
                if (ContentEncoding != null)
                    response.ContentEncoding = ContentEncoding;
                if (Data == null)
                    return;
                response.Write(string.Format("{0}({1})", jsoncallback, JsonConvert.SerializeObject(Data)));
            }
        }
    }
}
