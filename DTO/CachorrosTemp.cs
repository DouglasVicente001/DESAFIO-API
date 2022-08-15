using System.Collections.Generic;
using ProjetoAPI.Models;

namespace ProjetoAPI.DTO
{
    public class CachorrosTemp
    {
        public int Id { get; set; }
        public string NomeCachorro  { get; set; }     
        public string Raca  { get; set; }                           
        public int ClienteId { get; set; }
    }
}