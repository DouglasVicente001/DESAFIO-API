using System.Collections.Generic;

namespace ProjetoAPI.Models
{
    public class Cachorro
    {
        public int Id { get; set; }
        public string NomeCachorro  { get; set; }     
        public string Raca  { get; set; }                           
        public int ClienteId { get; set; }
        public Cliente cliente { get; set; }
        public List<Atendimento> Atendimentos { get; set; }
    }
                             
}