using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Skola_Forma.Models
{
    public class Lietotaji
    {
        [Required(ErrorMessage = "Šajā laukā ir jāievada dati.")]
        [MinLength(3, ErrorMessage = "Vārdam jābūt vismaz 30 simbolus garam."), MaxLength(30, ErrorMessage = "Vārdam jābūt maksimāli 30 simbolus garam.")]
        [RegularExpression("^[a-zA-ZĒŪĪŌĀŠĢĶĻŽČŅēūīōāšģķļžčņ]+$", ErrorMessage = "Drīkst ievadīt tikai burtus.")]
        [Display(Name = "Vārds")]
        public string Vards { get; set; }
        [Required(ErrorMessage = "Šajā laukā ir jāievada dati.")]
        [MinLength(3, ErrorMessage = "Uzvārdam jābūt vismaz 3 simbolus garam."), MaxLength(30, ErrorMessage = "Uzvārdam jābūt maksimāli 30 simbolus garam.")]
        [RegularExpression("^[a-zA-ZĒŪĪŌĀŠĢĶĻŽČŅēūīōāšģķļžčņ]+$", ErrorMessage = "Drīkst ievadīt tikai burtus.")]
        [Display(Name = "Uzvārds")]
        public string Uzvards { get; set; }
        [Required(ErrorMessage = "Šajā laukā ir jāievada dati.")]
        [MinLength(10, ErrorMessage = "Adresei jābūt vismaz 10 simbolus garai."), MaxLength(150, ErrorMessage = "Adresei jābūt maksimāli 150 simbolus garai.")]
        public string Adrese { get; set; }
        [Required(ErrorMessage = "Šajā laukā ir jāievada dati.")]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "Telefona numuram jābūt 8 ciparus garam.")]
        public int Telefons { get; set; }
    }
}
