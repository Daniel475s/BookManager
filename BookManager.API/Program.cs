using BookManager.API.Mappers;
using BookManager.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("BooksCs");

//Dados em memoria
//builder.Services.AddDbContext<BookDbContext>(o => o.UseInMemoryDatabase("BooksDb"));

//Dados em Banco
builder.Services.AddDbContext<BookDbContext>(o => o.UseSqlServer(connectionString));


builder.Services.AddAutoMapper(typeof(BookProfile).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BookManager.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Daniel",
            Email= "daniemcristo.ds@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/daniels-soares/")
        }
    });

    var xmlFile = "BookManager.API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
