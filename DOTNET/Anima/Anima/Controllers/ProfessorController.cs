using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Anima.BLL;
using AnimaModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Anima.Controllers
{
    [Route("school/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        readonly AnimaDBContext _context;
        readonly ProfessorBLL _professorBLL;

        public ProfessorController(AnimaDBContext context)
        {
            _context = context;
            _professorBLL = new ProfessorBLL();
        }

        // GET: school/<ProfessorController>
        [HttpGet]
        public async Task<ActionResult<Professor>> Get([FromQuery] string cpf)
        {
            var professor = await _professorBLL.Get(_context, cpf);

            if (professor == null)
            {
                return NotFound();
            }

            return professor;
        }


        // POST school/<ProfessorController>
        [HttpPost]
        public void Post([FromBody] JsonElement value)
        {
            try
            {
                _professorBLL.Save(_context, value);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                Response.WriteAsync("Ocorreu um erro ao cadastrar professor\n");
                Response.WriteAsync(ex.Message);
                Response.WriteAsync(ex.StackTrace);
            }
        }

    }
}
