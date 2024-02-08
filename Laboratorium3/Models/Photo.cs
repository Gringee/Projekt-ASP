using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium3.Models
{
  
    public class Photo
    {
        [HiddenInput]
        public int Id { get; set; }
        public DateTime Data { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Zbyt dlugi opis, wpisz max 50 znaków")]
        public string Opis { get;set; }
        public string Aparat { get;set; }
        public string Autor { get; set; }
        [Required(ErrorMessage = "Musisz podac autora")]
        public string Resolution { get; set; }
        public string Format { get; set; }
    }
}
