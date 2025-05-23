﻿using DemoNop.Core.Infrastructure;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNop.Web.Framework.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configure the application HTTP request pipeline
        /// </summary>
        /// <param name="application">Builder for configuring an application's request pipeline</param>
        public static void ConfigureRequestPipeline(this IApplicationBuilder application)
        {
            EngineContext.Current.ConfigureRequestPipeline(application);
        }
    }
}
