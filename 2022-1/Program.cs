// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => {
	webBuilder.Configure(app => {
		app.Run(context => 
			context.Response.WriteAsync("Jakiś komunikat")
		);
	});

		}).Build().Run();
