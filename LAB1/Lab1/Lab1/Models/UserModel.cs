﻿namespace Lab1.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public IFormFile Image { get; set; }
    }
}
