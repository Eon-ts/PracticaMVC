using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace PracticaMVC.Models
{
    public class marcas
    {
        [Key]
        [DisplayName("Id De Marca")]
        public int id_marcas { get; set; }


        [Required(ErrorMessage ="El nombre de la marca NO es opcional")]
        [DisplayName("Nombre de la marca")]
        public string? nombre_marca { get; set; }


        [DisplayName("Estado")]
        [StringLength(1, ErrorMessage = "La cantidad maxima de caracteres valida es {1}")]
        [Range(1,9, ErrorMessage ="Los valores aceptados son entre 1 y 9!")]
        public string? estados { get; set; }
    }
}
