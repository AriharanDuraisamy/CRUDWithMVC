using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework
{
    public class Registration
    {
        [Key]
        public long RegistrationId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public IEnumerable<Registration> Registrations { get; set; }
    }
}
