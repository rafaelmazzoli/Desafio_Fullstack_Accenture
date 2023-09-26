using Desafio_Fullstack_Accenture.Models;
using Desafio_Fullstack_Accenture.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Fullstack_Accenture.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FornecedorController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(IFornecedorData fornecedorData) => Ok(await fornecedorData.GetAll());

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, IFornecedorData fornecedorData)
        {
            var empresaResult = await fornecedorData.GetById(Id);

            if (empresaResult == null) return NotFound();

            return Ok(empresaResult);
        }

        [HttpPost("cnpj")]
        public async Task<IActionResult> InsertCnpj(Fornecedor fornecedor, IFornecedorData fornecedorData)
        {
            if (fornecedor.Cnpj_Cpf.Length != 14) return BadRequest("Esse endpoint cria apenas fornecedores com CNPJ");

            ViaCep viaCep = new ViaCep();
            var response = await viaCep.ValidaCep(fornecedor.Cep);
            if (!response.IsSuccessStatusCode) return BadRequest("Cep Inválido");

            var empresaResult = await fornecedorData.InsertCnpj(fornecedor);

            if (empresaResult == null) return NotFound();

            return Ok(empresaResult);
        }

        [HttpPost("cpf")]
        public async Task<IActionResult> InsertCpf(Fornecedor fornecedor, IFornecedorData fornecedorData)
        {
            if (fornecedor.Cnpj_Cpf.Length != 11) return BadRequest("Esse endpoint cria apenas fornecedores com CPF");

            ViaCep viaCep = new ViaCep();
            var response = await viaCep.ValidaCep(fornecedor.Cep);
            if (!response.IsSuccessStatusCode) return BadRequest("Cep Inválido");

            var empresaResult = await fornecedorData.InsertCpf(fornecedor);

            if (empresaResult == null) return NotFound();

            return Ok(empresaResult);
        }

        [HttpPut("cpf/{Id}")]
        public async Task<IActionResult> UpdateCpf(int Id, Fornecedor fornecedor, IFornecedorData fornecedorData)
        {
            ViaCep viaCep = new ViaCep();
            var response = await viaCep.ValidaCep(fornecedor.Cep);
            if (!response.IsSuccessStatusCode) return BadRequest("Cep Inválido");

            fornecedor.SetId(Id);

            var empresaResult = await fornecedorData.UpdateCpf(fornecedor);

            if (empresaResult == null) return NotFound();

            return Ok(empresaResult);
        }

        [HttpPut("cnpj/{Id}")]
        public async Task<IActionResult> UpdateCnpj(int Id, Fornecedor fornecedor, IFornecedorData fornecedorData)
        {
            ViaCep viaCep = new ViaCep();
            var response = await viaCep.ValidaCep(fornecedor.Cep);
            if (!response.IsSuccessStatusCode) return BadRequest("Cep Inválido");

            fornecedor.SetId(Id);

            var empresaResult = await fornecedorData.UpdateCnpj(fornecedor);

            if (empresaResult == null) return NotFound();

            return Ok(empresaResult);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Update(int Id, IFornecedorData fornecedorData)
        {
            var empresaResult = await fornecedorData.Delete(Id);

            if (empresaResult == null) return NotFound();

            return Ok(empresaResult);
        }
    }
}