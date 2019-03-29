using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.CodeFirst.WebApi.Domains;
using Senai.InLock.CodeFirst.WebApi.Interfaces;
using Senai.InLock.CodeFirst.WebApi.Repositories;

namespace Senai.InLock.CodeFirst.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogoRepository JogoRepository;

        public JogosController()
        {
            JogoRepository = new JogoRepository();
        }
        [HttpPost]
        public IActionResult Post(JogoDomain jogo)
        {
            try
            {
                JogoRepository.Cadastrar(jogo);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                
                return Ok(JogoRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }
        }
    }
}