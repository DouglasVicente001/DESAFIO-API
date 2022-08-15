using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Models;

namespace ProjetoAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Cachorro> Cachorros { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        
        public DbSet<Usuario> Usuarios { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Usuario>()
            .HasData(
                new Usuario { Id = 1, Email = "Veterinario@gft.com", Senha = "Gft@1234"}
            );

            modelBuilder.Entity<Cliente>()
            .HasData(
                new Cliente { Id = 1, NomeCliente = "Clecio" },
                new Cliente { Id = 2, NomeCliente = "Frederico" },
                new Cliente { Id = 3, NomeCliente = "Pedro" },
                new Cliente { Id = 4, NomeCliente = "Kestrel" }
            );
            modelBuilder.Entity<Veterinario>()
            .HasData(
                new Veterinario { Id = 1, NomeVeterinario = "Dr.Faust" },
                new Veterinario { Id = 2, NomeVeterinario = "Dr.David Banner" },
                new Veterinario { Id = 3, NomeVeterinario = "Dra.Potter" }
            );
            modelBuilder.Entity<Cachorro>()
            .HasData(
                new Cachorro { Id = 1, NomeCachorro = "Floquinho", Raca = "Dálmata", ClienteId = 2 },
                new Cachorro { Id = 2, NomeCachorro = "Rex", Raca = "PitBull", ClienteId = 1 },
                new Cachorro { Id = 3, NomeCachorro = "Fred", Raca = "HuskySiberiano", ClienteId = 2 },
                new Cachorro { Id = 4, NomeCachorro = "Lilica", Raca = "Yorkshire", ClienteId = 3 },
                new Cachorro { Id = 5, NomeCachorro = "Penélope", Raca = "Poodle", ClienteId = 3 },
                new Cachorro { Id = 6, NomeCachorro = "Hulk", Raca = "Rottweiler", ClienteId = 3 },
                new Cachorro { Id = 7, NomeCachorro = "Yoda", Raca = "Pinscher", ClienteId = 4 },
                new Cachorro { Id = 8, NomeCachorro = "Merlim", Raca = "PastorAlemão", ClienteId = 1 }
            );
            modelBuilder.Entity<Atendimento>()
            .HasData(
                new Atendimento { Id = 1, VeterinarioId = 2, ClienteId = 1, Temperamento = "Agressivo", Diagnostico = "Animal com fortes dores na região do torax.", DataEntrada = DateTime.Now },
                new Atendimento { Id = 2, VeterinarioId = 2, ClienteId = 1, Temperamento = "Passivo", Diagnostico = "Animal com dores na região da barriga.", DataEntrada = DateTime.Now },

                new Atendimento { Id = 3, VeterinarioId = 1, ClienteId = 2, Temperamento = "Sociável", Diagnostico = "Animal registrado para vacinação.", DataEntrada = DateTime.Now },
                new Atendimento { Id = 4, VeterinarioId = 1, ClienteId = 2, Temperamento = "Passivo", Diagnostico = "Animal apresentou-se com desânimo e vômito.", DataEntrada = DateTime.Now },

                new Atendimento { Id = 5, VeterinarioId = 3, ClienteId = 3, Temperamento = "Sociável", Diagnostico = "Animal registrado para vacinação", DataEntrada = DateTime.Now },
                new Atendimento { Id = 6, VeterinarioId = 3, ClienteId = 3, Temperamento = "Passivo", Diagnostico = "Animal registrado para castração", DataEntrada = DateTime.Now },
                new Atendimento { Id = 7, VeterinarioId = 3, ClienteId = 3, Temperamento = "Agressivo", Diagnostico = "Animal registrado para vacinação", DataEntrada = DateTime.Now },

                new Atendimento { Id = 8, VeterinarioId = 2, ClienteId = 4, Temperamento = "Agressivo", Diagnostico = "Animal com perna direita traseira supostamente fraturada", DataEntrada = DateTime.Now }
                );

            modelBuilder.Entity("AtendimentoCachorro")
            .HasData(
    new { AtendimentosId = 1, CachorrosId = 8 },
    new { AtendimentosId = 2, CachorrosId = 2 },
    new { AtendimentosId = 3, CachorrosId = 1 },
    new { AtendimentosId = 4, CachorrosId = 3 },

    new { AtendimentosId = 5, CachorrosId = 4 },
    new { AtendimentosId = 6, CachorrosId = 5 },
    new { AtendimentosId = 7, CachorrosId = 6 },

    new { AtendimentosId = 8, CachorrosId = 7 }
    );

        }
    }
}