using Microsoft.EntityFrameworkCore;
using TstCompras.Data;
// using TstCompras.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurando o CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()  // Permite qualquer origem (domínios)
              .AllowAnyHeader()  // Permite qualquer cabeçalho
              .AllowAnyMethod(); // Permite qualquer método (GET, POST, etc.)
    });
});

// Adicionando HttpClient


// Configurar o contexto do banco de dados (usando PostgreSQL como exemplo)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TstComprasConnection")));

// Configuração de controladores
builder.Services.AddControllers();

// Adiciona e configura o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();

// Ativando o middleware de CORS
app.UseCors("PermitirTudo");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
