using Senai.InLock.DataBaseFirst.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.DataBaseFirst.WebApi.Interfaces
{
    public interface IJogosRepository
    {
        List<Jogos> Listar();

        void Cadastrar(Jogos jogo);

        void Atualizar(Jogos jogos);

        void Deletar(Jogos jogo);
    }
}
