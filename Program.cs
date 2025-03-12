using dosEvAPI.Repositories;
using dosEvAPI.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.HttpOverrides;

 
var builder = WebApplication.CreateBuilder(args);
//!!Database
var connectionString = builder.Configuration.GetConnectionString("dosEvBack");
// Add services to the container.
var jwtSecretKey = builder.Configuration["JwtSettings:Key"]
    ?? throw new InvalidOperationException("JWT Secret Key is missing in configuration.");


var key = Encoding.UTF8.GetBytes(jwtSecretKey);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            ValidateLifetime = true
        };
    });


builder.Services.AddAuthorization();
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

    builder.Services.AddScoped<IPostRepository, PostRepository>(provider =>
        new PostRepository(connectionString));

    builder.Services.AddScoped<IEventoRepository, EventoRepository>(provider =>
        new EventoRepository(connectionString));

    builder.Services.AddScoped<ITokenRepository, TokenRepository>(provider =>
        new TokenRepository(connectionString));

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
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ITematicaService, TematicaService>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<TokenService>(provider =>
{
    var tokenRepository = provider.GetRequiredService<ITokenRepository>();
    return new TokenService(tokenRepository, jwtSecretKey);
});

var app = builder.Build();

// Configure the HTTP request pipeline.



app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API ZaragozaConecta V1");
    c.RoutePrefix = string.Empty;
});

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

if (!app.Environment.IsDevelopment())
{
    app.Logger.LogInformation("No se usara HTTPS dentro del contenedor.");
}
else
{
    app.UseHttpsRedirection();
}

app.UseCors("AllowAllOrigins");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
