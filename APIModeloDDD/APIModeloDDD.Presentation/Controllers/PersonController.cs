using APIModeloDDD.Domain.Interfaces;
using APIModeloDDD.Domain.Models;
using APIModeloDDD.Presentation.VM.Person;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APIModeloDDD.Presentation.Controllers
{
    [Route("api/v1/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository repository;
        private IMapper mapper { get; set; }
        public PersonController(IMapper mapper, IPersonRepository repository)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await repository.All();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonPostVM person)
        {
            var _person = this.mapper.Map<Person>(person);
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