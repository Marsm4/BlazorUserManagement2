﻿namespace BlazorUserManagement.Models
{
    public class UpdateUserDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}