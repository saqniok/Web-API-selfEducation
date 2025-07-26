/*
 *  var builder = WebApplication.CreateBuilder(args);
 *  ... Startpoint for ASP.NET Core application.
 *  app.Run();
 *        
 */


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true; // If the client requests a format that the server cannot produce, it will return a 406 Not Acceptable response.
});

builder.Services.AddProblemDetails(options =>
{
    // Add more Details in error messages
    options.CustomizeProblemDetails = ctx =>
    {
        ctx.ProblemDetails.Extensions.Add("additionaInfo", 
            "Additional information about the error.");    // add new parametr in error msg
        ctx.ProblemDetails.Extensions.Add("server",
            Environment.MachineName);                       // add name of device in error
        
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();          // Creates the web application based on the settings from builder.

// Configure the HTTP request pipeline.
// Setting up middleware (HTTP request processing pipeline):
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();       // Generates the API JSON description.
    app.UseSwaggerUI();     // Provides a visual interface at /swagger.
}

// Middleware are software components that handle HTTP requests and responses.
// Middleware can perform tasks such as authentication, authorization, logging, etc.
// Automatically redirects HTTP requests to HTTPS.
app.UseHttpsRedirection();

app.UseRouting();               // Enables routing middleware, which matches incoming requests to endpoints.

app.UseAuthorization();         // Enables middleware for authorization (but not authentication). Works if you have attributes like [Authorize] in controllers.

// Here EndpointRouting is configured — linking HTTP requests to handlers (controller methods).
app.MapControllers();           // Maps controller routes (e.g. GET /weatherforecast) to their corresponding methods.

app.Run();                      // Runs the application: it starts listening for HTTP requests.
