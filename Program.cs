using dosEvAPI.Repositories;
using dosEvAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;

 
var builder = WebApplication.CreateBuilder(args);
//!!Database
var connectionString = builder.Configuration.GetConnectionString("dosEvBack");
// Add services to the container.

//Inyeccion repo
 builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>(provider =>
        new ComentarioRepository(connectionString));

    builder.Services.AddScoped<ICategoriaEventoRepository, CategoriaEventoRepository>(provider =>
        new CategoriaEventoRepository(connectionString));

    builder.Services.AddScoped<ICategoriaProductoRepository, CategoriaProductoRepository>(provider =>
        new CategoriaProductoRepository(connectionString));

    builder.Services.AddScoped<IOrganizadorRepository, OrganizadorRepository>(provider =>
        new OrganizadorRepository(connectionString));

    builder.Services.AddScoped<IProductoRepository, ProductoRepository>(provider =>
        new ProductoRepository(connectionString));

    builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>(provider =>
        new UsuarioRepository(connectionString));

    builder.Services.AddScoped<IRolRepository, RolRepository>(provider =>
        new RolRepository(connectionString));

    builder.Services.AddScoped<ITematicaRepository, TematicaRepository>(provider =>
        new TematicaRepository(connectionString));

    builder.Services.AddScoped<IEventoRepository, EventoRepository>(provider =>
        new EventoRepository(connectionString));



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins",
            builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    });


builder.Services.AddScoped<IComentarioService, ComentarioService>();
builder.Services.AddScoped<ICategoriaEventoService, CategoriaEventoService>();
builder.Services.AddScoped<ICategoriaProductoService, CategoriaProductoService>();
builder.Services.AddScoped<IOrganizadorService, OrganizadorService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<ITematicaService, TematicaService>();
builder.Services.AddScoped<IEventoService, EventoService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AddAuthenticationScheme)

.AddJwtBearer(options =>
{

    options.RequireHttpsMetadata = false; // Cambiar a true si se necesita HTTPS
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Configuration["Jwt:Issuer"],
        ValidAudience = Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
        
    };

});

var app = builder.Build();

// Configure the HTTP request pipeline.




{
app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAllOrigins");

app.MapControllers();

app.Run();

