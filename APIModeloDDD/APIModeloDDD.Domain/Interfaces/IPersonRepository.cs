using APIModeloDDD.Domain.Models;

namespace APIModeloDDD.Domain.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        int Auth(Person person);
    }
}
