using Microsoft.EntityFrameworkCore;
using UserMgtAPI.context;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder =>
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials()
               .SetIsOriginAllowed((builer) => true));
});

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services
//     .AddControllers(mvcOptions => {
//         mvcOptions.EnableEndpointRouting = false;
//     })
//     .AddOData((opt, services) => opt
//         .Count()
//         .Filter()
//         .Expand()
//         .Select()
//         .OrderBy()
//         .SetMaxTop(null)
//         .AddRouteComponents(GetEdmModel())
//         .AddRouteComponents("api/odata", new EdmModelBuilder(services).GetEdmModel())
//     );


// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();


var app = builder.Build();

app.UseCors("CORSPolicy");

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();