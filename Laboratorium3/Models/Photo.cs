using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium3.Models
{
    public class Photo
    {
        [HiddenInput]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        [Required]
        public DateTime Data { get; set; }

        [Display(Name = "Opis zdjęcia")]
        [StringLength(maximumLength: 100, ErrorMessage = "Zbyt dlugi opis, wpisz max 100 znaków")]
        public string Opis { get;set; }

        [Display(Name = "Nazwa Aparatu")]
        [StringLength(maximumLength: 30, ErrorMessage = "max 30 znaków")]
        public string Aparat { get;set; }

        [Display(Name = "Autor")]
        [StringLength(maximumLength: 50, ErrorMessage = "max 50 znaków")]
        [Required(ErrorMessage = "Musisz podac autora")]
        public string Autor { get; set; }

        [Display(Name = "Rozdzielczość")]
        //[RegularExpression(@"^\d{4}x\d{3}$", ErrorMessage = "Rozdzielczość musi być w formacie np. 1920x1080")]
        [Required(ErrorMessage = "Musisz podać rozdzielczość")]
        public string Resolution { get; set; }
        [Display(Name = "Format")]
        [RegularExpression(@"^\d+x\d+$", ErrorMessage = "Format musi być w formacie np. 4x3 lub 16x9")]
        [Required(ErrorMessage = "Musisz podać format")]
        public string Format { get; set; }
        [Display(Name = "Priorytet")]
        public int Priority { get; set; }
        [HiddenInput]
        public int OrganizationId { get; set; }
        [ValidateNever]
        public List<SelectListItem> Organizations { get; set; }
    }
}
