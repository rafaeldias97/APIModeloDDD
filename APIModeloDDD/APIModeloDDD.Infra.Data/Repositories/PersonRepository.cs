using APIModeloDDD.Domain.Interfaces;
using APIModeloDDD.Domain.Models;
using System.Linq;

namespace APIModeloDDD.Infra.Data.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(Context.Context context) : base(context)
        {
        }

        public int Auth(Person person)
        {
            var res = context.Person.Where(x => x.email == person.email && x.senha == person.senha).FirstOrDefault();
            if (res != null)
            {
                return res.id;
            }

            return 0;
        }
    }
}
