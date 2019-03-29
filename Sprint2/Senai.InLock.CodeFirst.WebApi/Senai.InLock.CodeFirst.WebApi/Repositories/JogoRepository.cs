using Senai.InLock.CodeFirst.WebApi.Context;
using Senai.InLock.CodeFirst.WebApi.Domains;
using Senai.InLock.CodeFirst.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        public void Alterar(JogoDomain jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Update(jogo);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(JogoDomain jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        public void Deletar(JogoDomain jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {

                ctx.Jogos.Remove(jogo);
                ctx.SaveChanges();
            }
        }

        public List<JogoDomain> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.ToList();
            }
        }
    }
}
