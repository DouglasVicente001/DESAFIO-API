using System;
using System.Net.Http;
using System.Net.Http.Headers;
using atividade_api.DTO.ConsumoApi;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoAPI.Data;

namespace atividade_api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ConsumoApiTheDogController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public ConsumoApiTheDogController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet("Pesquisar/ListaDeCachorros")]
        public IActionResult GetRacas()
        {
            try
            {
                string endpoint = $"v1/breeds?search";
                var listaRetorno = GetTheDog<DadosAnimais>(endpoint);
                return StatusCode(200, listaRetorno);
            }
            catch (Exception)
            {
                return StatusCode(404, "Nada encontrado");
            }
        }
        public T[] GetTheDog<T>(string endpoint) where T : class
        {
            using (var atendimentos = new HttpClient())
            {
                var chaveApi = "f7711c31-01c6-4b6b-9dfa-7a3bd095832f";
                atendimentos.BaseAddress = new Uri("https://api.thedogapi.com/");
                atendimentos.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-api-key", chaveApi);
                var response = atendimentos.GetStringAsync(endpoint);
                response.Wait();

                var listaRetorno = JsonConvert.DeserializeObject<T[]>(response.Result);
                return listaRetorno;
            }
        }
        [HttpGet("Pesquisar/PaginaçãoDeCachorros")]
        public IActionResult GetRacas([FromQuery] int pagina = 1, int limite = 10)
        {
            try
            {
                string endpoint = $"v1/breeds?page={pagina}&limit={limite}";
                var listaRetorno = GetTheDog<DadosAnimais>(endpoint);
                return StatusCode(200, listaRetorno);
            }
            catch (Exception)
            {
                return StatusCode(404, "Nada encontrado");
            }

        }
        [HttpGet("Pesquisar/RaçasDeCachorros")]
        public IActionResult GetRacas([FromQuery] string Nome)
        {
            try
            {
                string endpoint = $"v1/breeds/search?q={Nome}";
                var listaRetorno = GetTheDog<DadosAnimais>(endpoint);
                return StatusCode(200, listaRetorno);
            }
            catch (Exception)
            {
                return StatusCode(404, "Nada encontrado");
            }
        }
    }
}