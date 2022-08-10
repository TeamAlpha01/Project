using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpLogging;
using IMS.DataAccessLayer;
using System.Reflection;
using IMS.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using IMS.Models;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
             new string[] {}
     }
 });
});

//DbContext
builder.Services.AddDbContext<InterviewManagementSystemDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("IMS"));
    });

//JSON Web Token
builder.Services.AddTransient<TokenService>();


//Dependency Injection For Services and Data Access Layer
builder.Services.AddTransient<InterviewManagementSystemDbContext>();

builder.Services.AddTransient<IRoleService,RoleService>();
builder.Services.AddTransient<IRoleDataAccessLayer,RoleDataAccessLayer>();
builder.Services.AddTransient<IDepartmentService,DepartmentService>();
builder.Services.AddTransient<IDepartmentDataAccessLayer,DepartmentDataAccessLayer>();
builder.Services.AddTransient<IDriveService,DriveService>();
builder.Services.AddTransient<IDriveDataAccessLayer,DriveDataAccessLayer>();
builder.Services.AddTransient<IEmployeeService,EmployeeService>();
builder.Services.AddTransient<IEmployeeDataAccessLayer,EmployeeDataAccessLayer>();
builder.Services.AddTransient<ILocationServices,LocationService>();
builder.Services.AddTransient<ILocationDataAccessLayer,LocationDataAccessLayer>();
builder.Services.AddTransient<IPoolService,PoolService>();
builder.Services.AddTransient<IPoolDataAccessLayer,PoolDataAccessLayer>();
builder.Services.AddTransient<IPoolDataAccessLayer,PoolDataAccessLayer>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        TokenDecryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
    };
}
);

//SMPT SERVICE
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
//builder.Services.AddSingleton<MailService>();
builder.Services.AddTransient<IMailService,MailService>();
builder.Services.AddTransient<IMailDataAccessLayer,MailDataAccessLayer>();



//Logging
builder.Services.AddHttpLogging(httpLogging =>
{
    httpLogging.LoggingFields = HttpLoggingFields.All;
});

var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
builder.Logging.AddSerilog(logger);

//CORS ANGULAR
builder.Services.AddCors((setup) =>
{
    setup.AddPolicy("default", (options) =>
    {
        options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

//JSON Include() output Serializer
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling =
Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddTransient<MailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
}
app.UseCors("default");

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpLogging();


app.MapControllers();

app.Run();

