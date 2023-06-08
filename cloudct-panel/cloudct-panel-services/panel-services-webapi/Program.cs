using panel_services_core.Infrastructure.Repository;
using panel_services_core.Services;

var builder = WebApplication.CreateBuilder(args);

//policy name, problem cors
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; 


// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IServicesService, ServicesService>();
builder.Services.AddScoped<IServicesRepository, ServicesRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//problem cors
builder.Services.AddCors(options =>  
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:5173");  //url do front, para ter permissão para mexer no back
                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//problem cors
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
