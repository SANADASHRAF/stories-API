using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region cors
//cors (first addition)
builder.Services.AddCors();
#endregion

#region swager change document and config
builder.Services.AddSwaggerGen(Options =>
{

    //swagger documentaction change
    Options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "storiesApi",
        Description = "my stories  asp .net core API 6 with swagger",
        TermsOfService = new Uri("https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-6.0&tabs=visual-studio"),

        Contact = new OpenApiContact
        {
            Name = "sanad ashraf",
            Email = "sanadbareen@gmail.com",
            Url = new Uri("https://github.com/SANADASHRAF")
        },

        License = new OpenApiLicense
        {
            Name = "License",
            Url = new Uri("https://github.com/SANADASHRAF"),
        },



    });

    //security definatin (autorization)
    Options.AddSecurityDefinition("Berear", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Berear",
        BearerFormat = "jwt",
        In = ParameterLocation.Header,
        Description = "jwt header token  send with request for autorization"

    });

    // Security Requirement
    Options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Name = "Bearer",
                In = ParameterLocation.Header,
                 Description="jwt header token  send with request for autorization",

            },
            new List<string>()
        }
    });


});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


#region cors
//cors(2)
app.UseCors(c => c.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()

  );
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
