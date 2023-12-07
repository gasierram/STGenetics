using BlazorCrudShared;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly HttpClient _httpClient;
        public AnimalService(HttpClient httpClient) 
        {
             _httpClient = httpClient;
        }
        public async Task<List<AnimalDTO>> GetAnimals()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<List<AnimalDTO>>>("/api/Animal/Animals");

            if (result!.Success)
            {
                return result.value!;
            }
            else
            {
                throw new Exception(result.message);
            }

        }
        public async Task<AnimalDTO> GetAnimal(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<AnimalDTO>>($"/api/Animal/Search/{id}");

            if (result!.Success)
            {
                return result.value!;
            }
            else
            {
                throw new Exception(result.message);
            }

        }
        public async Task<int> Create(AnimalDTO animal)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/Animal/Create", animal);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response!.Success)
            {
                return response.value!;
            }
            else
            {
                throw new Exception(response.message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"/api/Animal/Delete/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response!.Success)
            {
                return response.Success!;
            }
            else
            {
                throw new Exception(response.message);
            }
        }

        public async Task<int> Edit(AnimalDTO animal)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/Animal/Edit/{animal.AnimalId}", animal);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();
            if (response!.Success)
            {
                return response.value!;
            }
            else
            {
                throw new Exception(response.message);
            }
        }





    }
}
