using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);
builder.Configure();
var app = builder.Build();

app.Configure();

app.Run();

