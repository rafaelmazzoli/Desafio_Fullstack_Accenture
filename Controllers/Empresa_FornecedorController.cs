using Desafio_Fullstack_Accenture.Data;
using Desafio_Fullstack_Accenture.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Desafio_Fullstack_Accenture.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class Empresa_FornecedorController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(IEmpresa_FornecedorData empresa_FornecedorData) => Ok(await empresa_FornecedorData.GetAll());

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, IEmpresa_FornecedorData empresa_FornecedorData)
        {
            var empresaResult = await empresa_FornecedorData.GetById(Id);

            if (empresaResult == null) return NotFound();

            return Ok(empresaResult);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Empresa_Fornecedor empresa_Fornecedor, IEmpresa_FornecedorData empresa_FornecedorData, IEmpresaData empresaData, IFornecedorData fornecedorData)
        {
            var valido = await ValidaEmpresaParana(empresa_Fornecedor, empresaData, fornecedorData);
            if (!valido) return BadRequest("Empresas do Paraná não podem ter fornecedores menores de idade.");

            var empresaResult = await empresa_FornecedorData.Insert(empresa_Fornecedor);

            if (empresaResult == null) return NotFound();

            return Ok(empresaResult);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, Empresa_Fornecedor empresa_Fornecedor, IEmpresa_FornecedorData empresa_FornecedorData, IEmpresaData empresaData, IFornecedorData fornecedorData)
        {
            var valido = await ValidaEmpresaParana(empresa_Fornecedor, empresaData, fornecedorData);
            if (!valido) return BadRequest("Empresas do Paraná não podem ter fornecedores menores de idade.");

            empresa_Fornecedor.SetId(Id);

            var empresaResult = await empresa_FornecedorData.Update(empresa_Fornecedor);

            if (empresaResult == null) return NotFound();

            return Ok(empresaResult);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Update(int Id, IEmpresa_FornecedorData empresa_FornecedorData)
        {
            var empresaResult = await empresa_FornecedorData.Delete(Id);

            if (empresaResult == null) return NotFound();

            return Ok(empresaResult);
        }

        [NonAction]
        public async Task<bool> ValidaEmpresaParana(Empresa_Fornecedor empresa_Fornecedor, IEmpresaData empresaData, IFornecedorData fornecedorData)
        {
            var empresa = await empresaData.GetById(empresa_Fornecedor.Id_Empresa);
            var fornecedor = await fornecedorData.GetById(empresa_Fornecedor.Id_Fornecedor);

            if (empresa == null || fornecedor == null) return false;

            if (fornecedor.Data_Nascimento == null) return true;

            // Check Maior de Idade
            DateTime now = DateTime.Now;
            DateTime birth = DateTime.Parse(s: fornecedor.Data_Nascimento.ToString());
            DateTime limitDate = birth.AddYears(18);
            
            // Check Localidade
            ViaCep viaCep = new ViaCep();
            var response = await viaCep.ValidaCep(empresa.Cep);
            if (!response.IsSuccessStatusCode) return false;

            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ViaCepResponse>(jsonString);

            if (result != null && result.uf == "PR" && limitDate > now) return false;

            return true;
        }
    }
}