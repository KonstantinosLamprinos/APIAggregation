using AggregationService;
using AggregationService.API;
using AggregationService.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAPI, OpenMeteoAPI>();
builder.Services.AddScoped<IAPI, RestCountriesAPI>();


builder.Services.AddHttpClient();
builder.Services.AddHttpClient<IRetrieveDataService, RetrieveDataService>();
//builder.Services.AddScoped<IAggregatorService, APIAggregatorService>();

builder.Services.AddScoped<IAPIFactory,APIFactory>();
builder.Services.AddScoped<IAPIAggregatorService, APIAggregatorService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Aggregation API", Version = "v1" });

    var scheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Paste only the JWT"
    };
    c.AddSecurityDefinition("Bearer", scheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


// Add JWT Authentication
var jwtSecret = builder.Configuration["JWT:Secret"];
if (string.IsNullOrWhiteSpace(jwtSecret))
    throw new Exception("JWT:Secret is missing in configuration!");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret!)),
        RoleClaimType = ClaimTypes.Role,
        ClockSkew = TimeSpan.Zero
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            if (!string.IsNullOrEmpty(context.Token))
                return Task.CompletedTask;

            // try the HttpOnly cookie
            if (context.Request.Cookies.TryGetValue("jwt", out var cookieToken) &&
                !string.IsNullOrWhiteSpace(cookieToken))
            {
                context.Token = cookieToken;
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddAuthorization();




builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.WithOrigins("http://localhost:5037")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials());
});



var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
