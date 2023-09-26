var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Configura��es do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Refer�ncias
builder.Services.AddSingleton<IDatabaseAccess, DatabaseAccess>();
builder.Services.AddSingleton<IEmpresaData, EmpresaData>();
builder.Services.AddSingleton<IFornecedorData, FornecedorData>();
builder.Services.AddSingleton<IEmpresa_FornecedorData, Empresa_FornecedorData>();

var app = builder.Build();

// Configura��es de Ambiente de Desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
