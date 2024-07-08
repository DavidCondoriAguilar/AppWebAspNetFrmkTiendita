using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionTiendita.Models
{
    public class T_Categoria
    {
        //los nombres de los atributos de la clase
        //seran los nombres de los campos de la tabla
        //llave primaria
        [Key]
        //sea autonumerico --> identity(1,1)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codcat { get; set; }
        //no nulos
        [Required]
        //tamaño del campo
        [MaxLength(60, ErrorMessage = "El campo {0} de de tebe como " +
            "maximo {1}")]
        [StringLength(60)]
        public string nomcat { get; set; }
        //no nulos
        [Required]
        public bool estcat { get; set; }
    }
}
