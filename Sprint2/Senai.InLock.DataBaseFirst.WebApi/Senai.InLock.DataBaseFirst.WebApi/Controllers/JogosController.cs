using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.DataBaseFirst.WebApi.Domains;
using Senai.InLock.DataBaseFirst.WebApi.Interfaces;
using Senai.InLock.DataBaseFirst.WebApi.Repositories;

namespace Senai.InLock.DataBaseFirst.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogosRepository JogosRepository;

        public JogosController()
        {
            JogosRepository = new JogosRepository();
        }
        [HttpGet]
        public IActionResult Get() {
            try
            {
                return Ok(JogosRepository.Listar());
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Post(Jogos jogos)
        {
            try
            {
                JogosRepository.Cadastrar(jogos);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult Put(Jogos jogos)
        {
            try
            {
                JogosRepository.Atualizar(jogos);
                return Ok();
            }
            catch (Exception EX)
            {

                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult Delete(Jogos jogos)
        {
            try
            {
                JogosRepository.Deletar(jogos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}