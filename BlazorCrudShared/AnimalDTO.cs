using System.ComponentModel.DataAnnotations;

namespace BlazorCrudShared
{
    public class AnimalDTO
    {
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; }
        

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        //Should be a DTO 
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]

        public string Sex { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]

        public decimal Price { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]

        public string Status { get; set; }
    }
}