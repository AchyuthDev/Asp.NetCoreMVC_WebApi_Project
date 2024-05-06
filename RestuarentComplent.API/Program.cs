using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using RestuarentComplent.API.Data;
using RestuarentComplent.API.Repositry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRestaurentComplent, RestuarentComplentRepositry>();
builder.Services.AddDbContext<ApplicationDbContext>
    (options=>options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));

builder.Services.AddControllers()
    .AddOData((option=>option.Select().Count().OrderBy().Expand().SetMaxTop(100)));

var myallowspecicOrigin = "_myallowspecificOrigin";
//add cors
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: myallowspecicOrigin,
        Policy =>
        {
            Policy.WithOrigins("http://localhost:5095")
             .WithHeaders()
             .WithMethods();
        });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action}/{id?}");
app.UseCors(myallowspecicOrigin);

app.Run();
