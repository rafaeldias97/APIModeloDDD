using APIModeloDDD.Domain.Interfaces;
using APIModeloDDD.Domain.Models;

namespace APIModeloDDD.Infra.Data.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(Context.Context context) : base(context)
        {
        }
    }
}
