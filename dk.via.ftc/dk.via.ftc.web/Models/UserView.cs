﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dk.via.ftc.web.Models
{
    public class UserView
    {
        [Key]
        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("password")] public string Password { get; set; }


        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [Required]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        public void Update(UserView userToUpdate)
        {
            Password = userToUpdate.Password;
            Email = userToUpdate.Email;
            LastName = userToUpdate.LastName;
        }
    }
}
