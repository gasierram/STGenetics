using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorCrudShared;
using STG.back.Models;
using Microsoft.EntityFrameworkCore;

namespace STG.back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly DbCrudBlazorContext _dbContext;

        public AnimalController(DbCrudBlazorContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet]
        [Route("Animals")]
        public async Task<IActionResult> GetAnimals()
        {
            var responseApi = new ResponseAPI<List<AnimalDTO>>();
            var animals = new List<AnimalDTO>();

            try
            {
                foreach (var animal in await _dbContext.Animals.ToListAsync())
                {
                    animals.Add(new AnimalDTO
                    {
                        AnimalId = animal.AnimalId,
                        Name = animal.Name,
                        Breed = animal.Breed,
                        BirthDate = animal.BirthDate,
                        Price = animal.Price,
                        Sex = animal.Sex,
                        Status = animal.Status

                    });

                }
                responseApi.Success = true;
                responseApi.value = animals;

            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.message = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpGet]
        [Route("Search/{id}")]
        public async Task<IActionResult> GetAnimal(int id)
        {
            var responseApi = new ResponseAPI<AnimalDTO>();
            var animal = new AnimalDTO();

            try
            {
                var dbAnimal = await _dbContext.Animals.FirstOrDefaultAsync(x => x.AnimalId == id);

                if (dbAnimal != null)
                {
                    animal.AnimalId = dbAnimal.AnimalId;
                    animal.Name = dbAnimal.Name;
                    animal.Breed = dbAnimal.Breed;
                    animal.BirthDate = dbAnimal.BirthDate;
                    animal.Price = dbAnimal.Price;
                    animal.Sex = dbAnimal.Sex;
                    animal.Status = dbAnimal.Status;


                    responseApi.Success = true;
                    responseApi.value = animal;
                }
                else
                {

                    responseApi.Success = false;
                    responseApi.message = "not found";
                }
            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.message = ex.Message;
            }

            return Ok(responseApi);
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(AnimalDTO animal)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbAnimal = new Animal
                {
                    //AnimalId = animal.AnimalId,
                    Name = animal.Name,
                    Breed = animal.Breed,
                    BirthDate = animal.BirthDate,
                    Price = animal.Price,
                    Sex = animal.Sex,
                    Status = animal.Status
                };

                _dbContext.Animals.Add(dbAnimal);
                await _dbContext.SaveChangesAsync();

                if (dbAnimal.AnimalId != 0)
                {
                    responseApi.Success = true;
                    responseApi.value = dbAnimal.AnimalId;
                }

            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.message = ex.Message;
            }

            return Ok(responseApi);
        }


        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(AnimalDTO animal, int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbAnimal = await _dbContext.Animals.FirstOrDefaultAsync(a => a.AnimalId == id);


                if (dbAnimal != null)
                {
                    dbAnimal.Name = animal.Name;
                    dbAnimal.Breed = animal.Breed;
                    dbAnimal.BirthDate = animal.BirthDate;
                    dbAnimal.Price = animal.Price;
                    dbAnimal.Sex = animal.Sex;
                    dbAnimal.Status = animal.Status;


                    _dbContext.Animals.Add(dbAnimal);
                    await _dbContext.SaveChangesAsync();


                    responseApi.Success = true;
                    responseApi.value = dbAnimal.AnimalId;
                }
                else
                {

                    responseApi.Success = false;
                    responseApi.message = "not saved";
                }

            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.message = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {
                var dbAnimal = await _dbContext.Animals.FirstOrDefaultAsync(a => a.AnimalId == id);


                if (dbAnimal != null)
                {
                   

                    _dbContext.Animals.Remove(dbAnimal);
                    await _dbContext.SaveChangesAsync();


                    responseApi.Success = true;
                }
                else
                {

                    responseApi.Success = false;
                    responseApi.message = "not saved";
                }

            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.message = ex.Message;
            }

            return Ok(responseApi);
        }

    }
}
