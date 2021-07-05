using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpFinal_Julian_Moyano.Modelos
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]



        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(25)]
        public string Contraseña { get; set; }

        [Required]
        public bool Admin { get; set; }

    
    
    }


}

