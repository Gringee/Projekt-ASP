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
        public int Id { get; set; }
        [Column("Data")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Data { get; set; }
        [MaxLength(100)]
        public string Opis { get; set; }
        [MaxLength(30)]
        public string Aparat {  get; set; }
        [Required]
        public string Autor { get; set; }
        [Required] 
        public string Resolution { get; set; }
        [Required]
        public string Format { get; set; }
        public int Priority { get; set; }
       
    }
}
