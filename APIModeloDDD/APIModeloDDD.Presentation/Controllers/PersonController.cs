using APIModeloDDD.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace APIModeloDDD.Presentation.Controllers
{
    [Route("api/[controller]")]
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
    }
}