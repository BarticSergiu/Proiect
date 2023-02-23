using System.ComponentModel.DataAnnotations;

namespace Proiect.Models
{
    public class Persoana
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele este necesar")]
        [Display(Name = "Nume persoana")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Prenumele este necesar")]
        public string Prenume { get; set; }

        [Required(ErrorMessage = "Selectarea sexului este necesară")]
        public string Sex { get; set; }
    }
}