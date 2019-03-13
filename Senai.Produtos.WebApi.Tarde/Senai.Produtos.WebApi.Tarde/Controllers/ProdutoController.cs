using Microsoft.AspNetCore.Mvc;
using Senai.Produtos.WebApi.Tarde.Interfaces;
using Senai.Produtos.WebApi.Tarde.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Produtos.WebApi.Tarde.Controllers
{
    [Produces("application/json")] // Retorna formato Json
    [Route("api/[controller]")]
    [ApiController] //Implementa funcionalidades no Controller

    public class ProdutoController : ControllerBase
    {
        private IProdutoRepositorio ProdutoRepositorio { get; set; }


        public ProdutoController() {

            ProdutoRepositorio = new ProdutoRepositorio();
        }

        [HttpGet]
        public IActionResult Get(){
        
            return Ok(ProdutoRepositorio.Listar());
        }
    }
}

     


