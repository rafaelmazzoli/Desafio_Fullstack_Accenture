var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Configurações do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Referências
builder.Services.AddSingleton<IDatabaseAccess, DatabaseAccess>();
builder.Services.AddSingleton<IEmpresaData, EmpresaData>();
builder.Services.AddSingleton<IFornecedorData, FornecedorData>();
builder.Services.AddSingleton<IEmpresa_FornecedorData, Empresa_FornecedorData>();

var app = builder.Build();

// Configurações de Ambiente de Desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
