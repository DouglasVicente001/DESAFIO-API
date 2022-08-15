using System;
using System.Collections.Generic;
using ProjetoAPI.Models;

namespace ProjetoAPI.DTO
{
    public class AtendimentosTemp
    {
        public int Id { get; set; }
        public int VeterinarioId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataEntrada { get; set; }
        public List<int> CachorrosId { get; set; }
        public string Temperamento { get; set; }
        public string Diagnostico { get; set; }
        

    }
}