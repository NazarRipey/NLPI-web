﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NLPI.Core.DTO.AchievementsDTOs.StandartDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
