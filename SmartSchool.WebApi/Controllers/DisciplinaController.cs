using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebApi.Models;
using SmartSchool.WebApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartSchool.WebApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaService disciplinaService;

        public DisciplinaController(IDisciplinaService disciplinaService)
        {
            this.disciplinaService = disciplinaService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(disciplinaService.GetAllDisciplinas());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{disciplinaId}")]
        public async Task<IActionResult> GetByDisciplinaId(int disciplinaId)
        {
            try
            {
                return Ok(await disciplinaService.GetDisciplinaAsync(disciplinaId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(DisciplinaEditModel model)
        {
            try
            {
                if ((await disciplinaService.AddDisciplinaAsync(model)) is DisciplinaEditModelReturn disciplinaModelReturn)
                {
                    return Ok(disciplinaModelReturn);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("{disciplinaId}")]
        public async Task<IActionResult> Put(int disciplinaId, DisciplinaEditModel model)
        {
            try
            {
                if ((await disciplinaService.UpdateDisciplinaAsync(disciplinaId, model)) is DisciplinaEditModelReturn disciplinaModelReturn)
                {
                    return Ok(disciplinaModelReturn);
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

        [HttpDelete("{disciplinaId}")]
        public async Task<IActionResult> Delete(int disciplinaId)
        {
            try
            {
                if (await disciplinaService.DeleteDisciplinaAsync(disciplinaId))
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