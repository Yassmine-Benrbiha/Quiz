
using Components.DependencyInjection;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
const string policy = "AlowOrigins";

// Add services to the container.
builder.Services.AddRazorPages();
//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(policy,
    builder => builder.WithOrigins("http://localhost:4200",
    "https://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
});
//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.RegisterComponents();

//Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                       new OpenApiSecurityScheme
                       {
                            Name = "name",
                            Type = SecuritySchemeType.OAuth2,
                            In = ParameterLocation.Header,
                            Reference= new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                       },
                       new List<string>()}
                });
});
//DbContext
builder.Services.AddDbContext<myDatabaseContext>(o =>
{
    var connectionString = builder.Configuration["ConnectionStrings:MyProject"];
    //  o.UseLazyLoadingProxies();
    o.UseSqlServer(connectionString);
    o.UseSqlServer(connectionString);
}, ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
   
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();


app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend");
    options.OAuthClientId("Backend_swagger");
    options.OAuthAppName("Backend - Swagger");
    options.OAuthUsePkce();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors(policy);
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireCors(policy);
});
app.UseAuthorization();

app.MapRazorPages();

app.Run();
