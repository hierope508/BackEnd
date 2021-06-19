using AnimaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anima.BLL
{
    public class BLLMatricula
    {
        public void Save(AnimaDBContext context, JsonElement body)
        {
            try
            {
                var matricula = JsonSerializer.Deserialize<TbMatricula>(body.ToString());

                using (context)
                {
                    var aluno = context.TbAluno.Where(a => a.Ra == matricula.Ra).FirstOrDefault();
                    var grade = context.TbGrade.Where(g => g.CodGrade== matricula.CodGrade).FirstOrDefault();

                    if(aluno == null)
                        throw new Exception("Aluno não existe");

                    if (grade == null)
                        throw new Exception("Grade não existe");

                    if (context.TbMatricula.Where(m => m.Ra == matricula.Ra && m.CodGrade == grade.CodGrade).Any())
                            throw new Exception("Aluno já matriculado");

                        context.TbMatricula.Add(matricula);

                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                //Log exception
                throw;
            }

        }

        public void Delete(AnimaDBContext context, JsonElement value)
        {
            try
            {
                var mat = JsonSerializer.Deserialize<TbMatricula>(value.ToString());
                using (context)
                {
                    var matricula = from ma in context.TbMatricula
                                    join grade in context.TbGrade
                                    on ma.CodGrade equals grade.CodGrade
                                    where
                                        (grade.CodGrade == mat.CodGrade || grade.CodParentGrade == mat.CodGrade)
                                         && ma.Ra == mat.Ra
                                    select ma;

                    var ma2 = matricula.FirstOrDefault();

                    if (ma2 == null)
                        throw new Exception("Matricula não encontrada");

                    context.TbMatricula.Remove(ma2);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
