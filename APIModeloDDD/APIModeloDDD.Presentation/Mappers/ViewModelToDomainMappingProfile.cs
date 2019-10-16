using APIModeloDDD.Domain.Models;
using APIModeloDDD.Presentation.VM.Person;
using AutoMapper;

namespace APIModeloDDD.Presentation.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PersonPostVM, Person>();
            CreateMap<PersonDeleteVM, Person>();
            CreateMap<PersonAuthVM, Person>();
        }
    }
}
