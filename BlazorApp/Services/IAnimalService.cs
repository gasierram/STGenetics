using BlazorCrudShared;

namespace BlazorApp.Services
{
    public interface IAnimalService
    {
        Task<List<AnimalDTO>> GetAnimals();
        Task<AnimalDTO> GetAnimal(int id);

        Task<int> Create(AnimalDTO animal);
        Task<int> Edit(AnimalDTO animal);
        Task<bool> Delete(int id);
    }
}
