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
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public ClientesController(ApplicationDbContext database)
        {
            this.database = database;
        }
        [HttpGet]

        public IActionResult Get()
        {
            var clientes = database.Clientes.ToList();
            return Ok(clientes);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var clientes = database.Clientes.FirstOrDefault(c => c.Id == id);
                if (clientes.Id == id)
                {
                    return Ok(clientes);
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
        public IActionResult Post([FromBody] ClientesTemp cTemp)
        {

            Cliente cliente = new Cliente();
            cliente.NomeCliente = cTemp.NomeCliente;

            database.Add(cliente);
            database.SaveChanges();
            Response.StatusCode = 201;
            return new ObjectResult(cliente);
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] Cliente cliente)
        {
            try
            {
                var c = database.Clientes.First(c => c.Id == cliente.Id);

                if (cliente != null)
                {
                    c.Id = cliente.Id;
                    c.NomeCliente = cliente.NomeCliente != null ? cliente.NomeCliente : c.NomeCliente;
                    database.SaveChanges();
                    return Ok(c);
                }
                else
                {
                    Response.StatusCode = 400;
                    return new ObjectResult(new { info = "nada encontrado" });
                }
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
                var cliente = database.Clientes.FirstOrDefault(c => c.Id == id);

                if (cliente.Id != id)
                {
                    return StatusCode(404, "Id não encontrado");
                }
                else
                {
                    database.Clientes.Remove(cliente);
                    database.SaveChanges();
                    Response.StatusCode = 200;
                    return new ObjectResult(new { info = "Id deletado com sucesso", cliente });
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