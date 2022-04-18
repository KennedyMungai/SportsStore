using Microsoft.Extensions.Options;
using Platform;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MessageOptions>(options =>
    {
        options.CityName = "Albany";
    }
);

var app = builder.Build();

((IApplicationBuilder)app).Map("/branch", async branch =>
    {
        branch.UseMiddleware<Platform.QueryStringMiddleWare>();

        branch.Use(async (HttpContext context, Func<Task> next) =>
            {
                await context.Response.WriteAsync($"Branch Middleware");
            }
        );
    }
);

// app.Use(async (context, next) =>
//     {
//         if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
//         {
//             context.Response.ContentType = "text/plain";
//             await context.Response.WriteAsync("Custom Middleware \n");
//         }
//     }
// );

app.Use(async (context, next) => 
    {
        await next();
        await context.Response
            .WriteAsync($"\nStatus Code: {context.Response.StatusCode}");
    }
);

app.Use(async (context, next) => 
    {
        if (context.Request.Path == "/short")
        {
            await context.Response
                .WriteAsync($"Request short circuited");
        }
        else
        {
            await next();
        }
    }
);

app.UseMiddleware<Platform.QueryStringMiddleWare>();

app.MapGet("/", () => "Hello World!");

app.Run();
