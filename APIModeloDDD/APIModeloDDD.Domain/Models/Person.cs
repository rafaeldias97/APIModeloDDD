using System;
using System.Collections.Generic;
using System.Text;

namespace APIModeloDDD.Domain.Models
{
    public class Person : BaseEntity
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime birthdate { get; set; }

        public int idade()
        {
            // Save today's date.
            var today = DateTime.Today;
            // Calculate the age.
            var age = today.Year - this.birthdate.Year;
            // Go back to the year the person was born in case of a leap year
            if (this.birthdate.Date > today.AddYears(-age)) age--;

            return age;
        }

    }
}
