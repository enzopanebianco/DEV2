using Senai.InLock.CodeFirst.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Interfaces
{
   public interface IJogoRepository
    {
        List<JogoDomain> Listar();
        void Cadastrar(JogoDomain jogo);
        void Alterar(JogoDomain jogo);
        void Deletar(JogoDomain jogo);
    }
}
