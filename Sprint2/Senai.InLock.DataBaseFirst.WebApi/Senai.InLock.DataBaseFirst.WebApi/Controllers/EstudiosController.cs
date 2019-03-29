using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai.InLock.DataBaseFirst.WebApi.Domains;

namespace Senai.InLock.DataBaseFirst.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    return Ok(ctx.Estudios.ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Deu errado"
                });

            }
        }
        [HttpGet("estudiosComJogos")]
        public IActionResult BuscarEstudioComJogos()
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    return Ok(ctx.Estudios.Include("Jogos").ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest();

            }
        }
        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio)
        {
            try
            {
                using (InLockContext ctx =new InLockContext())
                {
                    ctx.Estudios.Add(estudio);
                    ctx.SaveChanges();
                }
                    return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new {
                mensagem = ex.Message +"Deu Ruim"});
            }
        }
        [HttpPut]
        public IActionResult Put(Estudios estudios)
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    Estudios estudioProcurado = ctx.Estudios.Find(estudios.Id);

                    if (estudioProcurado==null)
                    {
                        return NotFound();
                    }

                    estudioProcurado.Nome = estudios.Nome;
                    
                    ctx.Estudios.Update(estudioProcurado);
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
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    Estudios estudioProcurado = ctx.Estudios.Find(id);
                    if (estudioProcurado==null)
                    {
                        return NotFound();
                    }
                    ctx.Estudios.Remove(estudioProcurado);
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
