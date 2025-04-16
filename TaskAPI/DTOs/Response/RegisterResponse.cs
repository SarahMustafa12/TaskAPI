﻿using System.ComponentModel.DataAnnotations;

namespace TaskAPI.DTOs.Response
{
    public class RegisterResponse
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
