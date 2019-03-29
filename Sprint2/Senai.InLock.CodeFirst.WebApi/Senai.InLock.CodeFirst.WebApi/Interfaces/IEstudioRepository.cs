using Senai.InLock.CodeFirst.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Interfaces
{

    public interface IEstudioRepository
    {
        List<EstudioDomain> Listar();
        void Cadastrar(EstudioDomain estudio);
        void Alterar(EstudioDomain estudio);
        void Deletar(EstudioDomain estudios);
    }
}
