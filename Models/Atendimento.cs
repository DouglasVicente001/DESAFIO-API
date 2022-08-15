using System;
using System.Collections.Generic;

namespace ProjetoAPI.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public int VeterinarioId { get; set; }
        public Veterinario Veterinario { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataEntrada { get; set; }
        public List<Cachorro> Cachorros { get; set; }
        public string Temperamento { get; set; }
        public string Diagnostico { get; set; }

        
    

    }
}