using Senai.Produtos.WebApi.Tarde.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Produtos.WebApi.Tarde.Interfaces
{
    public interface IProdutoRepositorio
    {
        List<ProdutoDomain> Listar();
        void Cadastrar(ProdutoDomain produto);

    }
}
