using AnimaModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anima.BLL
{
    public class GradeBLL
    {
        public async Task<Grade> Get(AnimaDBContext context, int codGrade)
        {
            var grades = (from grade in context.TbGrade
                          join professor in context.TbProfessor
                             on grade.CodFuncionario equals professor.CodFuncionario
                          join usuario in context.TbUsuario
                             on professor.Cpf equals usuario.Cpf
                          where
                              grade.CodGrade == codGrade

                          select new Grade
                          {
                              CodGrade = grade.CodGrade
                              ,
                              CodParentGrade = grade.CodParentGrade
                              ,
                              Disciplina = grade.NomeDisciplina
                              ,
                              Curso = grade.NomeCurso
                              ,
                              Turma = grade.NomeTurma
                             ,
                              CodFuncionario = professor.CodFuncionario
                             ,
                              EmailProfessor = usuario.Email
                             ,
                              NomeProfessor = usuario.Nome
                             ,
                              CpfProfessor = professor.Cpf
                             ,
                              Alunos = new List<AlunoGrade> { }
                          }).FirstOrDefault();

            if (grades != null)
            {
                var alunos =

                (from aluno in context.TbAluno
                 join usuario in context.TbUsuario
                 on aluno.Cpf equals usuario.Cpf
                 join matricula in context.TbMatricula
                 on new { grades.CodGrade, aluno.Ra } equals new { matricula.CodGrade, matricula.Ra }
                 select new AlunoGrade
                 {
                     Ra = aluno.Ra
,
                     Email = usuario.Email
,
                     Nome = usuario.Nome
                 }).ToList();

                var subGrade = from grade in context.TbGrade
                               join matricula in context.TbMatricula
                               on grade.CodGrade equals matricula.CodGrade
                               join aluno in context.TbAluno
                               on matricula.Ra equals aluno.Ra
                               join usuario in context.TbUsuario
                               on aluno.Cpf equals usuario.Cpf
                               where
                                grade.CodParentGrade == grades.CodGrade
                               
                               select new AlunoGrade
                               {
                                   Ra = aluno.Ra
                                   ,
                                   Email = usuario.Email
                                   ,
                                   Nome = usuario.Nome
                               };


                if (subGrade != null && subGrade.Any())
                    alunos.AddRange(subGrade.ToList());

                grades.Alunos.AddRange(alunos);

            }

            return grades;
        }

        public void Save(AnimaDBContext context, JsonElement body)
        {
            try
            {
                var grade = JsonSerializer.Deserialize<TbGrade>(body.ToString());

                using (context)
                {
                    var professor = context.TbProfessor.Where(p => p.CodFuncionario == grade.CodFuncionario).FirstOrDefault();

                    if (professor == null)
                        throw new Exception("Professor não existe");

                    var currentGrade = context.TbGrade.Where(g => g.CodGrade == grade.CodGrade).FirstOrDefault();

                    if (currentGrade != null)
                    {
                        if (currentGrade.CodParentGrade != null || currentGrade.CodParentGrade == 0)
                            throw new Exception("A grade que está tentando atualizar é inválida");

                        context.TbGrade.Update(grade);
                    }
                    else
                    {
                        context.TbGrade.Add(grade);
                    }

                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                //Log exception
                throw;
            }

        }
    }
}
