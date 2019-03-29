using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.CodeFirst.WebApi.Context;
using Senai.InLock.CodeFirst.WebApi.Domains;
using Senai.InLock.CodeFirst.WebApi.Interfaces;
using Senai.InLock.CodeFirst.WebApi.Repositories;

namespace Senai.InLock.CodeFirst.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository EstudioRepository;

        public EstudiosController()
        {
            EstudioRepository = new EstudioRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
               
                return Ok(EstudioRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Post(EstudioDomain estudio)
        {
            try
            {
                EstudioRepository.Cadastrar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpPut]
        public IActionResult Put( EstudioDomain estudio)
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    EstudioDomain estudioRetornado = ctx.Estudios.Find(estudio.ID);

                    if (estudioRetornado == null)
                    {
                        return NotFound();
                    }
                    estudioRetornado.NomeEstudio = estudio.NomeEstudio;

                    EstudioRepository.Alterar(estudioRetornado);
                    ctx.SaveChanges();
                }
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {

                    
                    EstudioDomain estudioRetornado = ctx.Estudios.Find(id);

                    if (estudioRetornado == null)
                    {
                        return NotFound();
                    }

                    EstudioRepository.Deletar(estudioRetornado);
                    ctx.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
                
            }
        }
    }
}