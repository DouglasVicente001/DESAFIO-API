using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjetoAPI.Data;
using ProjetoAPI.DTO;
using ProjetoAPI.Models;

namespace ProjetoAPI.Controllers
{   
    [Route("api/[Controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public UsuariosController(ApplicationDbContext database){
            this.database = database;
        }
        
        [HttpPost("Registro")]
        public IActionResult Registro([FromBody]Usuario usuario){

            database.Add(usuario);
            database.SaveChanges();
            return Ok(new {info = "Usuario criado com sucesso", usuario});
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody]UsuariosTemp credenciais){
            Usuario usuario = database.Usuarios.First(user => user.Email.Equals(credenciais.Email));
            if (usuario != null){
                
                    if (usuario.Senha.Equals(credenciais.Senha)){

                    string chaveDeSeguranca = "Projeto_Teste_Api_Gft";
                    var chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveDeSeguranca));
                    var credenciaisDeAcesso = new SigningCredentials(chaveSimetrica,SecurityAlgorithms.HmacSha256Signature);
                    
                    var claims = new List<Claim>();
                    claims.Add(new Claim("Id",usuario.Id.ToString()));
                    claims.Add(new Claim("email",usuario.Email));
                    claims.Add(new Claim(ClaimTypes.Role,"Veterinario"));

                    var JWT = new JwtSecurityToken(
                        issuer: "atividadeApi",
                        expires: DateTime.Now.AddHours(1),
                        audience: "usuario_comum",
                        signingCredentials: credenciaisDeAcesso,
                        claims: claims
                    );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(JWT)); 
                }else{
                    Response.StatusCode = 401;
                    return new ObjectResult(new {info = "Email ou senha incorretos"});
                }

            }else{
                Response.StatusCode = 401;
                return new ObjectResult(new {info = "Email ou senha incorretos"});
            }
        }
    }
}