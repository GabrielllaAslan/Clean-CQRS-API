﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.UserRepository
{
    public interface IUserRepository

    {
        Task<bool> AddUserAnimalAsync(UserAnimal userAnimal);
    }
}
