using Microsoft.AspNetCore.Mvc;
using System;

namespace SmartSchool.WebApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() {
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