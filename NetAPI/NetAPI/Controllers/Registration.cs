using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VieJSLearning.Dal.Entities;
using VieJSLearning.Dal.Models;
using VieJSLearning.Dal.Repositories;
using VieJSLearning.Dal.Tools;

namespace VieJSLearning.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Registration : ControllerBase
    {
        private readonly ILogger<Registration> _logger;

        public Registration(ILogger<Registration> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public IEnumerable<User> GetAll()
        {
            var user = Get();
            var userEntity = new UserEntity
            {
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Mail = user.Mail
            };
            userEntity.SetId();

            var repo = new GenericRepository<UserEntity>();
            repo.Get

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new User
                {
                    FirstName = $"Федор{rng.Next(1, 5)}",
                    SecondName = $"Иванов{rng.Next(1, 5)}",
                    Mail = $"test{rng.Next(1, 5)}@gmail.com"
                })
                .ToArray();
        }

        [HttpGet]
        public User Get()
        {
            return new User
            {
                FirstName = "Федор",
                SecondName = "Иванов",
                Mail = "test1@gmail.com"
            };
        }
    }
}