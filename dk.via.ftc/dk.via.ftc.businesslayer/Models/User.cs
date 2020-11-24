using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dk.via.ftc.businesslayer.Models
{
    public interface User
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public void Update(User userToUpdate)
        {
            Password = userToUpdate.Password;
            Email = userToUpdate.Email;
            LastName = userToUpdate.LastName;
        }
    }
}
