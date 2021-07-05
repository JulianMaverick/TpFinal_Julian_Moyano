using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinal_Julian_Moyano.Modelos
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get;set;}

        [Required]
        [StringLength(25)]
        public string Nombre { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public string CondicionIva { get; set; }

        [ForeignKey("Usuario")]  
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; } 



    }
    

}
