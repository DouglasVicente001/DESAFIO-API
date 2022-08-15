using System;
using System.Collections.Generic;
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
    public class AtendimentosController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public AtendimentosController(ApplicationDbContext database)
        {
            this.database = database;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var atendimento = database.Atendimentos.Include(c => c.Cliente)
            .Include(v => v.Veterinario)
            .Include(c => c.Cachorros).ToList();
            Response.StatusCode = 201;
            return Ok(atendimento);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var atendimento = database.Atendimentos.Include(c => c.Cliente).
                Include(v => v.Veterinario).
                Include(c => c.Cachorros).FirstOrDefault(c => c.Id == id);

                if (atendimento.Id != id)
                {
                    return StatusCode(404, "Id não encontrado");
                }
                return Ok(atendimento);

            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Id não encontrado" });
            }

        }
        [Authorize(Roles = "Veterinario")]
        [HttpPost]
        public IActionResult Post([FromBody] AtendimentosTemp aTemp)
        {
            List<Cachorro> cachorros = new List<Cachorro>();

            foreach (var cachorroId in aTemp.CachorrosId)
            {
                var cachorroTemp = database.Cachorros.FirstOrDefault(c => c.Id == cachorroId);
                cachorros.Add(cachorroTemp);
            }
            try
            {
                Atendimento atendimento = new Atendimento();
                atendimento.ClienteId = aTemp.ClienteId;
                atendimento.VeterinarioId = aTemp.VeterinarioId;
                atendimento.Temperamento = aTemp.Temperamento;
                atendimento.Diagnostico = aTemp.Diagnostico;
                atendimento.DataEntrada = aTemp.DataEntrada;
                atendimento.Cachorros = cachorros;

                database.Add(atendimento);
                database.SaveChanges();

                return Ok(atendimento);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Id não encontrado" });
            }

        }
        [Authorize(Roles = "Veterinario")]
        [HttpPatch]
        public IActionResult Patch([FromBody] AtendimentosTemp aTemp)
        {
            try
            {
                List<Cachorro> cachorros = new List<Cachorro>();

                foreach (var cachorroId in aTemp.CachorrosId)
                {
                    var cachorroTemp = database.Cachorros.FirstOrDefault(c => c.Id == cachorroId);
                    cachorros.Add(cachorroTemp);
                }

                var atendimento = database.Atendimentos.Where(c => c.Id == aTemp.Id)
                .Include(c => c.Cachorros)
                .FirstOrDefault();

                atendimento.ClienteId = aTemp.ClienteId;
                atendimento.VeterinarioId = aTemp.VeterinarioId;
                atendimento.Temperamento = aTemp.Temperamento;
                atendimento.Diagnostico = aTemp.Diagnostico;
                atendimento.DataEntrada = aTemp.DataEntrada;
                atendimento.Cachorros = cachorros;

                database.Update(atendimento);
                database.SaveChanges();
                return Ok(atendimento);
            }
            catch (Exception)
            {
                Response.StatusCode = 404;
                return new ObjectResult(new { info = "Id não encontrado" });
            }
        }
        [Authorize(Roles = "Veterinario")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var atendimento = database.Atendimentos.Include(c => c.Cliente).
                Include(v => v.Veterinario).
                Include(c => c.Cachorros).FirstOrDefault(c => c.Id == id);
                if (atendimento.Id != id)
                {
                    return StatusCode(404, "Id não encontrado");
                }
                else
                {
                    database.Remove(atendimento);
                    database.SaveChanges();
                    Response.StatusCode = 200;
                    return new ObjectResult(new { info = "Id deletado com sucesso", atendimento });
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