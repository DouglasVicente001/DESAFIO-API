using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Data;
using ProjetoAPI.DTO;
using ProjetoAPI.Models;

namespace ProjetoAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize(Roles = "Veterinario")]
    public class CachorrosController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public CachorrosController(ApplicationDbContext database)
        {
            this.database = database;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var cachorros = database.Cachorros.Include(c => c.cliente).ToList();
            return Ok(cachorros);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var cachorros = database.Cachorros.First(c => c.Id == id);
                if (cachorros.Id == id)
                {
                    return Ok(cachorros);
                }
                else
                {
                    return StatusCode(404, "Id não encontrado");
                }

            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Id não encontrado" });
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] CachorrosTemp cTemp)
        {
            try
            {
                Cachorro cachorro = new Cachorro();
                cachorro.NomeCachorro = cTemp.NomeCachorro;
                cachorro.Raca = cTemp.Raca;
                cachorro.ClienteId = cTemp.ClienteId;
                database.Add(cachorro);
                database.SaveChanges();
                return Ok(cachorro);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Id não encontrado" });
            }
        }
        [HttpPatch]
        public IActionResult Patch([FromBody] CachorrosTemp cTemp)
        {
            try
            {
                var cachorro = database.Cachorros.First(c => c.Id == cTemp.Id);
                cachorro.Id = cTemp.Id;
                cachorro.NomeCachorro = cTemp.NomeCachorro;
                cachorro.Raca = cTemp.Raca;
                cachorro.ClienteId = cTemp.ClienteId;

                database.Update(cachorro);
                database.SaveChanges();
                return Ok(cachorro);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Id não encontrado" });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var cachorro = database.Cachorros.First(c => c.Id == id);
                if (cachorro.Id == id)
                {
                    database.Cachorros.Remove(cachorro);
                    database.SaveChanges();
                    Response.StatusCode = 200;
                    return new ObjectResult(new { info = "Id deletado com sucesso", cachorro });
                }
                else
                {
                    return StatusCode(404, "Id não encontrado");
                }

            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Id não encontrado" });
            }
        }
    }
}