using AutoMapper;
using DTO.DtoModel;
using Microsoft.AspNetCore.Mvc;
using PhotoApp.BLL.Entity.Abstract;
using PhotoApp.DAL.EntityFramework;
using PhotoApp.Entities.Models;
using PhotoApp.PhotoAPI.Filters.Exception;
using PhotoApp.PhotoAPI.Filters.Validation;
using PhotoApp.PhotoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.PhotoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly PhotoDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFirmaRepository _firmaRepository;
        private readonly IUserRepository _userRepository;
        public UserController(PhotoDbContext context, IMapper mapper, IFirmaRepository firmaRepository, IUserRepository userRepository)
        {
            _context = context;
            _mapper = mapper;
            _firmaRepository = firmaRepository;
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet(Name = "GetUser")]
        [UserException]
        public IActionResult GetUser()
        {
            //throw new Exception("tetststetsdds");
            //throw new NotImplementedException("test");
            //sessiondan firmaidsine göre gelecek

            List<User> user = _userRepository.GetAll();
           
            ServiceResponse<User> response = new ServiceResponse<User>
            {
                Entities = user,
                IsSuccessFul = true
            };
            response.EntitiesCount = response.Entities.Count();

            return Ok(response);
        }


        [HttpGet("{Id}", Name = "GetUserById")]
        [UserException]
        public IActionResult GetUser(int Id)
        {
            User user = _userRepository.GetByID(Id);

            var deger = _mapper.Map<UserDto.User>(user);
            ServiceResponse<UserDto.User> response = new ServiceResponse<UserDto.User>
            {
                Entity = deger,
                IsSuccessFul = true
            };
            if (response.Entity == null)
            {
                return BadRequest("Kayıt Bulunamadı");
            }
            else
            {
                return Ok(response);
            }
        }

        // POST api/<FirmaController>
        [HttpPost]
        [UserException]
        [UserValidate]
        public IActionResult Post([FromBody] UserDto.User userDto)
        {
            ServiceResponse<UserDto.User> responses = new ServiceResponse<UserDto.User>();
            //List<Firma> firmaListe = _firmaRepository.GetAll().Where(x => x.FirmaAdi == firmaDto.FirmaAdi).ToList(); 
            List<User> users = _userRepository.GetEx(x => x.UserName == userDto.UserName);
            if (users.Count > 0)
            {
                responses.HasError = true;
                responses.ErrorsAndWarnings.Add("Kullanıcı Adı Bulunmaktadır! Başka Kullanıcı Adı giriniz.!");
                responses.IsSuccessFul = false;
                return BadRequest(responses);
            }
            if (userDto.FirmaID == 0)
            {
                responses.HasError = true;
                responses.ErrorsAndWarnings.Add("Firma Seçiniz!");
                responses.IsSuccessFul = false;
                return BadRequest(responses);
            }
            if (userDto.KullaniciTipID == 0)
            {
                responses.HasError = true;
                responses.ErrorsAndWarnings.Add("Kullanıcı Tipi Seçiniz!");
                responses.IsSuccessFul = false;
                return BadRequest(responses);
            }
            if (userDto.KullaniciTipID == 1)
            {
                responses.HasError = true;
                responses.ErrorsAndWarnings.Add("Kullanıcı Tipi Firma Olamaz!");
                responses.IsSuccessFul = false;
                return BadRequest(responses);
            }
        
            User user = _mapper.Map<User>(userDto);
            user.ParentID = _userRepository.GetEx(x => x.FirmaID == userDto.FirmaID && x.KullaniciTipID == 1).Select(y => y.ID).FirstOrDefault();
            user.InsertDate = DateTime.Now;
            _userRepository.Add(user);

              
            var deger = _mapper.Map<UserDto.User>(user); 
            deger.FirmaAdi = _firmaRepository.GetEx(x => x.ID == userDto.FirmaID).Select(y => y.FirmaAdi).FirstOrDefault();
           
            responses.Entity = deger;
            responses.IsSuccessFul = true;
            

            return Ok(responses);
        }

        // PUT api/<FirmaController>/5
        [HttpPut("{id}")]
        [UserException]
        [UserValidate]
        public IActionResult Put(int id, [FromBody] UserDto.User userDto)
        {
            ServiceResponse<User> response = new ServiceResponse<User>();
            User user = _userRepository.GetByID(id);
            //throw new NotImplementedException();
            if (user == null)
            {
                response.HasError = true;
                response.ErrorsAndWarnings.Add("Kullanıcı Bulunamadı!");
                response.IsSuccessFul = false;
                return BadRequest(response);
            }

            user.Aktif = userDto.Aktif;
            user.ParentID = _userRepository.GetEx(x => x.FirmaID == userDto.FirmaID && x.KullaniciTipID == 1).Select(y => y.ID).FirstOrDefault();
            user.FirmaID = userDto.FirmaID;
            user.UserName = userDto.UserName;
            user.Password = userDto.Password;
            user.Ad = userDto.Ad;
            user.Soyad = userDto.Soyad;
            user.Telefon = userDto.Telefon;
            user.EMail = userDto.EMail;
            user.Adres = userDto.Adres;
            user.KullaniciTipID = userDto.KullaniciTipID;
            user.UpdateDate = DateTime.Now;
          
            _userRepository.Update(user);
            response.Entity = user;
            response.IsSuccessFul = true;

            return Ok(response);
        }

        // DELETE api/<FirmaController>/5
        [HttpDelete("{id}")]
        [UserException]
        public IActionResult Delete(int id)
        {
            ServiceResponse<User> response = new ServiceResponse<User>();
            User user = _userRepository.GetEx(x => x.ID == id && x.KullaniciTipID != 1).FirstOrDefault();
            if (user == null)
            {
                response.HasError = true;
                response.ErrorsAndWarnings.Add("Yönetici Kullanıcısı Silinemez!");
                response.IsSuccessFul = false;
                return BadRequest(response);
            }
            _userRepository.Delete(user);
            response.ErrorsAndWarnings.Add("Başarıyla silindi.");
            response.IsSuccessFul = true;

            response.Entity = user;

            return Ok(response);
        }

    }
}
