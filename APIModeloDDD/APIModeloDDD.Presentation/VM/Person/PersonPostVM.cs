using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIModeloDDD.Presentation.VM.Person
{
    public class PersonPostVM
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime birthdate { get; set; }
    }
}
