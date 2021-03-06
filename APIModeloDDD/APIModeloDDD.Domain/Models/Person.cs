﻿using System;
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
    }
}
