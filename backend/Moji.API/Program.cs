using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Moji.API.Services;
using Moji.Application.Interfaces;
using Moji.Application.Services;
using Moji.Domain.Entities;
using Moji.Infrastructure.Auth;
using Moji.Infrastructure.Context;
using Moji.Infrastructure.Repository;
using Moji.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var jwtSettings = builder.Configuration.GetSection("Jwt");
builder.Services.AddOpenApi();
builder.Services.AddDbContext<MojiDbContext>(o=>o.UseSqlServer(connectionString));
builder.Services.AddSingleton(sp => {
    var config= sp.GetRequiredService<IConfiguration>();
    var acc = new Account
    {
        ApiKey = config["Cloudinary:ApiKey"],
        ApiSecret = config["Cloudinary:ApiSecret"],
        Cloud = config["Cloudinary:CloudName"]
    };
    return new Cloudinary(acc); 

});
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IPostRepository,PostRepository>();
builder.Services.AddScoped<IGenericRepository<University>, GenericRepository<University>>();
builder.Services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUniversityService, UniversityService>();
builder.Services.AddTransient<IHashPassword, HashPassword>();
builder.Services.AddTransient<IGenerateToken, GenerateToken>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer= true,
                        ValidIssuer = jwtSettings["Issuer"],
                        ValidateAudience= true,
                        ValidAudience = jwtSettings["Audience"],
                        ValidateLifetime= true,
                        ValidateIssuerSigningKey= true,
                        IssuerSigningKey=new SymmetricSecurityKey(System.Text.UTF8Encoding.UTF8.GetBytes(jwtSettings["SecretKey"])),
                        ClockSkew=TimeSpan.Zero
                    };
                });
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowFrontend", p =>
    {
        p.AllowAnyHeader()
         .AllowAnyMethod()
         .AllowCredentials()
         .WithOrigins("http://localhost:5173");
    });
});
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<ICurrentUser, CurrentUser>();
builder.Services.AddTransient<IPhotoService,PhotoService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch(KeyNotFoundException e)
    {
        await ResponseHelper.HandleException(context, 404, e.Message);
    }
    catch(UnauthorizedAccessException e)
    {
        await ResponseHelper.HandleException(context, 401, e.Message);
    }
    catch(InvalidOperationException e)
    {
        await ResponseHelper.HandleException(context, 400, e.Message);
    }
    catch(Exception e)
    {
        await ResponseHelper.HandleException(context, 500, e.Message);
    }
});
app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
