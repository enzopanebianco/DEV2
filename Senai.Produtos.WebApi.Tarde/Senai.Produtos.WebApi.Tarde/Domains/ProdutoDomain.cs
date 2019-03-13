using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Produtos.WebApi.Tarde.Domains
{
    public class ProdutoDomain
    {
       public int ID  {get;set;}
       public string Nome { get; set; }
       public string Descricao { get; set; }
    }
}
