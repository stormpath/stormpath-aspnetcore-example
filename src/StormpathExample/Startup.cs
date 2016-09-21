// <copyright file="Startup.cs" company="Stormpath, Inc.">
// Copyright (c) 2016 Stormpath, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Stormpath.AspNetCore;

namespace StormpathExample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // By default, the Stormpath SDK will look for the 
            // API Key ID, API Key Secret, and Application href in environment variables.

            // It will also search the application root for a file called stormpath.yaml or stormpath.json.
            // This example project contains a stormpath.yaml file.
            services.AddStormpath();

            // You can optionally pass a configuration object instead.
            // Instantiate and pass an object to configure the SDK via code:
            //app.UseStormpath(new StormpathConfiguration
            //{
            //    Application = new ApplicationConfiguration
            //    {
            //        Href = "YOUR_APPLICATION_HREF"
            //    },
            //    Client = new ClientConfiguration
            //    {
            //        ApiKey = new ClientApiKeyConfiguration
            //        {
            //            Id = "YOUR_API_KEY_ID",
            //            Secret = "YOUR_API_KEY_SECRET"
            //        }
            //    }
            //});

            // Add framework services.
            services.AddMvc();

            // Configure authorization policies here, which can include Stormpath requirements.
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("AdminGroup", policy => policy.AddRequirements(new StormpathGroupsRequirement("admin")));
                opt.AddPolicy("FavoriteIsCyan", policy => policy.AddRequirements(new StormpathCustomDataRequirement("favoriteColor", "cyan")));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseStormpath();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
