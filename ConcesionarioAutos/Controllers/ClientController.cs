using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConcesionarioAutos.DAL.Entities;
using ConcesionarioAutos.Shared;
using Microsoft.EntityFrameworkCore;
using Humanizer;
using ConcesionarioAutos.Data;
using System.ComponentModel.DataAnnotations;

namespace ConcesionarioAutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ClientController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]

      
        public async Task<IActionResult> Lista()

        {
            var responseApi = new ResponseApi<List<Client>>();
            var Lista_Client = new List<Client>();



            try
            {
                foreach (var item in await _dbContext.Clients.ToListAsync())
                {
                    Lista_Client.Add(new Client { Id = item.Id, Name = item.Name, LastName = item.LastName, PhoneNumber = item.PhoneNumber, Email = item.Email });

                }


                responseApi.isCorrect = true;
                responseApi.Valor = Lista_Client;
            }
            catch (Exception ex)
            {
                responseApi.isCorrect = false;
                responseApi.Mensaje = ex.Message;


            }

            return Ok(responseApi);
        }

        [HttpGet]
        [Route("Buscar/{id}")]

        public async Task<IActionResult> Buscar(string id)

        {
            var responseApi = new ResponseApi<Client>();
            var ClientDto= new  Client();



            try
            {
                var DbClient = await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);

                if(DbClient != null)

                {
                    ClientDto.Id = DbClient.Name;
                    ClientDto.LastName = DbClient.LastName;
                    ClientDto.PhoneNumber = DbClient.PhoneNumber;

                    responseApi.isCorrect = true;
                    responseApi.Valor = ClientDto;

                } else
                {

                    responseApi.isCorrect = false;
                    responseApi.Mensaje = "no encontrado";
                }

            }
            catch (Exception ex)
            {
                responseApi.isCorrect = false;
                responseApi.Mensaje = ex.Message;


            }

            return Ok(responseApi);
        }

        [HttpPost]
        [Route("guardar")]

        public async Task<IActionResult> Guardar(Client clientDto)



        {
            var responseApi = new ResponseApi<string>();



            try
            {
                var DbClient = new Client
                {
                    Name = clientDto.Name,
                    LastName = clientDto.LastName,
                    PhoneNumber = clientDto.PhoneNumber,
                    Email = clientDto.Email,



                };


                _dbContext.Clients.Add(DbClient);
                await _dbContext.SaveChangesAsync();
               

                responseApi.isCorrect = true;
                responseApi.Valor = DbClient.Id;

            }
            catch (Exception ex)
            {
                responseApi.isCorrect = false;
                responseApi.Mensaje = "no guardado";


            }

            return Ok(responseApi);
        }


        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Editar(Client clientDto, string id)



        {
            var responseApi = new ResponseApi<string>();



            try
            {
                var DbClient = await _dbContext.Clients.FirstOrDefaultAsync(e => e.Id== id);
                
                if(DbClient != null)
                {
                    DbClient.Id = clientDto.Id;   
                    DbClient.Name = clientDto.Name;
                    DbClient.PhoneNumber = clientDto.PhoneNumber;
                    DbClient.Email = clientDto.Email;
                    _dbContext.Clients.Update(DbClient);
                    await _dbContext.SaveChangesAsync();


                    responseApi.isCorrect = true;
                    responseApi.Valor = DbClient.Id;
                }
                else
                {

                    responseApi.isCorrect = false;
                    responseApi.Mensaje = "Cliente no encontrado";
                }

              

            }
            catch (Exception ex)
            {
                responseApi.isCorrect = false;
                responseApi.Mensaje = "no guardado";


            }

            return Ok(responseApi);
        }

        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(string id)



        {
            var responseApi = new ResponseApi<string>();



            try
            {
                var DbClient = await _dbContext.Clients.FirstOrDefaultAsync(e => e.Id == id);

                if (DbClient != null)
                {
                   
                    _dbContext.Clients.Remove(DbClient);
                    await _dbContext.SaveChangesAsync();


                    responseApi.isCorrect = true;
                }
                else
                {

                    responseApi.isCorrect = false;
                    responseApi.Mensaje = "Cliente no encontrado";
                }



            }
            catch (Exception ex)
            {
                responseApi.isCorrect = false;
                responseApi.Mensaje = "no guardado";


            }

            return Ok(responseApi);
        }
    }
}