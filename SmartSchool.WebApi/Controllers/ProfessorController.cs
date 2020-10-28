using System;
using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.WebApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok("");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
    }
}