using AnimaModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anima.BLL
{
    public class ProfessorBLL
    {
        private readonly BLLSecurity _bLLSecurity;

        public ProfessorBLL()
        {
            _bLLSecurity = new BLLSecurity();
        }
        public async Task<IEnumerable<Professor>> GetList(AnimaDBContext context)
        {
            var professors = from professor in context.TbProfessor
                         join usuario in context.TbUsuario
                            on professor.Cpf equals usuario.Cpf
                         select new Professor
                         {
                             Nome = usuario.Nome,
                             Login = usuario.Login,
                             Cpf = professor.Cpf,
                             Email = usuario.Email,
                             CodFuncionario = professor.CodFuncionario
                         };

            return await professors.ToListAsync();
        }


        public async Task<Professor> Get(AnimaDBContext context, string cpf)
        {

            var result = from p in context.TbProfessor
                         join usuario in context.TbUsuario
                            on p.Cpf equals usuario.Cpf
                         where
                             p.Cpf == cpf
                         select new Professor
                         {
                             Nome = usuario.Nome,
                             Login = usuario.Login,
                             Cpf = p.Cpf,
                             Email = usuario.Email,
                             CodFuncionario = p.CodFuncionario,

                         };

            var professor = await result.FirstOrDefaultAsync();

            if (professor == null)
                return null;

            double grades = (from grade in context.TbGrade
                          where
                             grade.CodFuncionario == professor.CodFuncionario
                          select grade
                          ).Count();


            double alunos = (from grade in context.TbGrade
                          join matricula in context.TbMatricula
                          on grade.CodGrade equals matricula.CodGrade
                          where
                             grade.CodFuncionario == professor.CodFuncionario
                          select matricula
              ).Count();


            double salario = ((alunos / 10) * grades) * 50 + 1200;

            professor.salario = salario;
            professor.TotalAlunos = (int)alunos;
            professor.TotalGrades = (int)grades;

            return professor;
        }

        public async Task<Professor> Get(AnimaDBContext context, int codFuncionario)
        {
            var professors = from professor in context.TbProfessor
                             join usuario in context.TbUsuario
                                on professor.Cpf equals usuario.Cpf
                             where
                                professor.CodFuncionario == codFuncionario
                             select new Professor
                             {
                                 Nome = usuario.Nome,
                                 Login = usuario.Login,
                                 Cpf = professor.Cpf,
                                 Email = usuario.Email,
                                 CodFuncionario = professor.CodFuncionario
                             };

            return await professors.FirstOrDefaultAsync();
        }

        public void Save(AnimaDBContext context, JsonElement body)
        {
            try
            {

                var professorModel = JsonSerializer.Deserialize<Professor>(body.ToString());

                var professor = new TbProfessor
                {
                    Cpf = professorModel.Cpf,
                    CodFuncionario= professorModel.CodFuncionario
                };

                var usuario = new TbUsuario
                {
                    Cpf = professorModel.Cpf,
                    Email = professorModel.Email,
                    Login = professorModel.Login,
                    Nome = professorModel.Nome,
                    Senha = _bLLSecurity.GenerateHashedPassword(professorModel.Senha)
                };

                if (context.TbUsuario.Where(u => u.Cpf == professor.Cpf).Any())
                {
                    context.TbUsuario.Update(usuario);

                    if(context.TbProfessor.Where(p=>p.Cpf==professor.Cpf).Any())
                        context.TbProfessor.Update(professor);
                    else
                        context.TbProfessor.Add(professor);
                }
                else
                {
                    context.TbUsuario.Add(usuario);
                    context.TbProfessor.Add(professor);
                }

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Log exception
                throw;
            }

        }
    }
}
