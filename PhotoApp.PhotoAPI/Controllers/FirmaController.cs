using AutoMapper;
using DTO.DtoModel;
using Microsoft.AspNetCore.Mvc;
using PhotoApp.DAL.EntityFramework;
using PhotoApp.Entities.Models;
using System;
using System.Collections.Generic; 
using System.Linq;
using PhotoApp.PhotoAPI.Models;
using PhotoApp.BLL.Entity.Abstract; 
using PhotoApp.PhotoAPI.Filters.Exception;
using PhotoApp.PhotoAPI.Filters.Validation;
using System.Threading.Tasks;
using System.Data.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhotoApp.PhotoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : Controller
    {
        private readonly PhotoDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFirmaRepository _firmaRepository;
        private readonly IUserRepository _userRepository;
        public FirmaController(PhotoDbContext context, IMapper mapper, IFirmaRepository firmaRepository, IUserRepository userRepository)
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
        [HttpGet(Name = "GetFirma")]
        [FirmaException]
        public IActionResult GetFirma()
        {
             //throw new Exception("tetststetsdds");
            //throw new NotImplementedException("test");

            List<Firma> firma = _firmaRepository.GetAll(); 
            ServiceResponse<Firma> response = new ServiceResponse<Firma>
            {
                Entities = firma,
                IsSuccessFul = true
            };
            response.EntitiesCount = response.Entities.Count();

            return Ok(response);
        }


        [HttpGet("{Id}", Name = "GetFirmaById")]
        [FirmaException]
        public  IActionResult GetFirma(int Id)
        {
            Firma firma = _firmaRepository.GetByID(Id);

            var deger = _mapper.Map<FirmaDto.Firma>(firma);
            ServiceResponse<Firma> response = new ServiceResponse<Firma>
            {
                Entity = firma,
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
        [FirmaException]
        [FirmaValidate]
        public IActionResult Post([FromBody] FirmaDto.FirmaUser firmaDto)
        {
            ServiceResponse<FirmaDto.FirmaUser> responses = new ServiceResponse<FirmaDto.FirmaUser>();
            //List<Firma> firmaListe = _firmaRepository.GetAll().Where(x => x.FirmaAdi == firmaDto.FirmaAdi).ToList();
            List<Firma> firmaListe = _firmaRepository.GetEx(x => x.FirmaAdi == firmaDto.FirmaAdi);
            if (firmaListe.Count > 0)
            {
                responses.HasError = true;
                responses.ErrorsAndWarnings.Add("Firma Adı Bulunmaktadır! Başka Firma Adı Giriniz.!");
                responses.IsSuccessFul = false;
                return BadRequest(responses);
            } 
            //kullanıcı adı kontrolü koyulacak
            List<User> users = _userRepository.GetEx(x => x.UserName == firmaDto.UserName);
            if (users.Count > 0)
            {
                responses.HasError = true;
                responses.ErrorsAndWarnings.Add("Kullanıcı Adı Bulunmaktadır! Başka Kullanıcı Adı giriniz.!");
                responses.IsSuccessFul = false;
                return BadRequest(responses);
            }

            Firma firma = _mapper.Map<Firma>(firmaDto);
            firma.InsertDate = DateTime.Now;
            _firmaRepository.Add(firma);

           
            User user = _mapper.Map<User>(firmaDto);
            user.FirmaID = firma.ID;
            user.InsertDate = DateTime.Now;
            _userRepository.Add(user);


            var deger = _mapper.Map<FirmaDto.FirmaUser>(user);
            deger.FirmaAdi = firma.FirmaAdi;
            deger.UserID = user.ID;

            ServiceResponse<FirmaDto.FirmaUser> response = new ServiceResponse<FirmaDto.FirmaUser>
            {
                Entity = deger,
                IsSuccessFul = true
            };

            return Ok(response);
        }

        // PUT api/<FirmaController>/5
        [HttpPut("{id}")]
        [FirmaException]
        [FirmaValidate]
        public IActionResult Put(int id, [FromBody] FirmaDto.Firma firmaDto)
        {
            ServiceResponse<Firma> response = new ServiceResponse<Firma>();
            Firma firma = _firmaRepository.GetByID(id);
            //throw new NotImplementedException();
            if (firma == null)
            {
                response.HasError = true;
                response.ErrorsAndWarnings.Add("Firma Bulunamadı!");
                response.IsSuccessFul = false;
                return BadRequest(response);
            }
            List<Firma> firmaListe = _firmaRepository.GetEx(x => x.FirmaAdi == firmaDto.FirmaAdi && x.ID != id);
            if (firmaListe.Count > 0)
            {
                response.HasError = true;
                response.ErrorsAndWarnings.Add("Firma Adı Bulunmaktadır Başka Firma Adı Giriniz.!");
                response.IsSuccessFul = false;
                return BadRequest(response);
            }

            firma.FirmaAdi = firmaDto.FirmaAdi;
            firma.Aktif = firmaDto.Aktif;
            firma.UpdateDate = DateTime.Now;

            List<User> user = _userRepository.GetEx(x => x.FirmaID == id).ToList();
            if (user.Count > 0)
            {
                foreach (var item in user)
                {
                    item.Aktif = false;
                    item.DeletedDate = DateTime.Now;
                    _userRepository.Update(item);
                }

            } 
            _firmaRepository.Update(firma);
            response.Entity = firma;
            response.IsSuccessFul = true;



            return Ok(response);
        }

        // DELETE api/<FirmaController>/5
        [HttpDelete("{id}")]
        [FirmaException]
        public IActionResult Delete(int id)
        {
            ServiceResponse<Firma> response = new ServiceResponse<Firma>();
            Firma firma = _firmaRepository.GetEx(x => x.ID == id).FirstOrDefault();
            if (firma == null)
            {
                response.HasError = true;
                response.ErrorsAndWarnings.Add("Firma Bulunamadı!");
                response.IsSuccessFul = false;
                return BadRequest(response);
            }
            _firmaRepository.Delete(firma);
            response.ErrorsAndWarnings.Add("Başarıyla silindi.");
            response.IsSuccessFul = true;

            response.Entity = firma;

            return Ok(response);
        }
    }
}
