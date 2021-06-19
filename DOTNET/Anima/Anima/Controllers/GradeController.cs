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
    public class GradeController : ControllerBase
    {

        readonly AnimaDBContext _context;
        readonly GradeBLL _gradeBLL;

        public GradeController()
        {
            _context = new AnimaDBContext();
            _gradeBLL = new GradeBLL();
        }

        // GET: api/<GradeController>
        [HttpGet]
        public async Task<ActionResult<Grade>> Get([FromQuery] int codGrade)
        {
            var grade = await _gradeBLL.Get(_context, codGrade);

            if (grade == null)
            {
                return new EmptyResult();
            }

            return grade;
        }


        // POST api/<GradeController>
        [HttpPost]
        public void Post([FromBody] JsonElement value)
        {
            try
            {
                _gradeBLL.Save(_context, value);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                Response.WriteAsync("Ocorreu um erro ao cadastrar grade\n");
                Response.WriteAsync(ex.Message);
                Response.WriteAsync(ex.StackTrace);
            }
        }

        // PUT api/<GradeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GradeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
