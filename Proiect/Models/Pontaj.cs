using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proiect.Models
{
    public class Pontaj
    {
        public int id { get; set; }
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Data este necesară")]
        public int Data { get; set; }

        [DataType(DataType.Duration)]
        [Required(ErrorMessage = "Durata este necesară")]
        [Range(0, int.MaxValue)]
        public int Durata { get; set; }

        [Display(Name = "Sarcina")]
        [ForeignKey("Sarcina")]
        public int SarcinaId { get; set; }
        public Sarcina sarcinaObj { get; set; }

        public string Observatii { get; set; }
    }
}
