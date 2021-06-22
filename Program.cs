using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder => webBuilder.Configure(app => app.Use(async (context, _) =>
        {
            await using FileStream stream = File.OpenRead("index.html");
            context.Response.ContentType = "text/html";
            await stream.CopyToAsync(context.Response.Body);
        })))
        .Build()
        .Run();
