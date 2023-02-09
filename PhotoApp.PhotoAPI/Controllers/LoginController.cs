using AutoMapper;
using DTO.DtoModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoApp.BLL.Entity.Abstract;
using PhotoApp.DAL.EntityFramework;
using PhotoApp.Entities.Models;
using PhotoApp.PhotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.PhotoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly PhotoDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository; 

        public LoginController(PhotoDbContext context, IMapper mapper,IUserRepository userRepository)
        {
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]CheckUserResponseDto CheckUserDto)
        {
            ServiceResponse<UserDto.User> responses = new ServiceResponse<UserDto.User>();
            var user = _userRepository.GetEx(x => x.UserName == CheckUserDto.UserName && x.Aktif == true && x.Password == CheckUserDto.Password).SingleOrDefault();
            if (user == null)
            {
                responses.HasError = true;
                responses.ErrorsAndWarnings.Add("Giriş Başarısız.!");
                responses.IsSuccessFul = false;
                return BadRequest(responses);
            }
            var ass = await _context.FindAsync<User>(CheckUserDto.Id);
            return Ok(responses);
        }
    }
}
