using Microsoft.AspNetCore.Mvc;

namespace Desafio_Fullstack_Accenture.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmpresaController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(IEmpresaData empresaData) => Ok(await empresaData.GetAll());

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id, IEmpresaData empresaData)
        {
            var empresaResult = await empresaData.GetById(Id);

            if (empresaResult == null) return NotFound();

            return Ok(empresaResult);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(Empresa empresa, IEmpresaData empresaData)
        {
            var empresaResult = await empresaData.Insert(empresa);

            if (empresaResult == null) return NotFound();

            return Ok(empresaResult);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, Empresa empresa, IEmpresaData empresaData)
        {
            empresa.SetId(Id);

            var empresaResult = await empresaData.Update(empresa);

            if (empresaResult == null) return NotFound();

            return Ok(empresaResult);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Update(int Id, IEmpresaData empresaData)
        {
            var empresaResult = await empresaData.Delete(Id);

            if (empresaResult == null) return NotFound();

            return Ok(empresaResult);
        }
    }
}