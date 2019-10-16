using APIModeloDDD.Domain.Models;
using APIModeloDDD.Presentation.VM.Person;
using AutoMapper;

namespace APIModeloDDD.Presentation.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Person, PersonPostVM>();
            CreateMap<PersonDeleteVM, Person>();
        }
    }
}
