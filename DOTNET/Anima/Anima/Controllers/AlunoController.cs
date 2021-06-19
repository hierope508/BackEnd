using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Anima.BLL;
using AnimaModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Anima.Controllers
{
    [Route("school/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        readonly AnimaDBContext _context;
        readonly AlunoBLL _alunoBLL;

        public AlunoController(AnimaDBContext context)
        {
            _context = context;
            _alunoBLL = new AlunoBLL();
        }

        // GET: school/<AlunoController>
        [HttpGet]
        public async Task<ActionResult<Aluno>> Get([FromQuery] string cpf)
        {
            var aluno = await _alunoBLL.Get(_context, cpf);

            if (aluno== null)
            {
                return NotFound();
            }

            return aluno;
        }


        // POST school/<AlunoController>
        [HttpPost]
        public void Post([FromBody] JsonElement value)
        {
            try
            {
                _alunoBLL.Save(_context, value);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                Response.WriteAsync("Ocorreu um erro ao cadastrar o Aluno\n");
                Response.WriteAsync(ex.Message);
                Response.WriteAsync(ex.StackTrace);
            }
        }
    }
}
