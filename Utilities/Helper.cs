using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Items.Interfaces;
using Items.Services;
using Items.Utilities;

namespace Items.Utilities
{
    public static class Helper
    {
        public static void AddAssiment(this IServiceCollection services)
        {
            services.AddSingleton<IAssiment, AssimentService>();      
        }
    }
}