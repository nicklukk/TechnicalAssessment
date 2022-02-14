﻿using System;
using System.Collections.Generic;

namespace TechnicalAssessment.Api.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
