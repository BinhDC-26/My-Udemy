using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNop.Web.Framework.Infrastructure
{
    internal class DemoNopExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];

            string message = $"\nTime: {DateTime.Now}, Controller: {controllerName}, Action: {actionName}, Exception: {context.Exception.Message}";

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Log", "Log.txt");
            //saving the data in a text file called Log.txt
            File.AppendAllText(filePath, message);

            context.Result = new BadRequestResult();
        }
    }
}
