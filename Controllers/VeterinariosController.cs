using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Data;
using ProjetoAPI.DTO;
using ProjetoAPI.Models;

namespace ProjetoAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize(Roles = "Veterinario")]
    public class VeterinariosController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public VeterinariosController(ApplicationDbContext database)
        {
            this.database = database;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var veterinario = database.Veterinarios.ToList();
            return Ok(veterinario);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var veterinario = database.Veterinarios.First(c => c.Id == id);
                if (veterinario.Id == id)
                {
                    return Ok(veterinario);
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
        public IActionResult Post([FromBody] VeterinariosTemp vTemp)
        {
            Veterinario veterinario = new Veterinario();
            veterinario.NomeVeterinario = vTemp.NomeVeterinario;
            database.Add(veterinario);
            database.SaveChanges();
            Response.StatusCode = 201;
            return new ObjectResult(veterinario);
        }
        [HttpPatch]
        public IActionResult Patch([FromBody] VeterinariosTemp vTemp)
        {
            try
            {
                var veterinario = database.Veterinarios.First(v => v.Id == vTemp.Id);

                veterinario.Id = vTemp.Id;
                veterinario.NomeVeterinario = vTemp.NomeVeterinario;

                database.Update(veterinario);
                database.SaveChanges();
                return Ok(veterinario);

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
                var veterinario = database.Veterinarios.First(v => v.Id == id);
                if (veterinario.Id == id)
                {
                    database.Remove(veterinario);
                    database.SaveChanges();
                    Response.StatusCode = 200;
                    return new ObjectResult(new { info = "Id deletado com sucesso", veterinario });
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