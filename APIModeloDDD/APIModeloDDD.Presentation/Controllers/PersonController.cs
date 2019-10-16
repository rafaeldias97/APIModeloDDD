using APIModeloDDD.Domain.Interfaces;
using APIModeloDDD.Domain.Models;
using APIModeloDDD.Domain.Validations;
using APIModeloDDD.Presentation.VM.JWT;
using APIModeloDDD.Presentation.VM.Person;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIModeloDDD.Presentation.Controllers
{
    [Route("api/v1/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository repository;
        private IMapper mapper { get; set; }

        private readonly TokenConfigurations tokenConfigurations;
        public PersonController(IMapper mapper, IPersonRepository repository, TokenConfigurations tokenConfigurations)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.tokenConfigurations = tokenConfigurations; 
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Auth([FromBody] PersonAuthVM auth, [FromServices] PersonAuthValidator validator)
        {
            var _auth = this.mapper.Map<Person>(auth);
            var _validator = validator.Validate(_auth);

            if (!_validator.IsValid) return BadRequest(new { Erros = _validator.Errors });

            int id = repository.Auth(_auth);

            if (id != 0)
            {
                //Generate token
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.Key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[] {
                    new Claim("id", id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(tokenConfigurations.Issuer,
                    tokenConfigurations.Issuer,
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);

                return Ok(new { accessToken = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest("Usuário Inválido");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await repository.All();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonPostVM person, [FromServices] PersonPostValidator validator)
        {
            var _person = this.mapper.Map<Person>(person);

            var _validator = validator.Validate(_person);
            if (!_validator.IsValid) return BadRequest(new { Erros = _validator.Errors });

            await repository.Save(_person);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Person person)
        {
            await repository.Update(person);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] PersonDeleteVM person)
        {
            var _person = this.mapper.Map<Person>(person);
            await repository.Delete(_person);
            return Ok();
        }
    }
}