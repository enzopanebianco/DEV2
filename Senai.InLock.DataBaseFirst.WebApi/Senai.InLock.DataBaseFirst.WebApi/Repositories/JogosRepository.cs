using Senai.InLock.DataBaseFirst.WebApi.Domains;
using Senai.InLock.DataBaseFirst.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.DataBaseFirst.WebApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        public void Atualizar(Jogos jogos)
        {
            using (InLockContext ctx = new InLockContext())
            {
               
                ctx.Jogos.Update(jogos);
                ctx.SaveChanges();
                
            }
        }

        public void Cadastrar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        public void Deletar(Jogos jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Remove(jogo);
                ctx.SaveChanges();
            }
        }

        public List<Jogos> Listar()
        {
            List<Jogos> lsJogos = new List<Jogos>();
            using (InLockContext ctx = new InLockContext())
            {
                

                return ctx.Jogos.ToList();
            }
        }
    }
}
