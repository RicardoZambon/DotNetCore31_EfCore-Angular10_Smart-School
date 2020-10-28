using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebApi.Services;
using System;
using System.Threading.Tasks;

namespace SmartSchool.WebApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            this.alunoService = alunoService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(alunoService.GetAllAlunos());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{alunoId}")]
        public async Task<IActionResult> GetByAlunoId(int alunoId)
        {
            try
            {
                return Ok(await alunoService.GetAlunoAsync(alunoId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("GetByDisciplina/{disciplinaId}")]
        public IActionResult GetByDisciplinaId(int disciplinaId)
        {
            try
            {
                return Ok(alunoService.GetAlunosByDisciplinaId(disciplinaId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}