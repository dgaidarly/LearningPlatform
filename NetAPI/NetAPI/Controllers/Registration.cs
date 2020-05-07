using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VieJSLearning.Cryptography;
using VieJSLearning.Dal;
using VieJSLearning.Dal.Entities;
using VieJSLearning.Dal.Models;
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
            using (var dal = new DalWrapper())
            {
                var users = dal.UserRepository.Get()
                    .Select(x=>new User
                {

                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    Mail = x.Mail
                });
                return users;
            }
        }

        [HttpGet]
        public User Get(string id)
        {
            using (var dal = new DalWrapper())
            {
                var users = dal.UserRepository
                    .Get(x => x.Id == id)
                    .Select(x => new User
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        SecondName = x.SecondName,
                        Mail = x.Mail
                    });
                return users.FirstOrDefault();
            }
        }

        [HttpPost]
        public string SaveNewUser(User user)
        {
            using (var dal = new DalWrapper())
            {
                var isEmailExist = dal.UserRepository.Get(x => x.Mail == user.Mail).Any();
                if (isEmailExist)
                {
                    return "Указанный e-mail уже используется.";
                }
                var userEntity = new UserEntity
                {
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    Mail = user.Mail,
                    Password = Encryptor.Instance.GetEncryptedPass(user.Password)
                };
                userEntity.SetId();
                dal.UserRepository
                    .Insert(userEntity);
                dal.Save();
                return string.Empty;
            }
        }

    }
}