using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebApi.Models;
using SmartSchool.WebApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartSchool.WebApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService professorService;

        public ProfessorController(IProfessorService professorService)
        {
            this.professorService = professorService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(professorService.GetAllProfessores());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{professorId}")]
        public async Task<IActionResult> GetByProfessorId(int professorId)
        {
            try
            {
                return Ok(await professorService.GetProfessorAsync(professorId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(ProfessorEditModel model)
        {
            try
            {
                if ((await professorService.AddProfessorAsync(model)) is ProfessorEditModelReturn professorReturnModel)
                {
                    return Ok(professorReturnModel);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{professorId}")]
        public async Task<IActionResult> Put(int professorId, ProfessorEditModel model)
        {
            try
            {
                if ((await professorService.UpdateProfessorAsync(professorId, model)) is ProfessorEditModelReturn professorModelReturn)
                {
                    return Ok(professorModelReturn);
                }
                return BadRequest();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete("{professorId}")]
        public async Task<IActionResult> Delete(int professorId)
        {
            try
            {
                if (await professorService.DeleteProfessorAsync(professorId))
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}