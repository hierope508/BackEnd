using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Anima.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Anima.Controllers
{
    [Route("school/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        readonly AnimaDBContext _context;
        readonly BLLMatricula _matriculaBLL;

        public MatriculaController()
        {
            _context = new AnimaDBContext();
            _matriculaBLL = new BLLMatricula();
        }


        // POST api/<MatriculaController>
        [HttpPost]
        public void Post([FromBody] JsonElement value)
        {
            try
            {
                _matriculaBLL.Save(_context, value);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                Response.WriteAsync("Ocorreu um erro ao matricular o Aluno\n");
                Response.WriteAsync(ex.Message);
                Response.WriteAsync(ex.StackTrace);
            }
        }

        // DELETE school/<MatriculaController>/5
        [HttpDelete]
        public void Delete([FromBody] JsonElement matricula)
        {
            try
            {
                _matriculaBLL.Delete(_context, matricula);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                Response.WriteAsync("Ocorreu um erro ao matricular o Aluno\n");
                Response.WriteAsync(ex.Message);
                Response.WriteAsync(ex.StackTrace);
                throw;
            }
            

        }
    }
}
