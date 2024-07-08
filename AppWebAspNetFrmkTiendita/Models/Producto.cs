using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionTiendita.Models
{
    public class T_Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codpro { get; set; }
        [Required]
        [StringLength(60)]
        public string nompro { get; set; }
        [Required]
        [StringLength(500)]
        public string despro { get; set; }
        [Required]
        public decimal prepro { get; set; }
        [Required]
        public decimal canpro { get; set; }
        [Required]
        public bool estpro { get; set; }
        [Required]
        public int codcat { get; set; }
        [ForeignKey("codcat")]
        public virtual T_Categoria categoria { get; set; }
    }
}