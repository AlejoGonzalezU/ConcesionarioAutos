using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConcesionarioAutos.DAL.Entities;
using ConcesionarioAutos.Shared;
using Microsoft.EntityFrameworkCore;
using Humanizer;
using ConcesionarioAutos.Data;

namespace ConcesionarioAutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public UsersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()

        {   
            var responseApi = new ResponseApi <List<User>> ();
            var Lista_users = new List<User> ();



            try
            {
                foreach (var item in await _dbContext.Users.ToListAsync())
                {
                    Lista_users.Add(new User { Id = item.Id, UserName = item.UserName, PhoneNumber = item.PhoneNumber });
              
                }


                responseApi.isCorrect = true;
                responseApi.Valor = Lista_users;
            }catch (Exception ex) {
                responseApi.isCorrect = false;
                responseApi.Mensaje = ex.Message;


            }

            return Ok(responseApi);

        }
    }
}
