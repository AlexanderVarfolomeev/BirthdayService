﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BirthdayApi.Domain
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public UserStatus Status { get; set; }
    }
}