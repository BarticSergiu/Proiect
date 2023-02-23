using System.ComponentModel.DataAnnotations;

namespace Proiect.Models
{
    public class Sarcina
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Denumirea sarcinii este necesară")]
        [Display(Name = "Denumire sarcina")]
        public string Denumire { get; set; }

        [Required(ErrorMessage = "Descrierea sarcinii este necesară")]
        public string Descriere { get; set; }

        [Display(Name = "Prioritate")]
        public string Prioritate { get; set; }

        public string TipSarcina { get; set; }


        [DataType(DataType.Duration)]
        [Required(ErrorMessage = "Estimarea orelor este necesară")]
        [Range(0, int.MaxValue)]
        public int OreEstimate { get; set; }

        [Display(Name = "Persoana")]
        public int PersoanaId { get; set; }
        public Persoana persoanaObj { get; set; }
    }
}