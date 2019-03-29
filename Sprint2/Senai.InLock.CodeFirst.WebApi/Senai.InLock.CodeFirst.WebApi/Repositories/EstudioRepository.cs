using Senai.InLock.CodeFirst.WebApi.Context;
using Senai.InLock.CodeFirst.WebApi.Domains;
using Senai.InLock.CodeFirst.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        public void Alterar(EstudioDomain estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Update(estudio);
                ctx.SaveChanges();
            }  
        }

        public void Cadastrar(EstudioDomain estudio)
        {
            
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }

        public void Deletar(EstudioDomain estudio)
        {
            using (InLockContext ctx = new InLockContext())
            {
                
                ctx.Estudios.Remove(estudio);
                ctx.SaveChanges();
            }
        }

        public List<EstudioDomain> Listar()
        {
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Estudios.ToList();
            }
        }
    }
}
