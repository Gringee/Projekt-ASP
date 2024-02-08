using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("photos")]
    public class PhotoEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public DateTime Data { get; set; }
        public string Opis { get; set; }
        public string Aparat {  get; set; }
        public string Autor { get; set; }
        [Required] 
        public string Resolution { get; set; }
        public string Format { get; set; }
       
    }
}
