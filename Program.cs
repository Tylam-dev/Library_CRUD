using System.Text.Json.Serialization;
using AutoMapper;
using Library_CRUD.Context;
using Library_CRUD.Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("library_db")));
builder.Services.AddLogging();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBorrowService, BorrowService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

var mapperConfig = new MapperConfiguration( m => 
{
    m.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapControllers();

app.Run();
