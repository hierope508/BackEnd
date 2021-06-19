using AnimaModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Anima.BLL
{
    public class AlunoBLL
    {
        private readonly BLLSecurity _bLLSecurity;

        public AlunoBLL()
        {
            _bLLSecurity = new BLLSecurity();
        }

        public async Task<IEnumerable<Aluno>> GetList(AnimaDBContext context)
        {
            var alunos = from aluno in context.TbAluno
                         join usuario in context.TbUsuario
                            on aluno.Cpf equals usuario.Cpf
                         select new Aluno
                         {
                             Nome = usuario.Nome,
                             Login = usuario.Login,
                             Cpf = aluno.Cpf,
                             Email = usuario.Email,
                             RA = aluno.Ra
                         };

            return await alunos.ToListAsync();
        }

        public async Task<Aluno> Get(AnimaDBContext context, string cpf)
        {
            var aluno = from alunos in context.TbAluno
                        join usuarios in context.TbUsuario
                           on alunos.Cpf equals usuarios.Cpf
                        where
                            alunos.Cpf == cpf
                        select new Aluno
                        {
                            Nome = usuarios.Nome,
                            Login = usuarios.Login,
                            Cpf = alunos.Cpf,
                            Email = usuarios.Email,
                            RA = alunos.Ra
                        };

            return await aluno.FirstOrDefaultAsync();
        }

        public void Save(AnimaDBContext context, JsonElement body)
        {
            try
            {
                var alunoModel = JsonSerializer.Deserialize<Aluno>(body.ToString());

                var aluno = new TbAluno
                {
                    Cpf = alunoModel.Cpf,
                    Ra = alunoModel.RA
                };

                var usuario = new TbUsuario
                {
                    Cpf = alunoModel.Cpf,
                    Email = alunoModel.Email,
                    Login = alunoModel.Login,
                    Nome = alunoModel.Nome,
                    Senha = _bLLSecurity.GenerateHashedPassword(alunoModel.Senha)
                };

                using (context)
                {

                    if (context.TbUsuario.Where(u => u.Cpf == aluno.Cpf).Any())
                    {
                        context.TbUsuario.Update(usuario);
                        
                        if (context.TbAluno.Where(a => a.Cpf == aluno.Cpf).Any())
                            context.TbAluno.Update(aluno);
                        else
                            context.TbAluno.Add(aluno);
                    }
                    else
                    {
                        context.TbUsuario.Add(usuario);
                        context.TbAluno.Add(aluno);
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
